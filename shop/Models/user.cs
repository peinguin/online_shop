using System;
using System.Collections.Generic;

namespace shop.Models
{

    public class User : Base<User>
    {
        String _email;
        String _password;
        public List<string> roles = new List<string>();

        public User(String email, String password)
        {
            _email = email;
            _password = password;
        }

        public string Email
        {
            get
            {
                return _email;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
        }

        public bool InRoles(string rls)
        {
            if (string.IsNullOrWhiteSpace(rls))
            {
                return false;
            }

            if (roles.Contains(rls))
                return true;
            else
                return false;

            
            return false;
        }
    }
}
