﻿using AccountsFunction;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace AccountsWebAuthentication.Helper
{
    public static class WindowsUser
    {
        private static IFUser _iFUser;

        public static bool HasUserRoles(string[] userRoles)
        {
            _iFUser = new FUser();
            return _iFUser.IsMethodAccessible(Username, userRoles.ToList()); ;
        }

        public static int UserID
        {
            get
            {
                _iFUser = new FUser();
                var user = _iFUser.ReadUser(Username);
                int UserID = user?.UserID ?? 0;
                return UserID;
            }
        }

        public static string Username
        {
            get
            {
                WindowsIdentity clientId = (WindowsIdentity)HttpContext.Current.User.Identity;
                return clientId.Name;
            }
        }

    }
}