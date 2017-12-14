using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace CompetencyFrameworkAPI.Models
{
    public class Competency
    {
        public string TopicName { get; set; }
        public string AreaName { get; set; }
        public string CompetencyName { get; set; }
        public string RatingName { get; set; }
    }
}