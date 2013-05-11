using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shop.Models.ViewModels
{
    public class LoginView
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool isPersistent { get; set; }
    }
}