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
    [RoutePrefix("providers")]
    public class ProvidersController : ApiController
    {
        [HttpGet]
        [Route("")]
        public List<ProviderWrapper> Search([FromUri] string query = null, [FromUri] int? range = null, [FromUri] int limit = 20)
        {
            return ResourcesServices.Search(query, range, limit);
        }


        [HttpGet]
        [Route("{providerId}")]
        public IHttpActionResult Get([FromUri] string providerId)
        {
            if (string.IsNullOrEmpty(providerId))
                return BadRequest($"Provider id cannot be null");

            var result = ResourcesServices.Find(providerId);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
