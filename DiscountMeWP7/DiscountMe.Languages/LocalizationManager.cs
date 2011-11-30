using System.Windows;
using DiscountMe.Languages.Idiomas;

namespace DiscountMe.Languages {
    public class LocalizationManager : DependencyObject {
        #region Singleton

        private static LocalizationManager localizationManager;

        public static LocalizationManager Instance {
            get { return localizationManager ?? (localizationManager = new LocalizationManager()); }
        }

        public LocalizationManager() {
            Texts = new Texts();
            Session.Current.PropertyChanged += (s, e) => Texts = new Texts();
        }

        #endregion

        #region public Texts Texts

        public static readonly DependencyProperty TextsProperty = DependencyProperty.Register("Texts", typeof (Texts), typeof (LocalizationManager), null);

        public Texts Texts {
            get { return (Texts) GetValue(TextsProperty); }
            set { SetValue(TextsProperty, value); }
        }

        #endregion
    }
}