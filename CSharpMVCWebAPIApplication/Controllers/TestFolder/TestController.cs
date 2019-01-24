using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CSharpMVCWebAPIApplication.Controllers
{
    /*
     * There is the set of RoutePrefix and Route in the controller, so the url will map the 
     * function with Route set according to the set of RoutePrefix and Route.
     * So the set of config.Routes.MapHttpRoute in WebApiConfig.cs is useless for the function 
     * with Route set.
     * But the url will map the function without Route set according to the set of 
     * config.Routes.MapHttpRoute in WebApiConfig.cs, such as function "GetTest()".
     */
    [RoutePrefix("api/tests")]
    public class TestController : ApiController
    {
        // http://localhost:5014/api/tests/getall
        [Route("getall")]
        public string GetTestsData()
        {
            return "all data";
        }
        // http://localhost:5014/api/test
        public string GetTest()
        {
            return "all...";
        }
        // http://localhost:5014/api/tests/get/1
        [Route("get/{id}")]
        public string GetDataById(int id)
        {
            return "data_" + id;
        }
        // http://localhost:5014/api/tests/get?category=XXXX
        [Route("get")]
        public string GetDataByCategory(string category)
        {
            return "category_" + category;
        }
        // http://localhost:5014/api/tests/get
        [Route("get")]
        public string GetData()
        {
            return "get data";
        }
    }
}
