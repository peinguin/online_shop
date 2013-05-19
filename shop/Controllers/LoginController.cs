using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shop.Models.ViewModels;
using shop.Global.Auth;

namespace shop.Controllers
{
    public class LoginController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new LoginView());
        }

        [HttpPost]
        public ActionResult Index(LoginView loginView)
        {
            if (ModelState.IsValid)
            {
                Auth = CustomAuthentication.Instance;
                var user = Auth.Login(loginView.Email, loginView.Password, loginView.isPersistent);
                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState["Password"].Errors.Add("Пароли не совпадают");
            }
            return View(loginView);
        }

        public ActionResult Logout()
        {
            Auth.LogOut();
            return RedirectToAction("Index", "Home");
        }
    }

}
