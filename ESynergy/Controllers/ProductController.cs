using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ESynergy.Controllers
{
    public class ProductController : ApiController
    {
        [Route("api/products")]
        public IHttpActionResult GetProducts()
        {
            using (var context = new ProductContext())
            {
                var list = context.Products.ToList();

                return Ok(list);
            }
        }
    }
}
