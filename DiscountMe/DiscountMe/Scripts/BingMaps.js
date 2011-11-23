var map = null;
var click = null;
var pushpindragstart = null;
var pushpin = null;
var pinLayer, pinInfobox;
var pushpinOptions = { draggable: true };

function getMapKey() {
    var ret;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '/Home/GetMapKey',
        dataType: "json",
        async: false,
        success: function (data, textStatus) {
            ret = data;
        },
        error: function (data, textStatus, errorThrown) {
            alert("Error");
            return null;
        }
    });
    return ret;
}

function getCurrentLocation() {
    var geoLocationProvider = new Microsoft.Maps.GeoLocationProvider(map);
    geoLocationProvider.getCurrentPosition();
}

function SetView(location) {
    //A buffer limit to use to specify the infobox must be away from the edges of the map.
    var buffer = 25;

    var infoboxOffset = pinInfobox.getOffset();
    var infoboxAnchor = pinInfobox.getAnchor();
    var infoboxLocation = map.tryLocationToPixel(location, Microsoft.Maps.PixelReference.control);

    var dx = infoboxLocation.x + infoboxOffset.x - infoboxAnchor.x;
    var dy = infoboxLocation.y - 25 - infoboxAnchor.y;

    if (dy < buffer) {	//Infobox overlaps with top of map.
        //Offset in opposite direction.
        dy *= -1;
        //add buffer from the top edge of the map.
        dy += buffer;
    }
    else {
        //If dy is greater than zero than it does not overlap.
        dy = 0;
    }
    if (dx < buffer) {	//Check to see if overlapping with left side of map.
        //Offset in opposite direction.
        dx *= -1;
        //add a buffer from the left edge of the map.
        dx += buffer;
    }
    else {		//Check to see if overlapping with right side of map.
        dx = map.getWidth() - infoboxLocation.x + infoboxAnchor.x - pinInfobox.getWidth();
        //If dx is greater than zero then it does not overlap.
        if (dx > buffer) {
            dx = 0;
        }
        else {
            //add a buffer from the right edge of the map.
            dx -= buffer;
        }
    }

    //Adjust the map so infobox is in view
    if (dx != 0 || dy != 0) {
        map.setView({ centerOffset: new Microsoft.Maps.Point(dx, dy), center: map.getCenter() });
    }
}

function getAddres(location) {
    var address = null;
//    jQuery.support.cors = true;
    var geoZone = {};
    geoZone["Latitude"] = location.latitude;
    geoZone["Longitude"] = location.longitude;
    $.ajax({
        type: "POST",
        async: false,
        contentType: "application/json; charset=utf-8",
        url: "/Home/DatosPosicion",
        data: JSON.stringify(geoZone),
        dataType: "json",
        success: function (data, textStatus) {
            address = data;
        },
        error: function (data, textStatus, errorThrown) {
            address = '';
        }
    });
    return address;
}

function setPushpin(e) {
    // Sacado de http://stackoverflow.com/questions/8590875/how-to-get-lat-lon-of-a-mouse-click-with-bing-maps-ajax-control-v7
    var point = new Microsoft.Maps.Point(e.getX(), e.getY());
    var location = e.target.tryPixelToLocation(point);
    pushpin = new Microsoft.Maps.Pushpin(location, pushpinOptions);
    setPushPinData(location);
    Microsoft.Maps.Events.addHandler(pushpin, 'dragend', endDragDetails);  
    map.entities.push(pushpin);
    Microsoft.Maps.Events.addHandler(pushpin, 'click', displayEventInfo);
    Microsoft.Maps.Events.removeHandler(click);
}

function displayEventInfo(e) {
    if (e.targetType == "pushpin") {
        pinInfobox.setOptions({
            title: e.target.title,
            description: e.target.description,
            visible: true,
            showCloseButton: false,
            offset: new Microsoft.Maps.Point(0, 25)
        });
        var location = e.target.getLocation();
        pinInfobox.setLocation(location);
        SetView(location);
    }
    else {
        pinInfobox.setOptions({ visible: false });
    }
}

function infoBoxClick(e) {
    if (e.targetType == 'infobox') {
        e.target.setOptions({ visible: false });
    }
}

function endDragDetails(e) {
    var location = e.entity.getLocation();
    setPushPinData(location);
}