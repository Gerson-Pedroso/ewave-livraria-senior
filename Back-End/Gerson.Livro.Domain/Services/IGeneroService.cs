using System;
using System.Collections.Generic;
using System.Text;

namespace Gerson.Livro.Domain.Services
{
    public interface IGeneroService
    {
        void Delete(int id);
        IEnumerable<dynamic> GetAll();
        void Insert(dynamic genero);
        void Update(int id, dynamic genero);

    }
}
