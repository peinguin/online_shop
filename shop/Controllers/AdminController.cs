using System;
using System.Web.Mvc;
using shop.Models;
using Db4objects.Db4o;
using shop.Models.ViewModels;
using System.Collections.Generic;
namespace shop.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : BaseController
    {

        public ActionResult Categories()
        {
            var categories = new List<Category>();
            foreach (Category p in DB.db.QueryByExample(typeof(Category)))
            {
                categories.Add(p);
            }
            return View(categories);
        }

        public ActionResult Products()
        {
            var products = new List<Product>();
            foreach(Product p in DB.db.QueryByExample(typeof(Product))){
                products.Add(p);
            }

            return View(products);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(CategoryView categoryView)
        {
            if (ModelState.IsValid)
            {
                IObjectSet categories = DB.db.QueryByExample(new shop.Models.Category(categoryView.Name));
                if (categories.Count == 0)
                {
                    Category category = new Category(categoryView.Name);
                    DB.db.Store(category);
                    return RedirectToAction("Categories", "Admin");
                }
                ModelState["Name"].Errors.Add("Category is exist");
            }
            return View(categoryView);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            ProductView productView = new ProductView();
            productView.Categories = Category.GetAll();
            return View(productView);
        }
        [HttpPost]
        public ActionResult AddProduct(ProductView productView)
        {
            IObjectSet categories = DB.db.QueryByExample(new shop.Models.Category(productView.Category));
            if (categories.Count > 0) {
                Product product = new Product(productView.Name);
                DB.db.Store(product);
                Category category = (Category)categories.Next();
                category.addProduct(product);
                DB.db.Store(category);
                return RedirectToAction("Products", "Admin");
            }
            ModelState["Category"].Errors.Add("Category not found");
            return View(productView);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
