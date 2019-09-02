namespace CSharpMVCWebAPIApplication.Service.Filter
{
    using System.Diagnostics;
    using System.Web.Mvc;

    public class MyActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Debug.WriteLine("OnActionExecuted Function!!!");
            var values = filterContext.RouteData.Values;
            foreach (var item in values)
            {
                Debug.WriteLine($"{item.Key}\t{item.Value}");
            }

            //throw new System.NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debug.WriteLine("OnActionExecuting Function!!!");
            var values = filterContext.RouteData.Values;
            foreach (var item in values)
            {
                Debug.WriteLine($"{item.Key}\t{item.Value}");
            }

            //throw new System.NotImplementedException();
        }
    }
}