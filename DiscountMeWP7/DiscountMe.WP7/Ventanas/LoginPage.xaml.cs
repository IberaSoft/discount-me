using System;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Navigation;
using DiscountMe.DiscountMeService;
using DiscountMe.Languages.Idiomas;
using DiscountMe.WP7.Helpers;
using Microsoft.Phone.Controls;

namespace DiscountMe.Ventanas {
    public partial class LoginPage : PhoneApplicationPage {
        private readonly DiscountMeServiceSoapClient servicioLogin;

        public LoginPage() {
            InitializeComponent();
            servicioLogin = new DiscountMeServiceSoapClient();
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e) {
            servicioLogin.LoginCompleted += LoginCompleted;
            servicioLogin.LoginAsync(nombreUsuarioTextBox.Text, passwordTextBox.Password, ExtendedPropertyHelper.GetWindowsLiveAnonymousId());
        }

        void LoginCompleted(object sender, LoginCompletedEventArgs e) {
            if (e.Result == null) {
                MessageBox.Show(Texts.TextoUsuarioIncorrecto, Texts.TextoError, MessageBoxButton.OK);
                return;
            }
            MessageBox.Show(Texts.TextoBienvenida, Texts.TextoCorrecto, MessageBoxButton.OK);
            if (recuerdameToggleSwitch.IsChecked != null && recuerdameToggleSwitch.IsChecked.Value)
                GuardarInfoUsuario(e.Result);
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e) {
            base.OnNavigatedFrom(e);
            NavigationService.RemoveBackEntry();
        }

        private void GuardarInfoUsuario(User usuario) {
            var configuracion = IsolatedStorageSettings.ApplicationSettings;
            configuracion["NombreUsuario"] = usuario.UserName;
            configuracion["Password"] = usuario.Password;
            configuracion["Email"] = usuario.Email;
            configuracion.Save();
        }
    }
}