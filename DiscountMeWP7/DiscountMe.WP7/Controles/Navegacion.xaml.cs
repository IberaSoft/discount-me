using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DiscountMe.DiscountMeService;
using DiscountMe.Languages.Idiomas;
using Microsoft.Phone.Controls.Maps;

namespace DiscountMe.Controles {
    public partial class Navegacion : UserControl {
        public float NivelZoom = 17.0f;
        public int DistanciaAviso = 20;
        private readonly GeoCoordinateWatcher watcher;
        private readonly GeoCoordinate coordenadas;

        public Navegacion() {
            InitializeComponent();
            watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.Default) {MovementThreshold = DistanciaAviso};
            watcher.PositionChanged += WatcherPositionChanged;
            watcher.StatusChanged += WatcherStatusChanged;
            watcher.Start();
            coordenadas = new GeoCoordinate();
            if (coordenadas.IsUnknown)
                return;
            mapa.SetView(coordenadas, NivelZoom);
            mapa.Mode = new AerialMode();
        }

        private void PintarMiPosicion() {
            var pushpin = new Pushpin {
                                          Location = watcher.Position.Location,
                                          Background = new SolidColorBrush(Colors.Red),
                                          Content = "Yo"
                                      };
            mapa.Children.Add(pushpin);
        }

        private void WatcherStatusChanged(object sender, GeoPositionStatusChangedEventArgs e) {
            switch (e.Status) {
                case GeoPositionStatus.Ready:
                    break;
                case GeoPositionStatus.Disabled:
                    // location is unsupported or disabled on this device
                    MessageBox.Show(Texts.TextoGPSDesactivado, Texts.TextoAtencion, MessageBoxButton.OK);
                    break;
                case GeoPositionStatus.NoData:
                    watcher.Position.Location.Latitude = 54.086369f;
                    watcher.Position.Location.Longitude = 12.124754f;
                    break;
            }
        }

        private void PintarPOIs(IEnumerable<DiscountDTO> pois) {
            foreach (var pushpin in pois.Select(discountDto => new Pushpin {
                Content = string.Format("{0} a {1:C}",
                discountDto.Description,
                discountDto.Price),
                Location = new GeoCoordinate {
                    Latitude = discountDto.Latitude,
                    Longitude = discountDto.Longitude,
                }
            })) {
                mapa.Children.Add(pushpin);
            }
        }

        private void WatcherPositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e) {
            // Access the position information thusly:
            coordenadas.Latitude = e.Position.Location.Latitude;
            coordenadas.Longitude = e.Position.Location.Longitude;
            coordenadas.Altitude = e.Position.Location.Altitude;
            mapa.SetView(coordenadas, NivelZoom);
            mapa.Children.Clear();
            PintarMiPosicion();
            var app = Application.Current as App;
            if (app != null && (app.POIs != null && app.POIs.Count > 0)) {
                PintarPOIs(app.POIs);
            }
        }
    }
}