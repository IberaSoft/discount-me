using System;
using System.Web.Security;
using DiscountMe.BL;

namespace DiscountMe.Infrastructure {
    public class CustomMembershipUser : MembershipUser {
        public CustomMembershipUser(
        string providerName,
        string name,
        object providerUserKey,
        string email,
        string passwordQuestion,
        string comment,
        bool isApproved,
        bool isLockedOut,
        DateTime creationDate,
        DateTime lastLoginDate,
        DateTime lastActivityDate,
        DateTime lastPasswordChangedDate,
        DateTime lastLockoutDate
        )
            : base(providerName, name, providerUserKey, email, passwordQuestion,
            comment, isApproved, isLockedOut, creationDate, lastLoginDate,
            lastActivityDate, lastPasswordChangedDate, lastLockoutDate) {
        }

        public User User { get; set; }
        public Advertiser Advertiser { get; set; }
    }
}