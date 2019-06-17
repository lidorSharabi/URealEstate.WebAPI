using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiURealEstate.App_Data;
using WebApiURealEstate.Models;
using System.Web.Http.Cors;

namespace WebApiURealEstate.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        //[ActionName("createUser")]
        [Route("api/user/createUser")]
        public IHttpActionResult createUser([FromBody]CreateUserRequest newUser)
        {
            DataBaseHandler DBHandler = new DataBaseHandler();
            DBHandler.InsertUser(newUser);

            return Ok(true);
        }

        [HttpPost]
        [Route("api/user/getUserResults")]
        public IHttpActionResult getUserResults([FromBody]CreateUserRequest newUser)
        {
            DataBaseHandler DBHandler = new DataBaseHandler();
            List<Asset> assetsList = DBHandler.GetUserResults(newUser);
            return Ok(assetsList);
        }
    }
}
