using Dapper;
using scale.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scale.Services
{
    public class SqlServerService : IDbService
    {
        private static SqlServerService _instance;
        private static IDbConnection _connection;

        protected SqlServerService()
        {
        }

        public static SqlServerService CreateInstance(string connectionString)
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(connectionString);
                _connection.Open();
            }
            if (_instance == null)
            {
                _instance = new SqlServerService();
            }
            return _instance;
        }

        public IEnumerable<T> Query<T>(string query, object parameters = null) where T : class
        {
            return _connection.Query<T>(query, parameters);
        }

        public int Execute(string query, object parameters = null)
        {
            return _connection.Execute(query, parameters);
        }

        public T QuerySingleOrDefault<T>(string query, object parameters = null)
        {
            return _connection.QuerySingleOrDefault<T>(query, parameters);
        }
    }
}
