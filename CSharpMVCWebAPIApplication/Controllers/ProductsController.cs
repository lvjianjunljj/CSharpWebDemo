using CSharpMVCWebAPIApplication.Service.Azure;
using CSharpMVCWebAPIApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CSharpMVCWebAPIApplication.DAO.Azure;

namespace CSharpMVCWebAPIApplication.Controllers
{
    /*
     * There is not the set of RoutePrefix and Route, so the url will map the function according to the 
     * set of config.Routes.MapHttpRoute in WebApiConfig.cs. 
     * The mapping is according to the Input variable name, and function name has no effect on the mapping.
     */

    public class ProductsController : ApiController
    {
        // Simulation to get data from the database.
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        // Url "http://localhost:5014/api/products" map this function, because the url without other parameter
        // map the function that has no input.
        public IEnumerable<Product> GetProducts()
        {
            return products;
        }
        // Url "http://localhost:5014/api/products/1" map this function, because the input name of this 
        // function is "id", and the default routeTemplate is "api/{controller}/{id}" in WebApiConfig.cs.
        public Product GetProductsById(int id)
        {
            string appendString;
            try
            {
                appendString = AzureKeyVault.GetSecret("csharpmvcwebapikeyvault", "AppSecret");
            }
            catch (Exception e)
            {
                appendString = $"Getting appendString throw Exception: {e.Message}";
            }
            List<string> appendLineList = AzureSQLDatabase.GetAllData();
            var product = products.FirstOrDefault((p) => p.Id == id);
            product.Name += $" :{appendString}";
            foreach (string appendLine in appendLineList)
            {
                product.Name += appendLine;
            }
            //if (product == null)
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}
            return product;
        }
        // Url "http://localhost:5014/api/products?name=Hammer" map this function, because the input 
        // name of this function is "name".
        public IEnumerable<Product> GetProductsByName(string name)
        {
            return products.Where(
                (p) => string.Equals(p.Name, name,
                    StringComparison.OrdinalIgnoreCase));
        }
        // Url "http://localhost:5014/api/products?category=Hardware" map this function, because the input 
        // name of this function is "category".
        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return products.Where(
                (p) => string.Equals(p.Category, category,
                    StringComparison.OrdinalIgnoreCase));
        }
    }
}
