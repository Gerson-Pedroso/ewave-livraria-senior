using System;
using System.Collections.Generic;
using System.Text;

namespace Gerson.Livro.Domain.Services
{
    public interface IAutorService
    {
        void Delete(int id);
        IEnumerable<dynamic> GetAll();
        void Insert(dynamic autor);
        void Update(int id, dynamic autor);
    }
}
