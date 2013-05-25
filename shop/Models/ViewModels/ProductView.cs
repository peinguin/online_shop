using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Db4objects.Db4o;

using System.Collections;

namespace shop.Models.ViewModels
{
    public class ProductView
    {
        public string Name { get; set; }

        public IObjectSet Categories { get; set; }

        public string Category { get; set; }

        public System.Web.HttpPostedFileWrapper Image { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public List<ProductAttribute> attribute { get; set; }
    }
}