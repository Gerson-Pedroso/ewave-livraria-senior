using System.Data;

namespace Gerson.Livro.Application.Data
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
    }
}
