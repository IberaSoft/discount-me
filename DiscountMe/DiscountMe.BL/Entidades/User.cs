using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace DiscountMe.BL {
    public class User : EntidadBase {

        #region Primitive Properties

        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string PasswordSalt { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        public DateTime LastModifiedDate { get; set; }
        
        public DateTime LastLoginDate { get; set; }

        public string LastLoginIp { get; set; }
        
        public bool IsActivated { get; set; }
        
        public bool IsLockedOut { get; set; }
        
        public DateTime LastLockedOutDate { get; set; }
        
        public string NewPasswordKey { get; set; }
        
        public DateTime NewPasswordRequestedDate { get; set; }
        
        public string NewEmailKey { get; set; }
        
        #endregion

        #region Navigation Properties

        public List<Rol> Roles { get; set; }

        public List<UserPreferences> Preferences { get; set; }

        #endregion

        public override ValidationResult SelfValidate() {
            return ValidationHelper.Validate<UserValidator, User>(this);
        }
    }
}