using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CompetencyFrameworkAPI.Models;

namespace CompetencyFrameworkAPI
{
    public class DataAccess
    {

        public List<string> GetAllTechnologies()
        {
            var technologies = new List<string>();
            string connectionString = ConfigurationManager.ConnectionStrings["apiDatabase"].ToString();
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ReturnTechnology";
                    command.Connection = connection;
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        technologies.Add(reader.GetString(1));
                    }
                }
            }
            return technologies;
        }

        public List<string> GetAllJobTitle (string technologyName)
        {
            var jobTitle = new List<string>();
            string connectionString = ConfigurationManager.ConnectionStrings["apiDatabase"].ToString();
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ReturnJobTitle";
                    command.Connection = connection;
                    var parameter = new SqlParameter
                    {
                        ParameterName = "technologyName",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 255,
                        Value = technologyName,
                        Direction = ParameterDirection.Input
                    };
                    command.Parameters.Add(parameter);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        jobTitle.Add(reader.GetString(2));
                    }
                }
            }
            return jobTitle;
        }

        public List<Job> GetAllJob(string technologyName)
        {
            var jobTitle = new List<Job>();
            string connectionString = ConfigurationManager.ConnectionStrings["apiDatabase"].ToString();
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ReturnJobTitle";
                    command.Connection = connection;
                    var parameter = new SqlParameter
                    {
                        ParameterName = "technologyName",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 255,
                        Value = technologyName,
                        Direction = ParameterDirection.Input
                    };
                    command.Parameters.Add(parameter);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var job = new Job();
                        job.Title = reader.GetString(2);
                        job.Id = reader.GetInt32(0);

                        jobTitle.Add(job);

                    }
                }
            }
            return jobTitle;
        }

        public List<string> GetAllArea()
        {
            var area = new List<string>();
            string connectionString = ConfigurationManager.ConnectionStrings["apiDatabase"].ToString();
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ReturnArea";
                    command.Connection = connection;
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        area.Add(reader.GetString(1));
                    }
                }
            }
            return area;
        }

        public List<string> GetAllTopics()
        {
            var topics = new List<string>();
            string connectionString = ConfigurationManager.ConnectionStrings["apiDatabase"].ToString();
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ReturnTopics";
                    command.Connection = connection;
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        topics.Add(reader.GetString(1));
                    }
                }
            }
            return topics;
        }
   
        public List<CompetencyFrameworkAPI.Models.UserRatingData> GetAllRatingList()
        {

            var ratingList = new List<UserRatingData>();


            string connectionString = ConfigurationManager.ConnectionStrings["apiDatabase"].ToString();
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ReturnUserRating";
                    command.Connection = connection;


                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var userRatingData = new UserRatingData();
                        userRatingData.RatingID = (reader.GetInt32(0));
                        userRatingData.RatingName = (reader.GetString(1));
                        userRatingData.RatingTypeID = (reader.GetInt32(2));
                        userRatingData.RatingTypeName = (reader.GetString(3));
               
                          
                        ratingList.Add((userRatingData));
                    }
                }
            }
            return ratingList;
        }



        public List<CompetencyFrameworkAPI.Models.Competency> GetAllCompetencyList(string technologyName, string jobTitle)
        {

           var competencyList = new List<Competency>();


            string connectionString = ConfigurationManager.ConnectionStrings["apiDatabase"].ToString();
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ReturnAll";
                    command.Connection = connection;

                    var parameter = new SqlParameter
                    {
                        ParameterName = "technologyName",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 255,
                        Value = technologyName,
                        Direction = ParameterDirection.Input
                    };

                    var technologyParameter = new SqlParameter
                    {
                        ParameterName = "jobTitleName",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 255,
                        Value = jobTitle,
                        Direction = ParameterDirection.Input
                    };

                    command.Parameters.Add(parameter);
                    command.Parameters.Add(technologyParameter);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var competency = new Competency();
                        competency.TopicName = reader.GetString(0);
                        competency.AreaName = reader.GetString(1);
                        competency.CompetencyName = reader.GetString(2);
                        competency.CompetencyID = reader.GetInt32(3);
                        competency.RatingName = reader.GetString(4);
                        competency.RatingTypeName = reader.GetString(5);
                        competency.RatingTypeID = reader.GetInt32(6);
                        competency.RatingID = reader.GetInt32(7);
                        competencyList.Add((competency));
                    }
                }
            }
            return competencyList;
        }


        public List<CompetencyFrameworkAPI.Models.UserData> GetAllUsers()
        {

            var usersList = new List<UserData>();


            string connectionString = ConfigurationManager.ConnectionStrings["apiDatabase"].ToString();
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ReturnUsers";
                    command.Connection = connection;


                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var userData = new UserData();
                        userData.UserID = (reader.GetInt32(0));
                        userData.FirstName = (reader.GetString(1));
                        userData.LastName = (reader.GetString(2));
                        usersList.Add((userData));
                    }
                }
            }
            return usersList;
        }



        public List<CompetencyFrameworkAPI.Models.GetUserRating> GetAllUserInput(int userID)
        {

            var userInputList = new List<GetUserRating>();


            string connectionString = ConfigurationManager.ConnectionStrings["apiDatabase"].ToString();
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ReturnUserInput";
                    command.Connection = connection;

                    var UserIDParameter = new SqlParameter
                    {
                        ParameterName = "UserID",
                        SqlDbType = SqlDbType.Int,
                        Value = userID,
                        Direction = ParameterDirection.Input
                    };


                    command.Parameters.Add(UserIDParameter);
           
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var userInput = new GetUserRating();
                        userInput.RatingName = (reader.GetString(2)); ;
                        userInputList.Add((userInput));
                    }
                }
            }
            return userInputList;
        }

















    }
}