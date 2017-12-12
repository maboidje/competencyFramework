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
            var technologies = new List<string> ();
            

            string connectionString = @"data source=PBO-NETSQL04\devstream1; Initial Catalog = Job_Competency_JB_MA; User Id=CompetencyFramework; Password = 1Competency2Framework3";
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
    }
}