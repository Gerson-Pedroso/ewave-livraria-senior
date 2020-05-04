using System;
using System.Collections.Generic;
using System.Text;

namespace Gerson.Livro.Domain.Services
{
    public interface IEditoraService
    {
        void Delete(int id);
        IEnumerable<dynamic> GetAll();
        void Insert(dynamic editora);
        void Update(int id, dynamic editora);
    }
}
