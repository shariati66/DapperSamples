using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repo
{
    public class DapperDataAccess<T> : IDataAccess<T>
    {
        private readonly IDbConnection _connection;
        public DapperDataAccess(IConfiguration configuration)
        {
            _connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public async Task<List<T>> GetAll(string tableName)
        {
            using (var conn = _connection)
            {
                conn.Open();
                var getTable = await conn.QueryAsync<T>($"SELECT * FROM {tableName}");
                return getTable.ToList();
            }
        }

        public async Task<List<T>> GetByFilter(string tableName, string whereClause)
        {
            using (var conn = _connection)
            {
                conn.Open();
                var getTable = await conn.QueryAsync<T>($"SELECT * FROM {tableName} WHERE {whereClause}");
                return getTable.ToList();
            }
        }
    }
}
