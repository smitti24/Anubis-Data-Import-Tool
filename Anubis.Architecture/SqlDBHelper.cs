using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Npgsql;
using PostgreSQLCopyHelper;

namespace Anubis.Architecture
{
    public class SqlDbHelper
    {
        private const string AnubisConnectionString = "Anubis";
        private static NpgsqlConnection _dbConnection;

        public static string PostgreSqlConnectionString => ConfigurationManager.ConnectionStrings[AnubisConnectionString].ConnectionString;

        public static void ExecuteBatchSqlQuery(string sqlQuery, int totalRows, int completedRowsCount)
        {
            ExecuteSqlQuery(sqlQuery, () =>
            {
                if (completedRowsCount != totalRows) return;

                _dbConnection.Close();
                _dbConnection.Dispose();
            });
        }

        public static void ExecuteSqlQuery(string sqlQuery, Action action = null)
        {
            try
            {
                if (string.IsNullOrEmpty(_dbConnection?.ConnectionString))
                    _dbConnection = new NpgsqlConnection(PostgreSqlConnectionString);

                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(sqlQuery, _dbConnection))
                {
                    command.ExecuteNonQuery();
                }

                if (action != null)
                    action();
                else
                {
                    _dbConnection.Close();
                    _dbConnection.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void BulkWriteToDatabase<TEntity>(IPostgreSQLCopyHelper<TEntity> bulkPostgreSqlCopyHelper, IEnumerable<TEntity> entities)
        {
            using (NpgsqlConnection dbConnection = new NpgsqlConnection(PostgreSqlConnectionString))
            {
                dbConnection.Open();
                bulkPostgreSqlCopyHelper.SaveAll(dbConnection, entities);
            }
        }
    }
}
