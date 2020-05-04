using System;
using System.Collections.Generic;
using System.Text;

namespace Gerson.Livro.Domain.Data
{
    public interface IEditoraRepository
    {
        void Delete(int id);
        IEnumerable<dynamic> GetAll();
        void Insert(dynamic editora);
        void Update(int id, dynamic editora);
    }
}
