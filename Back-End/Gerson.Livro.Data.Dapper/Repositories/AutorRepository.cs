using Dapper;
using Gerson.Livro.Data.Dapper.Connection;
using Gerson.Livro.Domain.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Gerson.Livro.Data.Dapper.Repositories
{
    public class AutorRepository : IAutorRepository
    {

        private const string QUERY_ALL_AUTOR = @"
SELECT * FROM dbo.Autor";


        private readonly GersonConnectionFactory _masterConnectionFactory;

        public AutorRepository(GersonConnectionFactory masterConnectionFactory)
        {
            _masterConnectionFactory = masterConnectionFactory;
        }


        public void Delete(int id)
        {
            var query = @"DELETE dbo.Autor WHERE IDAutor= @IDAutor";

            using (var cnn = _masterConnectionFactory.Create())
            {
                cnn.Execute(query, new { IDAutor = id });
            }
        }        

        public IEnumerable<dynamic> GetAll()
        {
            using (var cnn = _masterConnectionFactory.Create())
            {
                var autores = cnn.Query<dynamic>(QUERY_ALL_AUTOR);
                return autores;
            }
        }
       
        public void Insert(dynamic autor)
        {
            var insertQuery = @"INSERT INTO dbo.Autor(Nome) VALUES (@Nome)";
            using (var cnn = _masterConnectionFactory.Create())
            {
                try
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("Nome", autor.Nome.ToString(), DbType.String);
                    var result = cnn.Execute(insertQuery, parameter);                    
                }
                catch(Exception ex)
                {
                    throw new NotImplementedException();
                }
            }
        }

        public void Update(int id, dynamic autor)
        {
            var updateQuery = @"UPDATE dbo.Autor SET Nome = @Nome WHERE IDAutor = @IDAutor";
            using (var cnn = _masterConnectionFactory.Create())
            {
                try
                {
                    var parameter = new DynamicParameters();
                    //parameter.Add("Nome", autor.Nome.ToString(), DbType.String);
                    var result = cnn.Execute(updateQuery, new { IDAutor = id, Nome = autor.Nome.ToString()});
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}
