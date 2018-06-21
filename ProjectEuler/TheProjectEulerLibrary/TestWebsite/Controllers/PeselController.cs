using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestWebsite.Models;

namespace TestWebsite.Controllers
{
    [RoutePrefix("Pesel")]
    public class PeselController : ApiController
    {
        [HttpGet]
        [Route("Validate/{pesel}")]
        public IHttpActionResult Validate(string pesel)
        {
            try
            {
                var obj = new Pesel(pesel);
                return this.Ok(true);
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetBirthDateFrom/{pesel}")]
        public IHttpActionResult GetBirthDate(string pesel)
        {
            try
            {
                var obj = new Pesel(pesel);
                return this.Ok(obj.BirthDate);
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }
    }
}
