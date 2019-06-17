using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiURealEstate.App_Data;

namespace WebApiURealEstate.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class DataController : ApiController
    {
        // GET api/data
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/data/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/data
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

        [HttpGet]
        [Route("api/data/get_locations")]
        public List<string> GetLocations()
        {
            DataBaseHandler DBHandler = new DataBaseHandler();
            return DBHandler.GetLocations();
        }
    }
}
