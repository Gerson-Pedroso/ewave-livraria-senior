using Dapper;
using Gerson.Livro.Data.Dapper.Connection;
using Gerson.Livro.Domain.Data;
using Gerson.Livro.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gerson.Livro.Data.Dapper.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private const string QUERY_LIVRO = @"
SELECT 
	 L.IDLivro
	,L.Titulo
	,L.DataPublicacao
	,L.Paginas
    ,A.IDAutor
	,A.Nome AS Autor
    ,E.IDEditora
	,E.Nome AS Editora
	,L.Descricao
	,L.Sinopse
	,L.Capa
	,G.IDGenero
FROM dbo.Livro AS L 
INNER JOIN dbo.Autor AS A ON A.IDAutor = L.IDAutor
INNER JOIN dbo.Generp AS G ON G.IDGenero = L.IDGenero
INNER JOIN dbo.Editora AS E ON E.IDEditora = L.IDEditora";


        private const string QUERY_GENERO = @"
SELECT G.Descricao
FROM dbo.GeneroLivro AS GL
INNER JOIN dbo.Genero AS G ON G.IDGenero = GL.IDGenero
WHERE GL.IDLivro = @IDLivro";


        private readonly GersonConnectionFactory _masterConnectionFactory;

        public LivroRepository(GersonConnectionFactory masterConnectionFactory)
        {
            _masterConnectionFactory = masterConnectionFactory;
        }


        public void Delete(int id)
        {
            var query = @"DELETE dbo.Livro WHERE IDLivro = @IDLivro";

            using (var cnn = _masterConnectionFactory.Create())
            {
                cnn.Execute(query, new { IDLivro = id });
            }
        }

        public LivroDto Get(int id)
        {
            var queryLivro = $"{QUERY_LIVRO} WHERE L.IDLivro = @IDLivro";

            using (var cnn = _masterConnectionFactory.Create())
            {
                var livro = cnn.QueryFirst<LivroDto>(queryLivro, new { IDLivro = id });
                livro.Generos = cnn.Query<string>(QUERY_GENERO, new { IDLivro = id });
                //livro.LinksCompra = cnn.Query<string>(QUERY_LINKS_COMPRA, new { IDLivro = id });

                return livro;
            }
        }

        public IEnumerable<LivroDto> GetAll()
        {
            using (var cnn = _masterConnectionFactory.Create())
            {
                var livros = cnn.Query<LivroDto>(QUERY_LIVRO);
                return livros;
            }
        }

        public void Insert(LivroDto livro)
        {
            var insertQuery = @"INSERT INTO dbo.Livro(Titulo, DataPublicacao, Paginas, IDAutor, IDEditora, Descricao, Sinopse, Capa, IDGenero) VALUES (@IDLivro, @Titulo, @DataPublicacao, @Paginas, @IDAutor, @IDEditora, @Descricao, @Sinopse, @Capa, @IDGenero)";
            using (var cnn = _masterConnectionFactory.Create())
            {
                try
                {
                    var livros = cnn.Execute(insertQuery, new
                    {
                        Titulo = livro.Autor.ToString(),
                        DataPublicacao = DateTime.Now,
                        Paginas = livro.Paginas,
                        IDAutor = livro.IDAutor,
                        IDEditora = livro.IDEditora,
                        Descricao = livro.Descricao.ToString(),
                        Sinopse = livro.Sinopse.ToString(),
                        Capa = livro.Capa.ToString(),
                        IDGenero = livro.IDGenero
                    });
                }
                catch
                {
                    throw new NotImplementedException();
                }
            }
        }

        public void Update(int id, LivroDto livro)
        {
            var updateQuery = @"UPDATE dbo.Livro SET (Titulo, DataPublicacao, Paginas, IDAutor, IDEditora, Descricao, Sinopse, Capa, IDGenero) = (@IDLivro, @Titulo, @DataPublicacao, @Paginas, @IDAutor, @IDEditora, @Descricao, @Sinopse, @Capa, @IDGenero) WHERE IDLivro = @IDLivro";
            using (var cnn = _masterConnectionFactory.Create())
            {
                try
                {
                    var parameter = new DynamicParameters();
                    //parameter.Add("Nome", autor.Nome.ToString(), DbType.String);
                    var result = cnn.Execute(updateQuery, new
                    {
                        IDLivro = id,
                        Titulo = livro.Titulo.ToString(),
                        DataPublicacao = DateTime.Now,
                        Paginas = livro.Paginas,
                        IDAutor = livro.IDAutor,
                        IDEditora = livro.IDEditora,
                        Descricao = livro.Descricao.ToString(),
                        Sinopse = livro.Sinopse.ToString(),
                        Capa = livro.Capa.ToString(),
                        IDGenero = livro.IDGenero
                    });
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}