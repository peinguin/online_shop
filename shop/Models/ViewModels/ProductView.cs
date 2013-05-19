using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Db4objects.Db4o;
namespace shop.Models.ViewModels
{
    public class ProductView
    {
        public string Name { get; set; }

        public IObjectSet Categories { get; set; }

        public string Category { get; set; }
    }
}