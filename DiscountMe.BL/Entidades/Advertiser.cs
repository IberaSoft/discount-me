using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace DiscountMe.BL {
    public class Advertiser : EntidadBase {

        #region Primitive Properties

        public virtual string Name { get; set; }

        public virtual string Surname { get; set; }

        public virtual string UserName { get; set; }

        public virtual string CompanyName { get; set; }

        public virtual string Website { get; set; }

        public virtual string Description { get; set; }

        public virtual string Cif { get; set; }

        public virtual string PrimaryPhone { get; set; }

        public virtual string PrimaryFax { get; set; }

        public virtual string Email { get; set; }

        public virtual string Comment { get; set; }

        public virtual string Password { get; set; }
        
        public virtual string PasswordSalt { get; set; }

        public virtual double Latitude { get; set; }
        
        public virtual double Longitude { get; set; }

        public virtual DateTime CreateDate { get; set; }
        
        public virtual DateTime LastModifiedDate { get; set; }
        
        public virtual DateTime LastLoginDate { get; set; }
        
        public virtual string LastLoginIp { get; set; }
        
        public virtual bool IsActivated { get; set; }
        
        public virtual bool IsLockedOut { get; set; }
        
        public virtual DateTime? LastLockedOutDate { get; set; }
        
        public virtual string NewPasswordKey { get; set; }
        
        public virtual DateTime? NewPasswordRequestedDate { get; set; }
        
        public virtual string NewEmailKey { get; set; }

        #endregion

        #region Navigation Properties

        public virtual List<Rol> Roles { get; set; }

        public virtual Address Address { get; set; }

        public virtual List<Discount> Discounts { get; set; }

        #endregion

        public override ValidationResult SelfValidate() {
            return ValidationHelper.Validate<AdvertiserValidator, Advertiser>(this);
        }
    }
}