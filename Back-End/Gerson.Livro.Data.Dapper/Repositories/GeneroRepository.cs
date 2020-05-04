using Dapper;
using Gerson.Livro.Data.Dapper.Connection;
using Gerson.Livro.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gerson.Livro.Data.Dapper.Repositories
{
    public class GeneroRepository: IGeneroRepository
    {
       
        private const string QUERY_GENERO = @"
SELECT G.Descricao
FROM dbo.GeneroLivro AS GL
INNER JOIN dbo.Genero AS G ON G.IDGenero = GL.IDGenero
WHERE GL.IDLivro = @IDLivro";

        private const string QUERY_ALL_GENERO = @"
SELECT * FROM dbo.Genero";
        

        private readonly GersonConnectionFactory _masterConnectionFactory;

        public GeneroRepository(GersonConnectionFactory masterConnectionFactory)
        {
            _masterConnectionFactory = masterConnectionFactory;
        }


        public void Delete(int id)
        {
            var query = @"DELETE dbo.Genero WHERE IDGenero = @IDGenero";

            using (var cnn = _masterConnectionFactory.Create())
            {
                cnn.Execute(query, new { IDGenero = id });
            }
        }        
        
        public IEnumerable<dynamic> GetAll()
        {
            using (var cnn = _masterConnectionFactory.Create())
            {
                var generos = cnn.Query<dynamic>(QUERY_ALL_GENERO);
                return generos;
            }
        }       

        public void Insert(dynamic genero)
        {
            var insertQuery = @"INSERT INTO dbo.Genero(IDGenero, Descricao) VALUES (@IDGenero, @Descricao);";
            using (var cnn = _masterConnectionFactory.Create())
            {
                try
                {
                    cnn.Execute(insertQuery, new { genero });
                }
                catch
                {
                    throw new NotImplementedException();
                }
            }
        }

        public void Update(int id, dynamic genero)
        {
            throw new NotImplementedException();
        }
    }
}
