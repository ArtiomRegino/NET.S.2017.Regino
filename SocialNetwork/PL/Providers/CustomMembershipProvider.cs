using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Interfaces;

namespace PL.Providers
{
    public class CustomMembershipProvider: MembershipProvider
    {
        public IUserService UserService { get; } =
            (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));

        public IRoleService RoleService { get; } =
            (IRoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleService));

        public override bool ValidateUser(string username, string password)
        {
            bool isValid = false;
            var user = UserService.GetUserByUserName(username);
            
            if (user != null && Crypto.VerifyHashedPassword(user.Password, password))
                isValid = true;
                    
            return isValid;
        }

        public MembershipUser CreateUser(string username, string password, string email)
        {
            BllPhoto photo = new BllPhoto();
            BllProfile profile = new BllProfile
                                {
                                    Photo = photo,
                                    UserName = username
                                };
            BllUser user = new BllUser()
                                {
                                  Profile = profile,
                                  UserName = username,
                                  Email = email,
                                  Password = Crypto.HashPassword(password),
                                  RoleId = RoleService.GetAll().FirstOrDefault(r => r.Name == "ActiveUser").Id
                                };
            UserService.Create(user);

            return GetUser(username, true);
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            var user = UserService.GetUserByUserName(username);
            if (user == null) return null;

            var memberUser = new MembershipUser("CustomMembershipProvider",
                                                user.UserName, null, null, null, null,
                                                false, false, DateTime.MinValue,
                                                DateTime.MinValue, DateTime.MinValue,
                                                DateTime.MinValue, DateTime.MinValue);
            return memberUser;
        }

        #region NotImplemented

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion,
            string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion,
            string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordRetrieval { get; }
        public override bool EnablePasswordReset { get; }
        public override bool RequiresQuestionAndAnswer { get; }
        public override string ApplicationName { get; set; }
        public override int MaxInvalidPasswordAttempts { get; }
        public override int PasswordAttemptWindow { get; }
        public override bool RequiresUniqueEmail { get; }
        public override MembershipPasswordFormat PasswordFormat { get; }
        public override int MinRequiredPasswordLength { get; }
        public override int MinRequiredNonAlphanumericCharacters { get; }
        public override string PasswordStrengthRegularExpression { get; }
        
        #endregion
    }
}