using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSharpMVCWebAPIApplication
{
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
