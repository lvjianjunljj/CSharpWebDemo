using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CSharpMVCWebAPIApplication.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {

        public string GetTestsData()
        {
            return "all data";
        }
        [Route("get/{id}")]
        public string GetDataById(int id)
        {
            return "data_" + id;
        }
        [Route("get/{id}")]
        public string GetDataByCategory(string category)
        {
            return "category_" + category;
        }
    }
}
