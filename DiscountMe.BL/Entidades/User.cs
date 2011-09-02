using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace DiscountMe.BL {
    public class User : EntidadBase {

        #region Primitive Properties

        public virtual string Name { get; set; }

        public virtual string Surname { get; set; }

        public virtual string UserName { get; set; }

        public virtual string Password { get; set; }

        public virtual string Email { get; set; }

        public virtual string PasswordSalt { get; set; }
        
        public virtual DateTime CreateDate { get; set; }
        
        public virtual DateTime LastModifiedDate { get; set; }
        
        public virtual DateTime LastLoginDate { get; set; }

        public virtual string LastLoginIp { get; set; }
        
        public virtual bool IsActivated { get; set; }
        
        public virtual bool IsLockedOut { get; set; }
        
        public virtual DateTime LastLockedOutDate { get; set; }
        
        public virtual string NewPasswordKey { get; set; }
        
        public virtual DateTime NewPasswordRequestedDate { get; set; }
        
        public virtual string NewEmailKey { get; set; }
        
        #endregion

        #region Navigation Properties

        public virtual List<Rol> Roles { get; set; }

        public virtual List<UserPreferences> Preferences { get; set; }

        #endregion

        public override ValidationResult SelfValidate() {
            return ValidationHelper.Validate<UserValidator, User>(this);
        }
    }
}