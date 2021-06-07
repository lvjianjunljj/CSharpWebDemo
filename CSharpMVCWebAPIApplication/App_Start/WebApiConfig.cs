namespace CSharpMVCWebAPIApplication
{
    using CSharpMVCWebAPIApplication.Service.Filter;
    using System.Web.Http;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            // The default set is for the controller without RoutePrefix or Prefix set.
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            // Filters setting
            config.Filters.Add(new MyActionFilterAttribute());

            //  Here we just can use the implement class of interface System.Web.Http.Filters.IFilter.
            // But cannot use the implement class of interface System.Web.Mvc.IActionFilter
            //config.Filters.Add(new MyActionFilter());

            // Note: We can set filter both here and in the FilterConfig, but what we use in these two plcaes are different. 
            //And they will run for different request, I will do more test on this.


            // For this set, the url "http://localhost:5014/api/products" is mapping the DefaultApi MapHttpRoute
            // not SampleApi. It will not map the SampleApi MapHttpRoute whose id value is null.

            //config.Routes.MapHttpRoute(
            //    name: "SampleApi",
            //    routeTemplate: "api/{id}/{controller}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
