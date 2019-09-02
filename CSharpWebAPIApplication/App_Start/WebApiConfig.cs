namespace CSharpWebAPIApplication
{
    using CSharpWebAPIApplication.Service.Filter;
    using System.Net.Http.Headers;
    using System.Web.Http;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // The best way to change the default schema of return to json.
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Filters setting
            config.Filters.Add(new MyActionFilterAttribute());

            //  Here we just can use the implement class of interface System.Web.Http.Filters.IFilter.
            // But cannot use the implement class of interface System.Web.Mvc.IActionFilter
            //config.Filters.Add(new MyActionFilter());

            //For the default mapping without tag in controller
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
