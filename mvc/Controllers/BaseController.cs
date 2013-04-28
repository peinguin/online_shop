using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using mvc.Global;
using mvc.Global.Auth;
using mvc.Models;

	namespace mvc.Controllers{
		public abstract class BaseController : Controller
	    {
	        public IRepository Repository { get; set; }

			public CustomAuthentication Auth { get; set; }
			public User CurrentUser
		    {
		        get
		        {
					if (Auth == null)
	                {
	                    Auth = new CustomAuthentication();
	                }
		            return ((UserIndentity)Auth.CurrentUser.Identity).User;
		        }
		    }
	    }
	}
