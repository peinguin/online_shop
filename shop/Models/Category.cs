using System;
using System.Collections.Generic;

namespace shop.Models
{
    public class Category : Base<Category>
    {

        private IList<Product> _products;
        private String _name;

        public Category(String name)
        {
            _products = new List<Product>();
            _name = name;
        }

        public void addProduct(Product product)
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

        public IList<Product> Products
        {
            get
            {
                return _products;
            }
        }
    }
}

