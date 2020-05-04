using Gerson.Livro.Domain.Data;
using Gerson.Livro.Domain.Entities.DTO;
using Gerson.Livro.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gerson.Livro.Application.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public void Delete(int id)
        {
            _livroRepository.Delete(id);
        }

        public LivroDto Get(int id)
        {
            return _livroRepository.Get(id);
        }

        public IEnumerable<LivroDto> GetAll()
        {
            return _livroRepository.GetAll();
        }

        public void Insert(LivroDto livro)
        {
            _livroRepository.Insert(livro);
        }

        public void Update(int id, LivroDto livro)
        {
            _livroRepository.Update(id, livro);
        }
    }
}
