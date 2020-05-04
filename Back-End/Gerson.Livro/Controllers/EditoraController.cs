using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerson.Livro.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gerson.Livro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditoraController : ControllerBase
    {
        private readonly IEditoraService _editoraService;

        public EditoraController(IEditoraService editoraService)
        {
            _editoraService = editoraService;
        }

        // GET: api/Editora
        [HttpGet]
        public ActionResult<IEnumerable<dynamic>> Get()
        {
            var result = _editoraService.GetAll();
            return Ok(result);
        }

        // POST: api/Editora
        [HttpPost]
        public void Post([FromBody] dynamic editora)
        {
            _editoraService.Insert(editora);
        }

        // PUT: api/Editora/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] dynamic editora)
        {
            _editoraService.Update(id, editora);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _editoraService.Delete(id);
        }
    }
}
