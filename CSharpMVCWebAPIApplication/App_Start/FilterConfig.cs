namespace CSharpMVCWebAPIApplication
{
    using CSharpMVCWebAPIApplication.Service.Filter;
    using System.Diagnostics;
    using System.Web.Mvc;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            // We cannot use the subclass of System.Web.Http.Filters.ActionFilterAttribute here.
            //filters.Add(new MyActionFilterAttribute());
            filters.Add(new MyActionFilter());
        }
    }
}
