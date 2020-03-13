using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Configuration;

namespace AnubisArchitecture
{
    public class SqlDBHelper
    {
        private const string ANUBIS_CONNECTION_STRING = "Anubis";

        public static void ExecuteSqlQuery(string query)
        {
            string connection = ConfigurationManager.ConnectionStrings["ANUBIS_CONNECTION_STRING"].ConnectionString;

            try
            {

                using (NpgsqlConnection conn = new NpgsqlConnection(connection))
                {
                    conn.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                    

                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        


    }
}
