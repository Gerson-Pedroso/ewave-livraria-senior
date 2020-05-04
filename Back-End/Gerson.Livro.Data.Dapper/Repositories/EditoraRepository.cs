using Dapper;
using Gerson.Livro.Data.Dapper.Connection;
using Gerson.Livro.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gerson.Livro.Data.Dapper.Repositories
{
    public class EditoraRepository: IEditoraRepository
    {

        private const string QUERY_ALL_EDITORA = @"
SELECT * FROM dbo.Editora";

        private readonly GersonConnectionFactory _masterConnectionFactory;

        public EditoraRepository(GersonConnectionFactory masterConnectionFactory)
        {
            _masterConnectionFactory = masterConnectionFactory;
        }


        public void Delete(int id)
        {
            var query = @"DELETE dbo.Editora WHERE IDEditora = @IDEditora";

            using (var cnn = _masterConnectionFactory.Create())
            {
                cnn.Execute(query, new { IDLivro = id });
            }
        }
     
        public IEnumerable<dynamic> GetAll()
        {
            using (var cnn = _masterConnectionFactory.Create())
            {
                var editora = cnn.Query<dynamic>(QUERY_ALL_EDITORA);
                return editora;
            }
        }       

        public void Insert(dynamic editora)
        {
            var insertQuery = @"INSERT INTO dbo.Livro(IDEditora, Nome) VALUES (@IDEditora, @Nome);";
            using (var cnn = _masterConnectionFactory.Create())
            {
                try
                {
                    var livros = cnn.Execute(insertQuery, new { editora });
                }
                catch
                {
                    throw new NotImplementedException();
                }
            }
        }

        public void Update(int id, dynamic editora)
        {
            throw new NotImplementedException();
        }
    }
}
