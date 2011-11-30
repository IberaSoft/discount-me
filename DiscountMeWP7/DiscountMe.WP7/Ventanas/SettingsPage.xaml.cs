using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Windows;
using DiscountMe.Languages.Idiomas;
using Microsoft.Phone.Controls;
using Phone.Controls;

namespace DiscountMe.Ventanas {
    public partial class SettingsPage : PhoneApplicationPage {
        private PickerBoxDialog rangoDialog, medidaDialog;
        private readonly List<Rango> rangosDistancia = new List<Rango> {
                                                                           new Rango {Name = "50"},
                                                                           new Rango {Name = "100"},
                                                                           new Rango {Name = "150"},
                                                                           new Rango {Name = "200"},
                                                                           new Rango {Name = "250"},
                                                                           new Rango {Name = "300"},
                                                                           new Rango {Name = "350"},
                                                                           new Rango {Name = "400"}
                                                                       };
        private readonly List<Medida> unidadesMedida = new List<Medida>{new Medida {Name = "Metros"}, new Medida {Name = "Millas"}};
        private Rango rangoElegido;
        private Medida medidaElegida;

        public SettingsPage() {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e) {
            var configuracion = IsolatedStorageSettings.ApplicationSettings;
            if (configuracion.Contains("Rango")) {
                CambiarRangoButton.DataContext =
                    rangoElegido = rangosDistancia.FirstOrDefault(rango => rango.Name == configuracion["Rango"].ToString());
            }
            if (configuracion.Contains("Medida")) {
                CambiarMedidaButton.DataContext =
                    medidaElegida = unidadesMedida.FirstOrDefault(medida => medida.Name == configuracion["Medida"].ToString());
            }
        }

        private void InitRangoPickerBoxDialog() {
            rangoDialog = new PickerBoxDialog { ItemsSource = rangosDistancia, Title = Texts.TextoCategoriaAjustes };
            if (rangoElegido != null)
                rangoDialog.SelectedIndex = rangosDistancia.IndexOf(rangoElegido);
            rangoDialog.Unloaded += RangoDialogClosed;
        }

        private void InitMedidaPickerBoxDialog() {
            medidaDialog = new PickerBoxDialog { ItemsSource = unidadesMedida, Title = Texts.TextoCategoriaAjustes };
            if (medidaElegida != null)
                medidaDialog.SelectedIndex = unidadesMedida.IndexOf(medidaElegida);
            medidaDialog.Unloaded += MedidaDialogClosed;
        }

        private void MedidaDialogClosed(object sender, RoutedEventArgs e) {
            medidaElegida = (Medida)medidaDialog.SelectedItem;
            if (medidaElegida != null)
                CambiarMedidaButton.DataContext = unidadesMedida.FirstOrDefault(medida => medida.Name == medidaElegida.Name);
        }

        private void RangoDialogClosed(object sender, RoutedEventArgs e) {
            rangoElegido = (Rango)rangoDialog.SelectedItem;
            if (rangoElegido != null)
                CambiarRangoButton.DataContext = rangosDistancia.FirstOrDefault(rango => rango.Name == rangoElegido.Name);
        }

        private void OnCambiarRangoButtonClick(object sender, RoutedEventArgs e) {
            InitRangoPickerBoxDialog();
            if (rangosDistancia != null) {
                rangoDialog.SelectedIndex = rangosDistancia.IndexOf(rangoElegido);
            }
            rangoDialog.Show();
        }

        private void OnCambiarMedidaButton(object sender, RoutedEventArgs e) {
            InitMedidaPickerBoxDialog();
            if (medidaElegida != null) {
                medidaDialog.SelectedIndex = unidadesMedida.IndexOf(medidaElegida);
            }
            medidaDialog.Show();
        }

        private void OnGuardarButtonClick(object sender, RoutedEventArgs e) {
            var configuracion = IsolatedStorageSettings.ApplicationSettings;
            if (rangoElegido != null)
                configuracion["Rango"] = rangoElegido.Name;
            if (medidaElegida != null)
                configuracion["Medida"] = medidaElegida.Name;
            configuracion.Save();
            NavigationService.GoBack();
        }
        
        public class Rango {
            public string Name { get; set; }
        }

        public class Medida {
            public string Name { get; set; }
        }
    }
}