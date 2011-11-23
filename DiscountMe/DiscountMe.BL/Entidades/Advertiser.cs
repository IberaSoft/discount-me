using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace DiscountMe.BL {
    public class Advertiser : EntidadBase {

        #region Primitive Properties

        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string CompanyName { get; set; }

        public string Website { get; set; }

        public string Description { get; set; }

        public string Cif { get; set; }

        public string PrimaryPhone { get; set; }

        public string PrimaryFax { get; set; }

        public string Email { get; set; }

        public string Comment { get; set; }

        public string Password { get; set; }
        
        public string PasswordSalt { get; set; }

        public double Latitude { get; set; }
        
        public double Longitude { get; set; }

        public DateTime CreateDate { get; set; }
        
        public DateTime LastModifiedDate { get; set; }
        
        public DateTime LastLoginDate { get; set; }
        
        public string LastLoginIp { get; set; }
        
        public bool IsActivated { get; set; }
        
        public bool IsLockedOut { get; set; }
        
        public DateTime? LastLockedOutDate { get; set; }
        
        public string NewPasswordKey { get; set; }
        
        public DateTime? NewPasswordRequestedDate { get; set; }
        
        public string NewEmailKey { get; set; }

        #endregion

        #region Navigation Properties

        public Address Address { get; set; }

        public List<Discount> Discounts { get; set; }

        #endregion

        public override ValidationResult SelfValidate() {
            return ValidationHelper.Validate<AdvertiserValidator, Advertiser>(this);
        }
    }
}