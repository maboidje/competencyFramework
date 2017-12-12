using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompetencyFrameworkAPI.Controllers
{
    public class JobTitleController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get(string id)
        {

            var dataAccess = new DataAccess();
            return dataAccess.GetAllJobTitle(id);
        }
    }
}
