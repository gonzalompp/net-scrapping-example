using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScrappingExample.Models
{
    public class Products
    {
        public int ID { get; set; }
        public string BrandName { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantiy { get; set; }
    }
}