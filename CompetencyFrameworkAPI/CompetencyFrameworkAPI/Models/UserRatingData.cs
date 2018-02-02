using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace CompetencyFrameworkAPI.Models
{
    public class UserRatingData
    {
        public int RatingID { get; set; }
        public string RatingName { get; set; }
        public int RatingTypeID { get; set; }
        public string RatingTypeName { get; set; }
    }
}