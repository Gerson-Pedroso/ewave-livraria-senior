using Gerson.Livro.Application.Data;
using System.Data;
using System.Data.SqlClient;

namespace Gerson.Livro.Data.Dapper.Connection
{
    public abstract class SqlConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection Create()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
