USE master;

INSERT INTO [dbo].[Editora] ( Nome ) VALUES ('Cortez Editora')
INSERT INTO [dbo].[Editora] ( Nome ) VALUES ('Coletivo Editorial')
INSERT INTO [dbo].[Editora] ( Nome ) VALUES ('Editora Vozes')
INSERT INTO [dbo].[Editora] ( Nome ) VALUES ('Editora Record')
INSERT INTO [dbo].[Editora] ( Nome ) VALUES ('Panda Books')
INSERT INTO [dbo].[Editora] ( Nome ) VALUES ('Qualis')
INSERT INTO [dbo].[Editora] ( Nome ) VALUES ('Illuminare')
INSERT INTO [dbo].[Editora] ( Nome ) VALUES ('Vivaluz Editora')

INSERT INTO [dbo].[Autor] ( [Nome] ) VALUES ('Machado de Assis' )
INSERT INTO [dbo].[Autor] ( [Nome] ) VALUES ('Clarice Lispector' )
INSERT INTO [dbo].[Autor] ( [Nome] ) VALUES ('Carlos Drummond de Andrade' )
INSERT INTO [dbo].[Autor] ( [Nome] ) VALUES ('Guimarães Rosa' )
INSERT INTO [dbo].[Autor] ( [Nome] ) VALUES ('Jorge Amado' )
INSERT INTO [dbo].[Autor] ( [Nome] ) VALUES ('José de Alencar' )
INSERT INTO [dbo].[Autor] ( [Nome] ) VALUES ('Mário de Andrade' )


INSERT INTO [dbo].Genero ( Descricao ) VALUES ('Autobiografia' )
INSERT INTO [dbo].Genero ( Descricao ) VALUES ('Fantasia ' )
INSERT INTO [dbo].Genero ( Descricao ) VALUES ('Horror' )
INSERT INTO [dbo].Genero ( Descricao ) VALUES ('Comédia' )
INSERT INTO [dbo].Genero ( Descricao ) VALUES ('Romance' )
INSERT INTO [dbo].Genero ( Descricao ) VALUES ('Suspense' )
INSERT INTO [dbo].Genero ( Descricao ) VALUES ('Guerra' )
INSERT INTO [dbo].Genero ( Descricao ) VALUES ('Auto-ajuda' )


INSERT INTO dbo.Livro
(
    Titulo,
    DataPublicacao,
    Paginas,
    IDAutor,
    IDEditora,
	IDGenero,
    Descricao,
    Sinopse,
    Capa
)
VALUES
(   'Livro 1 ', 
    GETDATE(),
    100,
    1, 
    1, 
	1,
    'Descrição livro 1',
    'Sinopse livro 1', 
	NULL
    )
	


DECLARE
	@IDLivro INT

SELECT TOP 1 @IDLivro = L.IDLivro FROM dbo.Livro AS L



INSERT INTO dbo.GeneroLivro (IDLivro, IDGenero) VALUES (@IDLivro, 1 )
INSERT INTO dbo.GeneroLivro (IDLivro, IDGenero) VALUES (@IDLivro, 2 )
INSERT INTO dbo.GeneroLivro (IDLivro, IDGenero) VALUES (@IDLivro, 3 )

INSERT INTO dbo.LinkCompraLivro ( IDLivro, Link ) VALUES (@IDLivro, 'https://www.google.com/' )
INSERT INTO dbo.LinkCompraLivro ( IDLivro, Link ) VALUES (@IDLivro, 'https://www.google.com.br' )