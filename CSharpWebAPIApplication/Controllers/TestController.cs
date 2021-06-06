using System.Collections.Generic;
using System.Web.Http;

namespace CSharpWebAPIApplication.Controllers
{
    public class TestController : ApiController
    {
        // GET: api/Test
        public IEnumerable<string> Get()
        {
            //Debug.WriteLine(1234);
            //Debug.WriteLine(this.Request.ToString());
            return new string[] { "value1", "value2" };
        }

        // GET: api/Test/5
        public string Get(string id)
        {
            return "id_" + id;
        }

        // POST: api/Test
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
    }
}
