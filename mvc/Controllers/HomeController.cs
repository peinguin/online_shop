using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

using Db4objects.Db4o;

using System.Web.Script.Serialization;

using Models;

namespace Models{
	public class DB{

		static string _file = "store.db4o";
		private static IObjectContainer _db;

		public static IObjectContainer db
        {
            get
            {
                if (_db == null) {
					_db = Db4oFactory.OpenFile(_file);
				}
				return _db;
            }
        }

		private DB (){}
	}

	class Base<T>{
		public static IObjectSet GetAll(){
			return DB.db.QueryByExample (typeof(Base<T>));
		}

		public void save(){
			DB.db.Store (this);
			DB.db.Commit ();
		}
	}

	class Product : Base<Product>{
		String _name;

		public Product (String name)
		{
			_name = name;
		}

		public string Name
        {
            get
            {
                return _name;
            }
        }
	}

	class Category : Base<Category>{

		private List<Product> _products;
		private String _name;

		public Category (String name)
		{
			_products = new List<Product>();
			_name = name;
		}

		public void addProduct (Product product)
		{
			_products.Add(product);
		}

		public string Name
        {
            get
            {
                return _name;
            }
        }
        
        public List<Product> Products
        {
            get
            {
                return _products;
            }
        }
	}

}

namespace Controllers
{

	public class HomeController : Controller
	{
		public ActionResult Index ()
		{
			return View ();
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


	            foreach(Category c in categories)
					Console.WriteLine(c);


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

