using System.Collections.Generic;
using System.Device.Location;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Windows;
using DiscountMe.DiscountMeService;
using DiscountMe.Languages.Idiomas;
using Microsoft.Phone.Controls;
using Phone.Controls;

namespace DiscountMe.Ventanas {
    public partial class SearchPage : PhoneApplicationPage {
        private PickerBoxDialog customDialog;
        private DiscountCategory categoriaElegida;
        private readonly List<DiscountCategory> listaCategorias;
        readonly GeoCoordinateWatcher gcw; 

        public SearchPage() {
            InitializeComponent();
            var app = Application.Current as App;
            if (app == null)
                return;
            listaCategorias = app.ListaCategorias;
            if (gcw == null)
                gcw = new GeoCoordinateWatcher();
            gcw.Start(); 
        }

        private void InitPickerBoxDialog() {
            customDialog = new PickerBoxDialog {ItemsSource = listaCategorias, Title = Texts.TextoCategoriaBusqueda};
            customDialog.Unloaded += CustomDialogClosed;
        }

        private void CustomDialogClosed(object sender, RoutedEventArgs e) {
            categoriaElegida = (DiscountCategory)customDialog.SelectedItem;
            if (categoriaElegida != null)
                CategoriaButton.DataContext = listaCategorias.FirstOrDefault(category => category.Name == categoriaElegida.Name);
        }
        
        private void OnCategoriaButtonClick(object sender, RoutedEventArgs e) {
            InitPickerBoxDialog();
            if (listaCategorias != null)
                customDialog.SelectedIndex = listaCategorias.IndexOf(categoriaElegida);
            customDialog.Show();
        }

        private void BuscarButtonClick(object sender, RoutedEventArgs e) {
            var servicio = new DiscountMeServiceSoapClient();
            servicio.DescuentosCercanosCompleted += DescuentosCercanosCompletado;
            var configuracion = IsolatedStorageSettings.ApplicationSettings;
            var rango = configuracion.Contains("Rango") ? int.Parse(configuracion["Rango"].ToString()) : 100;
            var medida = configuracion.Contains("Medida") ? configuracion["Medida"].ToString() : "Metros";
            servicio.DescuentosCercanosAsync(gcw.Position.Location.Latitude, gcw.Position.Location.Longitude, ParametrosTextBox.Text, rango, categoriaElegida, medida);
        }

        void DescuentosCercanosCompletado(object sender, DescuentosCercanosCompletedEventArgs e) {
            var app = Application.Current as App;
            if (app == null)
                return;
            app.POIs = e.Result.ToList();
            NavigationService.GoBack();
        }
    }
}