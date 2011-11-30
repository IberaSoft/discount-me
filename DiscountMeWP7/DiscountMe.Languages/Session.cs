using System.ComponentModel;
using System.Globalization;
using System.Threading;

namespace DiscountMe.Languages {
    /// <summary>
    /// "Singleton"    
    /// </summary>
    public class Session : INotifyPropertyChanged {
        #region Singleton
        public static Session Instance;
        
        public static Session Current {
            get {
                return Instance ?? (Instance = new Session());
            }
        }
        #endregion

        #region public static CultureInfo Culture
        private CultureInfo culture;
        public static CultureInfo Culture {
            get {
                return Current.culture;
            }
            set {
                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = Current.culture = value;
                Current.OnPropertyChanged("Culture");
            }
        }
        #endregion

        #region Implementation INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}