﻿using System;
using System.Security.Principal;

namespace shop.Global.Auth
{
    public class UserProvider : IPrincipal
    {
        private UserIndentity userIdentity { get; set; }

        #region IPrincipal Members

        public IIdentity Identity
        {
            get
            {
                return userIdentity;
            }
        }

        public bool IsInRole(string role)
        {
            if (userIdentity.User == null)
            {
                return false;
            }
            return userIdentity.User.InRoles(role);
        }

        #endregion


        public UserProvider(string name, IRepository repository)
        {
            userIdentity = new UserIndentity();
            userIdentity.Init(name, repository);
        }


        public override string ToString()
        {
            return userIdentity.Name;
        }
    }
}

