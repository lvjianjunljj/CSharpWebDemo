namespace CSharpWebAPIApplication.Controllers
{
    using CSharpWebAPIApplication.Models;
    using System.Web.Http;
    using System.Web.Http.Controllers;

    public class BaseController : ApiController
    {
        protected Product[] products;
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            products = new Product[]
            {
                new Product { Name = "Tomato Soup", Category = "Groceries", Price = 1 },
                new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
                new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
            };
        }
    }
}
