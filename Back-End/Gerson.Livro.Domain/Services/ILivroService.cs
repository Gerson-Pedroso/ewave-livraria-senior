using Gerson.Livro.Domain.Entities.DTO;
using System.Collections.Generic;

namespace Gerson.Livro.Domain.Services
{
    public interface ILivroService
    {
        IEnumerable<LivroDto> GetAll();
        LivroDto Get(int id);
        void Insert(LivroDto livro);
        void Update(int id, LivroDto livro);
        void Delete(int id);
    }
}