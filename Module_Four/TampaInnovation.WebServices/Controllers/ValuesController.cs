using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TampaInnovation.Business;
using TampaInnovation.Models;

namespace TampaInnovation.WebServices.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public List<string> Get()
        {
            ResourcesServices.TestCall();
            return new List<string>();
        }

        [HttpGet]
        // GET api/values/5
        public string Get(int id)
        {
            return "String";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
