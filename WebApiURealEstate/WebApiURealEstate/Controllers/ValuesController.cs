using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiURealEstate.App_Data;

namespace WebApiURealEstate.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
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

        [HttpGet]
        [Route("api/values/lidor")]
        public bool lidor()
        {
            DataBaseHandler DBHandler = new DataBaseHandler();
            //DBHandler.InsertUser();

            return true;
        }


        //[HttpPost]
        //[ActionName("createUser")]
        ////[Route("api/values/createUser")]
        //public IHttpActionResult createUser([FromBody]CreateUserRequest newUser)
        //{
        //    DataBaseHandler DBHandler = new DataBaseHandler();
        //    DBHandler.InsertUser(newUser);

        //    return Ok(true);
        //}
    }
}
