using System;
using System.Collections.Specialized;
using System.Web.Hosting;
using System.Web.Security;
using DiscountMe.Infrastructure.Services;

namespace DiscountMe.Infrastructure {
    public class CustomMembershipRoleProvider : RoleProvider {
        public override void Initialize(string name, NameValueCollection config) {
            if (config == null)
                throw new ArgumentNullException("config");
            if (name.Length == 0)
                name = "CustomMembershipRoleProvider";
            if (String.IsNullOrEmpty(config["description"])) {
                config.Remove("description");
                config.Add("description", "Custom Membership Role Provider");
            }
            base.Initialize(name, config);
            applicationName = GetConfigValue(config["applicationName"], HostingEnvironment.ApplicationVirtualPath);
        }

        public override bool IsUserInRole(string username, string roleName) {
            var user = new RolServiceLayer();
            return user.IsUserInRole(username, roleName);
        }

        public override string[] GetRolesForUser(string username) {
            var user = new RolServiceLayer();
            return user.GetRolesForUser(username);
        }

        public override void CreateRole(string roleName) {
            var user = new RolServiceLayer();
            user.CreateRole(roleName);
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole) {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName) {
            var user = new RolServiceLayer();
            return user.RoleExists(roleName);
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames) {
            var user = new RolServiceLayer();
            user.AddUsersToRoles(usernames, roleNames);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames) {
            var user = new RolServiceLayer();
            user.RemoveUsersFromRoles(usernames, roleNames);
        }

        public override string[] GetUsersInRole(string roleName) {
            var user = new RolServiceLayer();
            return user.GetUsersInRole(roleName);
        }

        public override string[] GetAllRoles() {
            var user = new RolServiceLayer();
            return user.GetAllRoles();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch) {
            var user = new RolServiceLayer();
            return user.FindUsersInRole(roleName, usernameToMatch);
        }

        public override string ApplicationName {
            get { return applicationName; }
            set { applicationName = value; }
        }

        private string applicationName;

        private string GetConfigValue(string configValue, string defaultValue) {
            return string.IsNullOrEmpty(configValue) ? defaultValue : configValue;
        }
    }
}