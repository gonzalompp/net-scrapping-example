using ScrappingExample.Models;
using ScrappingExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ScrappingExample.Controllers
{
    public class ProductsController : ApiController
    {
        // GET api/products
        public IEnumerable<Products> Get()
        {
            return ProductsRepository.GetProductList();
        }
    }
}
