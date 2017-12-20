using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebGrease.Css.Ast;

namespace CompetencyFrameworkAPI
{
    public class DataAccess
    {

        public List<string> GetAllTechnologies()
        {
            var technologies = new List<string>();


            string connectionString =
                @"data source=PBO-NETSQL04\devstream1; Initial Catalog = Job_Competency_JB_MA; User Id=CompetencyFramework; Password = 1Competency2Framework3";
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


            string connectionString =
                @"data source=PBO-NETSQL04\devstream1; Initial Catalog = Job_Competency_JB_MA; User Id=CompetencyFramework; Password = 1Competency2Framework3";
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


            string connectionString =
                @"data source=PBO-NETSQL04\devstream1; Initial Catalog = Job_Competency_JB_MA; User Id=CompetencyFramework; Password = 1Competency2Framework3";
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


            string connectionString =
                @"data source=PBO-NETSQL04\devstream1; Initial Catalog = Job_Competency_JB_MA; User Id=CompetencyFramework; Password = 1Competency2Framework3";
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

    }
}



