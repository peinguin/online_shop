using System;

namespace shop.Models
{

    public class User : Base<User>
    {
        String _email;
        String _password;

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

        public bool InRoles(string roles)
        {
            if (string.IsNullOrWhiteSpace(roles))
            {
                return false;
            }

            /*var rolesArray = roles.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var role in rolesArray)
            {
                var hasRole = UserRoles.Any(p => string.Compare(p.Role.Code, role, true) == 0);
                if (hasRole)
                {
                    return true;
                }
            }*/
            return false;
        }
    }
}
