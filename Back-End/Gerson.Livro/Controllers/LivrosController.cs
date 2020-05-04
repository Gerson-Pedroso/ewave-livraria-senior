using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerson.Livro.Domain.Entities.DTO;
using Gerson.Livro.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gerson.Livro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivrosController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<LivroDto>> Get()
        {
            var result = _livroService.GetAll();
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<LivroDto> Get(int id)
        {
            var result = _livroService.Get(id);
            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] LivroDto livro)
        {
            _livroService.Insert(livro);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] LivroDto livro)
        {
            _livroService.Update(id, livro);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _livroService.Delete(id);
        }
    }
}
