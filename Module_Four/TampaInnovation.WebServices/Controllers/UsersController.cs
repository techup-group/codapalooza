using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TampaInnovation.Models;

namespace TampaInnovation.WebServices.Controllers
{
    [RoutePrefix("users")]
    public class UsersController : ApiController
    {
        [Route("")]
        [HttpPost]
        public IHttpActionResult Register([FromBody] UserRegistration userRegistration)
        {
            if (ModelState.IsValid)
            {
                //TODO: Do something
                return StatusCode(HttpStatusCode.Accepted);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
