using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CompetencyFrameworkAPI.Models;

namespace CompetencyFrameworkAPI.Controllers
{
    public class JobController : ApiController
    {
        // GET api/values
        public IEnumerable<Job> Get(string id)
        {

            var dataAccess = new DataAccess();
            return dataAccess.GetAllJob(id);
        }
    }
}
