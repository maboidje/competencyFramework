using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompetencyFrameworkAPI.Controllers
{
    public class TopicsController : ApiController
    {
        public IEnumerable<string> Get()
        {

            var dataAccess = new DataAccess();
            return dataAccess.GetAllTopics();
        }


    }
}
