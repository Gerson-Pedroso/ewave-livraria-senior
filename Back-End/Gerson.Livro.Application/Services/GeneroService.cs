using Gerson.Livro.Domain.Data;
using Gerson.Livro.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gerson.Livro.Application.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroService(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }

        public void Delete(int id)
        {
            _generoRepository.Delete(id);
        }
       
        public IEnumerable<dynamic> GetAll()
        {
            return _generoRepository.GetAll();
        }

        public void Insert(dynamic genero)
        {
            _generoRepository.Insert(genero);
        }

        public void Update(int id, dynamic genero)
        {
            _generoRepository.Update(id, genero);
        }
    }
}
