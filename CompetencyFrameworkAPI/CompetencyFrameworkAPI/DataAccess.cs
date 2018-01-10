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

        public List<string> GetAllJobTitle(string technologyName)
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

        public List<Competency> GetAllCompetencyList(string technologyName, string jobTitle)
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
                        competency.RatingName = reader.GetString(3);
                        competencyList.Add((competency));
                    }
                }
            }
            return competencyList;
        }

        public bool AddUser(User user)
        {
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

                    var firstNameParameter = new SqlParameter
                    {
                        ParameterName = "FirstName",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 25,
                        Value = user.FirstName,
                        Direction = ParameterDirection.Input
                    };

                    var lastNameParameter = new SqlParameter
                    {
                        ParameterName = "LastName",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 25,
                        Value = user.LastName,
                        Direction = ParameterDirection.Input
                    };

                    var emailAddressParameter = new SqlParameter
                    {
                         ParameterName = "EmailAddress",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        Value = user.EmailAddress,
                        Direction = ParameterDirection.Input
                    };

                    var jobTitleIdParameter = new SqlParameter
                    {
                        ParameterName = "JobTitleID",
                        SqlDbType = SqlDbType.Int,
                        Value = user.JobTitleId,
                        Direction = ParameterDirection.Input
                    };

                    var alreadyExistParameter = new SqlParameter
                    {
                        ParameterName = "AlreadyExists",
                        SqlDbType = SqlDbType.Bit,
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(firstNameParameter);
                    command.Parameters.Add(lastNameParameter);
                    command.Parameters.Add(emailAddressParameter);
                    command.Parameters.Add(jobTitleIdParameter);
                    command.Parameters.Add(alreadyExistParameter);
                    command.ExecuteNonQuery();
                    return (bool)alreadyExistParameter.Value;
                }
            }
        }

    }
}