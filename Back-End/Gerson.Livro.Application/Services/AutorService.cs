using Gerson.Livro.Domain.Data;
using Gerson.Livro.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gerson.Livro.Application.Services
{
    public class AutorService: IAutorService
    {
        private readonly IAutorRepository _autorRepository;

        public AutorService(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public void Delete(int id)
        {
            _autorRepository.Delete(id);
        }

        public IEnumerable<dynamic> GetAll()
        {
            return _autorRepository.GetAll();
        }

        public void Insert(dynamic genero)
        {
            _autorRepository.Insert(genero);
        }

        public void Update(int id, dynamic genero)
        {
            _autorRepository.Update(id, genero);
        }
    }
}
