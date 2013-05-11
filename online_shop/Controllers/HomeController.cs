
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Db4objects.Db4o;
using System.Web.Script.Serialization;
using mvc.Models;

namespace mvc.Controllers
{

	public class HomeController : BaseController
	{
		public ActionResult Index ()
		{
			return View ();
		}

		public ActionResult UserLogin()
        {

            return View(CurrentUser);
        }

		public ActionResult Add (String Name)
		{
			Category c = new Category(Name);
			c.save();
			return RedirectToAction ("Get");
		}

		public ActionResult Get ()
		{
			IObjectSet categories = Category.GetAll();
				var jsonSerialiser = new JavaScriptSerializer();
				var json = jsonSerialiser.Serialize(categories);
		
	         		return Content(json);  
		}

		public ActionResult Getall(){

			IObjectSet categories = Category.GetAll();


	            foreach(Category c in categories)
					Console.WriteLine(c);


				var jsonSerialiser = new JavaScriptSerializer();
				var json = jsonSerialiser.Serialize(categories);
		
	         		return Content(json);
		}

		public ActionResult CreateTst(){
			Category cat1 = new Category("cat1");
			Category cat2 = new Category("cat2");
			Category cat3 = new Category("cat3");

			Product product1 = new Product("prod1");
			Product product2 = new Product("prod2");
			Product product3 = new Product("prod3");

			cat1.addProduct(product1);
			cat2.addProduct(product2);
			cat2.addProduct(product3);

			cat1.save();
			cat2.save();
			cat3.save();

			return RedirectToAction ("Index");
		}
	}
}