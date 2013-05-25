using System;
using System.Collections.Generic;

namespace shop.Models
{

    public class ProductAttribute
    {
        public String name { get; set; }
        public String key { get; set; }
    }

    public class Product : Base<Product>
    {
        String _name;
        public String image;
        public String description;
        public List<ProductAttribute> attributes;
        float _price;

        public Product(String name)
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

        public float Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
    }
}
