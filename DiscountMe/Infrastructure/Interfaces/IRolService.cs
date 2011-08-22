namespace DiscountMe.Infrastructure.Services {
    public interface IRolService {
        bool Enabled { get; }
        bool IsUserInRole(string username, string roleName);
        string[] GetRolesForUser(string username);
        string[] GetUsersInRole(string roleName);
        bool RoleExists(string roleName);
        void AddUsersToRoles(string[] usernames, string[] roleNames);
        void RemoveUsersFromRoles(string[] usernames, string[] roleNames);
        string[] GetAllRoles();
        string[] FindUsersInRole(string roleName, string usernameToMatch);
        void CreateRole(string roleName);
    }
}