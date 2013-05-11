using System;
using System.Collections.Generic;

namespace shop.Models
{
    class Category : Base<Category>
    {

        private List<Product> _products;
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

        public List<Product> Products
        {
            get
            {
                return _products;
            }
        }
    }
}

