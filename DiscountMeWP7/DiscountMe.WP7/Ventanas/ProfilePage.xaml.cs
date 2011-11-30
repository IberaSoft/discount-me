using System.IO.IsolatedStorage;
using System.Windows;
using Microsoft.Phone.Controls;

namespace DiscountMe.WP7.Ventanas {
    public partial class ProfilePage : PhoneApplicationPage {
        public ProfilePage() {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e) {
            var configuracion = IsolatedStorageSettings.ApplicationSettings;
            if (configuracion.Contains("NombreUsuario"))
                NombreUsuarioTextBlock.Text = configuracion["NombreUsuario"].ToString();
            if (configuracion.Contains("Email"))
                EmailUsuarioTextBlock.Text = configuracion["Email"].ToString();
        }

        private void OnCerrarSesionButtonClick(object sender, RoutedEventArgs e) {
            var configuracion = IsolatedStorageSettings.ApplicationSettings;
            configuracion.Remove("NombreUsuario");
            configuracion.Remove("Password");
            configuracion.Remove("Email");
            configuracion.Save();
            NavigationService.GoBack();
        }
    }
}