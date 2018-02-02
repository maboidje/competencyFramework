using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CompetencyFrameworkAPI.Models;

namespace CompetencyFrameworkAPI.Controllers
{
    public class JobTitleController : ApiController
    {
        //// GET api/values
        public IEnumerable<string> Get(string id)
        {

            var dataAccess = new DataAccess();
            return dataAccess.GetAllJobTitle(id);
        }

        // GET api/values
        //[Route("api/jobtitle/getjobdetails")]
        //public IEnumerable<Job> GetJobDetails(string id)
        //{

        //    var dataAccess = new DataAccess();
        //    return dataAccess.GetAllJob(id);
        //}
    }
}
