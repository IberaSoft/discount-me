﻿using System.Web.Security;

namespace DiscountMe.Infrastructure {
    // The FormsAuthentication type is sealed and contains static members, so it is difficult to
    // unit test code that calls its members. The interface and helper class below demonstrate
    // how to create an abstract wrapper around such a type in order to make the AccountController
    // code unit testable.

    public interface IMembershipService {
        int MinPasswordLength { get; }
        bool ValidateUser(string userName, string password);
        MembershipCreateStatus CreateUser(CustomMembershipUser usuario);
        bool ChangePassword(string userName, string oldPassword, string newPassword);
    }
}