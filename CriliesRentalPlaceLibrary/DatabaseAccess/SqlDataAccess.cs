using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriliesRentalPlaceLibrary.DatabaseAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public List<T> LoadData<T, U>(string query, U parameters, string connectionStringName, bool isStoredProcedure = false)
        {
            CommandType commandType = isStoredProcedure == true ? CommandType.StoredProcedure : CommandType.Text;

            using (IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionStringName)))
            {
                return connection.Query<T>(query, parameters, commandType: commandType).ToList();
            }
        }

        public void SaveData<T>(string query, T parameters, string connectionStringName, bool isStoredProcedure = false)
        {
            CommandType commandType = isStoredProcedure == true ? CommandType.StoredProcedure : CommandType.Text;

            using (IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionStringName)))
            {
                connection.Execute(query, parameters, commandType: commandType);
            }
        }
    }
}
