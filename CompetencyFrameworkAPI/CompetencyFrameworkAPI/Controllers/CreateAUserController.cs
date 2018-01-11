using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CompetencyFrameworkAPI.Models;

namespace CompetencyFrameworkAPI.Controllers
{
    public class CreateAUserController : ApiController
    {
        [HttpPost]
        public bool Post(User user)
        { 
            var dataAccess = new DataAccess();
            return dataAccess.AddUser(user);
        }
    }
}
