namespace CSharpWebAPIApplication
{
    using System.Diagnostics;
    using System.Web;
    using System.Web.Http;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //GlobalConfiguration.Configure(ActionFilter)
            // The default return schema is xml, so need to update the configuration.
            // The default order is xml->json->download.

            //GlobalConfiguration.Configuration.Formatters.Clear();
            //GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());

            //GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            ////GlobalConfiguration.Configuration.Formatters.JsonFormatter.SupportedMediaTypes.Clear();
        }

        /// <summary>
        /// Receive all the request
        /// </summary>
        protected void Application_BeginRequest()
        {
            // Intercept request
            //string[] segments = Request.Url.Segments;
            var requestURL = Request.Url;
            var requestMethod = Request.HttpMethod;
            var requestStream = Request.InputStream;


            Debug.WriteLine($"requestURL: '{requestURL}'");
            Debug.WriteLine($"requestMethod: '{requestMethod}'");

            //StreamReader sr = new StreamReader(requestStream, Encoding.UTF8);
            //string line;
            //while ((line = sr.ReadLine()) != null)
            //{
            //    Debug.WriteLine(line);
            //}
            //sr.Close();
        }
    }
}
