namespace CSharpMVCWebAPIApplication.Service.Filter
{
    using System.Diagnostics;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    /*
     * We can set the subclass of System.Web.Http.Filters.ActionFilterAttribute as the input of function HttpConfiguration.Filters.Add() in class WebApiConfig to make this filter work.
     * But it cannot be the input of function GlobalFilterCollection.Add() in class FilterConfig that is in the project CSharpMVCWebAPIApplication.

     */
    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        // Function process firstly
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var request = actionContext.Request.ToString();
            Debug.WriteLine("Function OnActionExecuting");
            Debug.WriteLine(request);
            base.OnActionExecuting(actionContext);
        }

        // Function process then
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var request = actionExecutedContext.Request.ToString();
            Debug.WriteLine("Function OnActionExecuted");
            Debug.WriteLine(request);
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}