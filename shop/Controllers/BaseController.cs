using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using shop.Global;
using shop.Global.Auth;
using shop.Models;
//using Ninject;
namespace shop.Controllers
{
    public abstract class BaseController : Controller
    {
        public IRepository Repository { get; set; }

       // [Inject]
        public CustomAuthentication Auth {
            get{
                return CustomAuthentication.Instance;
            }
            set{
                Auth = value;
            }
        }
        public User CurrentUser
        {
            get
            {
                return ((UserIndentity)Auth.CurrentUser.Identity).User;
            }
        }
    }
}
