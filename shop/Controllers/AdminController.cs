using System;
using System.Web.Mvc;
using shop.Models;
using Db4objects.Db4o;
using shop.Models.ViewModels;
using System.Collections.Generic;

using System.IO;


namespace shop.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : BaseController
    {

        public ActionResult Categories()
        {
            var categories = new List<Category>();
            IObjectSet results = Category.GetAll();
            foreach (Category p in results)
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
            return View(new CategoryView());
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
            if (ModelState.IsValid)
            {
                IObjectSet categories = DB.db.QueryByExample(new shop.Models.Category(productView.Category));

                var valid = true;

                if (categories.Count == 0)
                {
                    valid = false;
                    ModelState.AddModelError("Category", "Category is required.");
                }

                if (productView.Image == null)
                {
                    ModelState.AddModelError("Image", "Image must be");
                }
                else
                {
                    if (productView.Image.ContentType != "image/jpeg")
                    {
                        valid = false;
                        ModelState.AddModelError("Image", "Image must be i jpeg picture");
                    }
                    else
                    {
                        var name = Path.GetFileName(productView.Image.FileName);

                        var fileName = Path.GetFileNameWithoutExtension(name);
                        var extension = Path.GetExtension(name);
                        var i = 0;

                        var path = Path.Combine(Server.MapPath("~/Content/products"), fileName + extension);

                        while (System.IO.File.Exists(path))
                        {
                            ++i;
                            path = Path.Combine(Server.MapPath("~/Content/products"), fileName + i + extension);
                        }
                        productView.Image.SaveAs(path);
                    }
                }

                if (productView.Price == null || productView.Price <= 0)
                {
                    valid = false;
                    ModelState.AddModelError("Price", "Price must be greather by 0");
                }

                var itemToRemove = Request.Form["attribute"];
                if (valid)
                {
                    Category category = (Category)categories.Next();
                    Product product = new Product(productView.Name);

                    product.attributes = productView.attribute;
                    product.Price = productView.Price;
                    category.addProduct(product);
                    DB.db.Store(category.Products);

                    return RedirectToAction("Products", "Admin");
                }
            }
            productView.Categories = Category.GetAll();
            return View(productView);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
