using Gerson.Livro.Domain.Data;
using Gerson.Livro.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gerson.Livro.Application.Services
{
    public class EditoraService : IEditoraService
    {
        private readonly IEditoraRepository _editoraRepository;

        public EditoraService(IEditoraRepository editoraRepository)
        {
            _editoraRepository = editoraRepository;
        }

        public void Delete(int id)
        {
            _editoraRepository.Delete(id);
        }

        public IEnumerable<dynamic> GetAll()
        {
            return _editoraRepository.GetAll();
        }

        public void Insert(dynamic editora)
        {
            _editoraRepository.Insert(editora);
        }

        public void Update(int id, dynamic editora)
        {
            _editoraRepository.Update(id, editora);
        }
    }
}
