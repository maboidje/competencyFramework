using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CompetencyFrameworkAPI.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace CompetencyFrameworkAPI.Controllers
{
    public class UserRatingController : ApiController
    {

        public IEnumerable <UserRatingData> Get()
        {

            var dataAccess = new DataAccess();
            return dataAccess.GetAllRatingList();
        }


    }
}
