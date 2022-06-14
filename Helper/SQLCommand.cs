using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// debugging
using System.Diagnostics;
//
using scale.Model;

namespace scale.Helper
{
    // DAL: Data Access Layer
    class SQLCommand
    {
        // connection string
        public const string connectionString = "Data Source=DESKTOP-3OJQK0E;Initial Catalog=DBCanDa;Integrated Security=True";
        public static int executeInsert(string query, ref DBConnection connection)
        {
            // Initialization.  
            SqlCommand sqlCommand = new SqlCommand();
            int rowCount;

            try
            {
                // Settings.  
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = connection.connection();
                sqlCommand.CommandTimeout = 10; //// Setting timeeout 10s. 

                // Open.  
                connection.connection().Open();

                // Result.  
                rowCount = sqlCommand.ExecuteNonQuery();

                // Close.  
                connection.connection().Close();
            }
            catch (Exception ex)
            {
                // Close.  
                connection.connection().Close();

                throw ex;
            }

            return rowCount;
        }

        public static SqlDataReader executeSelect(string query, ref DBConnection connection)
        {
            // Initialization.  
            SqlCommand sqlCommand = new SqlCommand();

            SqlDataReader reader;
            try
            {
                // Settings.  
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = connection.connection();
                sqlCommand.CommandTimeout = 10; //// Setting timeeout 10s. 

                // Open.  
                connection.connection().Open();

                // Result.  
                reader = sqlCommand.ExecuteReader();

                // Close.  
                //connection.connection().Close();
            }
            catch (Exception ex)
            {
                // Close.  
                connection.connection().Close();

                throw ex;
            }

            return reader;
        }
    }
}
