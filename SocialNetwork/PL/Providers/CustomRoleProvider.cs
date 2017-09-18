using System;
using System.Linq;
using System.Web.Security;
using BLL.Interface.Entities;
using BLL.Interfaces.Interfaces;

namespace PL.Providers
{
    public class CustomRoleProvider: RoleProvider
    {
        public IRoleService RoleService { get; } =
            (IRoleService) System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleService));

        public IUserService UserService { get; } =
            (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));

        public override bool IsUserInRole(string username, string roleName)
        {
            bool outputResult = false;

            var user = UserService.GetUserByUserName(username);
            if (user == null) return false;
            var userRole = RoleService.GetAll().FirstOrDefault(r => r.Name == roleName);
            if (userRole != null)
                outputResult = true;

            return outputResult;
        }

        public override string[] GetRolesForUser(string username)
        {
            var role = new string[] { };
            var user = UserService.GetUserByUserName(username);
            if (user == null)
                return role;

            var userRole = RoleService.GetAll().FirstOrDefault(r => r.Id == user.RoleId);
            if (userRole != null)
                role = new[] { userRole.Name };

            return role;
        }

        public override void CreateRole(string roleName)
        {
            RoleService.Create(new BllRole {Name = roleName});
        }

        #region NotImplemented

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }

        #endregion
    }
}