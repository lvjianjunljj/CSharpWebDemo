namespace CSharpWebAPIApplication472.Controllers
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    [RoutePrefix("api/tests")]
    public class TestController : ApiController
    {
        [Route("")]
        public HttpResponseMessage Get()
        {
            return this.Request.CreateResponse(HttpStatusCode.OK, new string[] { "1", "2" });
        }
    }
}
