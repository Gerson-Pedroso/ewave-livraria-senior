using Microsoft.Extensions.Configuration;

namespace Gerson.Livro.Data.Dapper.Connection
{
    public class MasterConnectionFactory : SqlConnectionFactory
    {
        public MasterConnectionFactory(IConfiguration configuration) : base(configuration["MASTER_CONNECTION_STRING"])
        {
        }
    }
}