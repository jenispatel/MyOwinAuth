using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace MyOwinAuth.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [Authorize(Roles = "admins")]
        public IEnumerable<string> Get()
        {

            //username
            var b = HttpContext.Current.User.Identity.Name;
            IEnumerable<Claim> claims = ((System.Security.Claims.ClaimsPrincipal)HttpContext.Current.User).Claims;
            //// or
            var a = claims.Where(x => x.Type == "Age").FirstOrDefault().Value;
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
