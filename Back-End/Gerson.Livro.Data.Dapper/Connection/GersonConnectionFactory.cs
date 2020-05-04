using Microsoft.Extensions.Configuration;

namespace Gerson.Livro.Data.Dapper.Connection
{
    public class GersonConnectionFactory : SqlConnectionFactory
    {
        public GersonConnectionFactory(IConfiguration configuration) : base(configuration["GERSON_CONNECTION_STRING"])
        {
        }
    }
}