using System;
using System.Web;
using shop.Models;
using System.Security.Principal;
using System.Web.Security;

namespace shop.Global.Auth
{

    public class CustomAuthentication : IAuthentication
    {
        private static CustomAuthentication instance;

        public static CustomAuthentication Instance
           {
              get 
              {
                 if (instance == null)
                 {
                     instance = new CustomAuthentication();
                 }
                 return instance;
              }
           }

        private CustomAuthentication()
        {
            Repository = new Db4oRepository();
        }
        private const string cookieName = "__AUTH_COOKIE";

        public HttpContext HttpContext { get; set; }

        public IRepository Repository { get; set; }

        #region IAuthentication Members

        public User Login(string userName, string Password, bool isPersistent)
        {
            User retUser = Repository.Login(userName, Password);
            if (retUser != null)
            {
                CreateCookie(userName, isPersistent);
            }
            return retUser;
        }

        public User Login(string userName)
        {
            User retUser = null;//Repository.Users.FirstOrDefault(p => string.Compare(p.Email, userName, true) == 0);
            if (retUser != null)
            {
                CreateCookie(userName);
            }
            return retUser;
        }

        private void CreateCookie(string userName, bool isPersistent = false)
        {
            var ticket = new FormsAuthenticationTicket(
                  1,
                  userName,
                  DateTime.Now,
                  DateTime.Now.Add(FormsAuthentication.Timeout),
                  isPersistent,
                  string.Empty,
                  FormsAuthentication.FormsCookiePath);

            // Encrypt the ticket.
            var encTicket = FormsAuthentication.Encrypt(ticket);

            // Create the cookie.
            var AuthCookie = new HttpCookie(cookieName)
            {
                Value = encTicket,
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout)
            };
            HttpContext.Response.Cookies.Set(AuthCookie);
        }

        public void LogOut()
        {
            var httpCookie = HttpContext.Response.Cookies[cookieName];
            if (httpCookie != null)
            {
                httpCookie.Value = string.Empty;
                _currentUser = new UserProvider(null, null);
            }
        }

        private IPrincipal _currentUser;

        public IPrincipal CurrentUser
        {
            get
            {
                if (_currentUser == null || !_currentUser.Identity.IsAuthenticated)
                {
                    try
                    {
                        HttpCookie authCookie = HttpContext.Request.Cookies.Get(cookieName);
                        if (authCookie != null && !string.IsNullOrEmpty(authCookie.Value))
                        {
                            var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                            _currentUser = new UserProvider(ticket.Name, Repository);
                        }
                        else
                        {
                            _currentUser = new UserProvider(null, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        ex = null;
                        _currentUser = new UserProvider(null, null);
                    }
                }
                return _currentUser;
            }
        }
        #endregion
    }
}