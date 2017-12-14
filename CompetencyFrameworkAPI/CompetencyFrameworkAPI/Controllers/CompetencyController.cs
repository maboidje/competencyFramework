using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CompetencyFrameworkAPI.Models;

namespace CompetencyFrameworkAPI.Controllers
{
    public class CompetencyController : ApiController
    {
        //// GET api/values

        public IEnumerable<Competency> Get(string technologyName, string jobTitle)
        {
            var dataAccess = new DataAccess();
            return dataAccess.GetAllCompetencyList(technologyName, jobTitle);
        }

     

    }
}
