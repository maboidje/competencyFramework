using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CompetencyFrameworkAPI.Models;

namespace CompetencyFrameworkAPI.Controllers
{
    public class GetUserRatingController : ApiController
    {

        public IEnumerable<GetUserRating> Get(int UserID)
        {
            var dataAccess = new DataAccess();
            return dataAccess.GetAllUserInput(UserID);
        }
    }
}

