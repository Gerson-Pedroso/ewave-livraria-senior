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
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;

        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        // GET: api/Autor
        [HttpGet]
        public ActionResult<IEnumerable<dynamic>> Get()
        {
            var result = _autorService.GetAll();
            return Ok(result);
        }
        
        // POST: api/Autor
        [HttpPost]
        public void Post([FromBody] dynamic autor)
        {
            _autorService.Insert(autor);
        }

        // PUT: api/Autor/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] dynamic autor)
        {
            _autorService.Update(id, autor);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _autorService.Delete(id);
        }
    }
}
