using Microsoft.Data.SqlClient;
using System;

namespace Data
{
    public class DBManager
    {
        public string? ConnectionString { get; set; } = null;

        public DBManager(string? connectionString = null)
        {
            this.ConnectionString = connectionString;
        }

        public bool Connect()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                }
                return true;
            }
            catch (SqlException sqlEx)
            {
                throw new Exception(sqlEx.Message);
            }
        }
    }
}
