using System;
using System.Collections.Generic;
using System.Text;

namespace Gerson.Livro.Domain.Data
{
    public interface IGeneroRepository
    {
        void Delete(int id);
        IEnumerable<dynamic> GetAll();
        void Insert(dynamic genero);
        void Update(int id, dynamic genero);

    }
}
