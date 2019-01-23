using CSharpWebAPIApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CSharpWebAPIApplication.Controllers
{
    [RoutePrefix("api/productss")]
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        [Route("all/1")]
        public IEnumerable<string> GetProducts()
        {
            string[] res = new string[] { "1", "2" };
            return res;
            //return products;
        }

        [Route("all/2/{id}")]
        public IEnumerable<string> GetProducts(int id)
        {
            string[] res = new string[] { "1", "2", id + "_" };
            return res;
            //return products;
        }

        // http://localhost:8771//api/products
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }
        // http://localhost:8771//api/products/1
        public Product GetProductById(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return product;
        }
        // http://localhost:8771//api/products/?category=Groceries
        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return products.Where(
                (p) => string.Equals(p.Category, category,
                    StringComparison.OrdinalIgnoreCase));
        }
    }
}
