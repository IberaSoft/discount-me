using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;
using DiscountMe.DiscountMeService;
using DiscountMe.Helpers;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Controls.Maps;

namespace DiscountMe {
    public partial class MainPage : PhoneApplicationPage {
        private DiscountMeServiceSoapClient servicioLogin;

        // Constructor
        public MainPage() {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            var app = Application.Current as App;
            if (app != null && (app.ListaCategorias == null || app.ListaCategorias.Count <= 0)) {
                servicioLogin = new DiscountMeServiceSoapClient();
                servicioLogin.ListaCategoriasCompleted += ListaCategoriasCompleted;
                servicioLogin.ListaCategoriasAsync();
               
            }
            if (app != null && (app.POIs != null && app.POIs.Count > 0)) {
                PintarPOIs(app.POIs);
            }
        }

        private void PintarPOIs(IEnumerable<DiscountDTO> pois) {
            foreach (var pushpin in pois.Select(discountDto => new Pushpin {
                Content = string.Format("{0} a {1:C}", discountDto.Description, discountDto.Price),
                Location = new GeoCoordinate{
                    Latitude = discountDto.Latitude,
                    Longitude = discountDto.Longitude,
                }})) {
                var mapa = LayoutRoot.GetChildObject<Map>("mapa");
                mapa.Children.Add(pushpin);
            }
        }

        void ListaCategoriasCompleted(object sender, ListaCategoriasCompletedEventArgs e) {
            if (e.Result != null) {
                var app = Application.Current as App;
                if (app != null) {
                    app.ListaCategorias = e.Result.ToList();
                }
            }
        }

        private void AboutMenuItemClick(object sender, EventArgs e) {
            NavigationService.Navigate(new Uri("/Ventanas/AboutPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void ProfileMenuItemClick(object sender, EventArgs e) {
            NavigationService.Navigate(new Uri("/Ventanas/ProfilePage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void SettingsMenuItemClick(object sender, EventArgs e) {
            NavigationService.Navigate(new Uri("/Ventanas/SettingsPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void AppbarSearchClick(object sender, EventArgs e) {
            NavigationService.Navigate(new Uri("/Ventanas/SearchPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}