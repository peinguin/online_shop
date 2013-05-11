﻿using System;

namespace shop.Models
{
    class Product : Base<Product>
    {
        String _name;

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
    }
}
