using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scale.Helper
{
    class DBConnection
    {
        // connection string
        private const string connectionString = "Server=localhost;Database=sysb;Trusted_Connection=True;";

        // singleton instance
        private static DBConnection _instance;

        // Sql connection 
        protected SqlConnection sqlConnection = new SqlConnection(connectionString);

        protected DBConnection()
        {

        }

        public static DBConnection Instance()
        {
            if(_instance == null)
            {
                _instance = new DBConnection();
            }

            return _instance;
        }
        public SqlConnection connection()
        {
            return _instance.sqlConnection;
        }
    }
}
