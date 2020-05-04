using System;
using System.Collections.Generic;
using System.Text;
using Gerson.Livro.Domain.Entities.DTO;

namespace Gerson.Livro.Domain.Data
{
    public interface ILivroRepository
    {
        void Delete(int id);
        LivroDto Get(int id);
        IEnumerable<LivroDto> GetAll();
        void Insert(LivroDto livro);
        void Update(int id, LivroDto livro);
    }
}
