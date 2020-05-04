using System;
using System.Collections.Generic;

namespace Gerson.Livro.Domain.Entities.DTO
{
    public class LivroDto
    {
        public int IDLivro { get; set; }
        public string Titulo { get; set; }
        public DateTime DataPublicacao { get; set; }
        public int Paginas { get; set; }
        public string Descricao { get; set; }
        public string Sinopse { get; set; }
        public string Capa { get; set; }

        public int IDAutor { get; set; }
        public string Autor { get; set; }

        public int IDEditora { get; set; }
        public string Editora { get; set; }
        public int IDGenero { get; set; }
        public IEnumerable<string> Generos { get; set; }
        //public IEnumerable<string> LinksCompra { get; set; }
    }
}