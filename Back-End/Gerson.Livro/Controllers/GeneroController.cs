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
    public class GeneroController : ControllerBase
    {

        private readonly IGeneroService _generoService;

        public GeneroController(IGeneroService generoService)
        {
            _generoService = generoService;
        }

        // GET: api/Genero
        [HttpGet]
        public ActionResult<IEnumerable<dynamic>> Get()
        {
            var result = _generoService.GetAll();
            return Ok(result);
        }       

        // POST: api/Genero
        [HttpPost]
        public void Post([FromBody] dynamic genero)
        {
            _generoService.Insert(genero);
        }

        // PUT: api/Genero/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] dynamic genero)
        {
            _generoService.Update(id, genero);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _generoService.Delete(id);
        }
    }
}
