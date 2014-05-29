using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DataAccess.Helpers
{
    internal class Database
    {
        internal void CreateDatabase(string connectString)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectString);
                con.Open();
            }
            catch (Exception)
            {
                _connectionString =  @"Server=LOCALHOST\LOCALHOST;Integrated Security=true";
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    var fileContent = File.ReadAllText("Helpers/Script.txt");
                    var sqlqueries = fileContent.Split(new[] {"GO"}, StringSplitOptions.RemoveEmptyEntries);
                    var cmd = new SqlCommand("query");
                    con.Open();
                    foreach (var query in sqlqueries)
                    {
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                    }
                
                }
            }
        }
        private string _connectionString;
    }
}
