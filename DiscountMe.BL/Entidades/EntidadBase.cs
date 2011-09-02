using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace DiscountMe.BL {
    public abstract class EntidadBase : INotifyPropertyChanged, IDataErrorInfo {

        #region Properties
        public virtual int Id { get; set; }

        [ScaffoldColumn(false)]
        public virtual bool IsValid {
            get { return SelfValidate().IsValid; }
        }

        #endregion

        #region INotifyPropertyChanged

        public void RaisePropertyChanged(params string[] propertyName) {
            propertyName.ToList().ForEach(x => {
                                              if (PropertyChanged != null)
                                                  PropertyChanged(this, new PropertyChangedEventArgs(x));
                                          });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region FluentValidation

        public abstract ValidationResult SelfValidate();

        #endregion

        #region IDataErrorInfo

        [ScaffoldColumn(false)]
        public virtual string Error {
            get { return ValidationHelper.GetError(SelfValidate()); }
        }

        public virtual string this[string columnName] {
            get {
                var validationResults = SelfValidate();
                if (validationResults == null)
                    return string.Empty;
                var columnResults = validationResults.Errors.FirstOrDefault(x => string.Compare(x.PropertyName, columnName, true) == 0);
                return columnResults != null ? columnResults.ErrorMessage : string.Empty;
            }
        }

        #endregion
    }
}