using BibliotecaApp.Models;
using BibliotecaApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly LivrosService _service;
        public LivrosController(LivrosService service) => _service = service;

        /// <summary>Lista todos os livros</summary>
        [HttpGet]
        public async Task<ActionResult<List<Livro>>> Get() =>
            await _service.GetAsync();

        /// <summary>Obtém um livro por Id</summary>
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Livro>> GetById(string id)
        {
            var livro = await _service.GetByIdAsync(id);
            return livro is null ? NotFound() : livro;
        }

        /// <summary>Cria um novo livro</summary>
        [HttpPost]
        public async Task<ActionResult<Livro>> Post([FromBody] Livro livro)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            await _service.CreateAsync(livro);
            return CreatedAtAction(nameof(GetById), new { id = livro.Id }, livro);
        }

        /// <summary>Atualiza um livro</summary>
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Put(string id, [FromBody] Livro livro)
        {
            var exists = await _service.GetByIdAsync(id);
            if (exists is null) return NotFound();

            var ok = await _service.UpdateAsync(id, livro);
            return ok ? NoContent() : Problem("Falha ao atualizar.");
        }

        /// <summary>Remove um livro</summary>
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var exists = await _service.GetByIdAsync(id);
            if (exists is null) return NotFound();

            var ok = await _service.DeleteAsync(id);
            return ok ? NoContent() : Problem("Falha ao excluir.");
        }
    }
}
