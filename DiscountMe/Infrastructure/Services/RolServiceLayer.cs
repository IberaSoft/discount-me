using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using DiscountMe.BL;
using DiscountMe.DAL;

#region Role Provider

namespace DiscountMe.Infrastructure.Services {
    public class RolServiceLayer : IRolService {
        private readonly IUnitOfWork uow;

        public RolServiceLayer() : this(DependencyResolver.Current.GetService<IUnitOfWork>()) {
        }

        private RolServiceLayer(IUnitOfWork unitOfWork) {
            uow = unitOfWork;
        }

        public bool Enabled {
            get { return Roles.Enabled; }
        }

        public bool IsUserInRole(string username, string roleName) {
            var user = uow.Users.Consulta(u => u.UserName.Equals(username) || u.Email.Equals(username)).FirstOrDefault();
            if (user != null) {
                var roles = from ur in user.Roles
                            from r in uow.Roles.Lista()
                            where ur.Id == r.Id
                            select r.RoleName;
                return roles.Any(r => r.Equals(roleName));
            }
            var advertiser = uow.Advertisers.Consulta(u => u.UserName.Equals(username) || u.Email.Equals(username)).FirstOrDefault();
            if (advertiser != null) {
                var roles = from ur in advertiser.Roles
                            from r in uow.Roles.Lista()
                            where ur.Id == r.Id
                            select r.RoleName;
                return roles.Any(r => r.Equals(roleName));
            }
            return false;
        }

        public string[] GetRolesForUser(string username) {
            var user = uow.Users.Consulta(u => u.UserName.Equals(username) || u.Email.Equals(username)).FirstOrDefault();
            if (user != null) {
                var roles = user.Roles.SelectMany(ur => uow.Roles.Lista(), (ur, r) => new { ur, r })
                    .Where(t => t.ur.Id == t.r.Id).Select(t => t.r.RoleName);
                return roles.ToArray();
            }
            var advertiser = uow.Advertisers.Consulta(u => u.UserName.Equals(username) || u.Email.Equals(username)).FirstOrDefault();
            if (advertiser != null) {
                var roles = advertiser.Roles.SelectMany(ur => uow.Roles.Lista(), (ur, r) => new { ur, r })
                    .Where(t => t.ur.Id == t.r.Id).Select(t => t.r.RoleName);
                return roles.ToArray();
            }
            return new string[] { };
        }

        public string[] GetUsersInRole(string roleName) {
            var rol = uow.Roles.Consulta(r => r.RoleName.Equals(roleName)).SingleOrDefault();
            if (rol != null) {
                var users = from ru in rol.Users
                            from r in uow.Users.Lista()
                            where ru.Id == r.Id
                            select r.UserName;
                return users.ToArray();
            }
            rol = uow.Roles.Consulta(r => r.RoleName.Equals(roleName)).FirstOrDefault();
            if (rol != null) {
                var advertisers = from ru in rol.Advertisers
                                  from r in uow.Advertisers.Lista()
                                  where ru.Id == r.Id
                                  select r.UserName;
                return advertisers.ToArray();
            }
            return new string[] { };
        }

        public bool RoleExists(string roleName) {
            var rol = uow.Roles.Consulta(r => r.RoleName.Equals(roleName)).FirstOrDefault();
            return rol != null;
        }

        public void AddUsersToRoles(string[] usernames, string[] roleNames) {
            foreach (var username in usernames) {
                var user = uow.Users.Consulta(u => u.UserName.Equals(username) || u.Email.Equals(username)).SingleOrDefault();
                foreach (var roleName in roleNames) {
                    if (RoleExists(roleName) && user != null && (user.Roles == null || !IsUserInRole(user.UserName, roleName))) {
                        var rol = uow.Roles.Consulta(r => r.RoleName.Equals(roleName)).FirstOrDefault();
                        if (user.Roles == null)
                            user.Roles = new List<Rol>();
                        user.Roles.Add(rol);
                        rol.Users.Add(user);
                        uow.SaveChanges();
                        return;
                    }
                }
            }
            foreach (var username in usernames) {
                var user = uow.Advertisers.Consulta(u => u.UserName.Equals(username) || u.Email.Equals(username)).SingleOrDefault();
                foreach (var roleName in roleNames) {
                    if (RoleExists(roleName) && user != null && (user.Roles == null || !IsUserInRole(user.UserName, roleName))) {
                        var rol = uow.Roles.Consulta(r => r.RoleName.Equals(roleName)).FirstOrDefault();
                        if (user.Roles == null)
                            user.Roles = new List<Rol>();
                        user.Roles.Add(rol);
                        rol.Advertisers.Add(user);
                        uow.SaveChanges();
                        return;
                    }
                }
            }
        }

        public void RemoveUsersFromRoles(string[] usernames, string[] roleNames) {
            foreach (var username in usernames) {
                var user = uow.Users.Consulta(u => u.UserName.Equals(username) || u.Email.Equals(username)).FirstOrDefault();
                foreach (var roleName in roleNames) {
                    if (RoleExists(roleName) && !IsUserInRole(user.UserName, roleName)) {
                        var rol = uow.Roles.Consulta(r => r.RoleName.Equals(roleName)).FirstOrDefault();
                        user.Roles.Remove(rol);
                        rol.Users.Remove(user);
                        uow.SaveChanges();
                    }
                }
            }
        }

        public string[] GetAllRoles() {
            return uow.Roles.Lista().Select(r => r.RoleName).ToArray();
        }

        public string[] FindUsersInRole(string roleName, string usernameToMatch) {
            var rol = uow.Roles.Consulta(r => r.RoleName.Equals(roleName)).FirstOrDefault();
            if (rol != null) {
                var users = from ru in rol.Users
                            from r in uow.Users.Lista()
                            where ru.Id == r.Id && r.UserName == usernameToMatch
                            select r.UserName;
                return users.ToArray();
            }
            return new string[] { };
        }

        public void CreateRole(string roleName) {
            var rol = new Rol { RoleName = roleName };
            uow.Roles.Agregar(rol);
            uow.SaveChanges();
        }

#endregion
    }
}