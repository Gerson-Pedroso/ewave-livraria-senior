INSERT INTO dbo.Livro(Titulo,DataPublicacao,Paginas,IDAutor,IDEditora,Descricao,Sinopse,Capa)VALUES(   'Livro 1 ', GETDATE(),100,1, 1, 'Descrição livro 1','Sinopse livro 1', NULL);
INSERT INTO dbo.GeneroLivro (IDLivro, IDGenero) VALUES (1, 1 );
INSERT INTO dbo.GeneroLivro (IDLivro, IDGenero) VALUES (1, 2 );
INSERT INTO dbo.GeneroLivro (IDLivro, IDGenero) VALUES (1, 3 );
INSERT INTO dbo.LinkCompraLivro ( IDLivro, Link ) VALUES (1, 'https://www.google.com/' );
INSERT INTO dbo.LinkCompraLivro ( IDLivro, Link ) VALUES (1, 'https://www.google.com.br' );