using System;
using System.Collections.Generic;
using CompetencyFrameworkAPI.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompetencyFrameworkAPI.Controllers
{
    public class UserController : ApiController
    {
        public IEnumerable<UserData> Get()
        {

            var dataAccess = new DataAccess();
            return dataAccess.GetAllUsers();
        }


    }
}
