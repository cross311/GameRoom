using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GameRoom.WebAPI.Controllers
{
    public class GameResultsController : ApiController
    {
        // GET: api/GameResults
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GameResults/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GameResults
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GameResults/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GameResults/5
        public void Delete(int id)
        {
        }
    }
}
