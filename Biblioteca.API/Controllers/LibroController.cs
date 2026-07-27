using Biblioteca.BL.Interfaces;
using Biblioteca.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController(ILibroService service) : ControllerBase
    {
        // GET: api/<LibroController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<IEnumerable<LibroDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            IEnumerable<LibroDto> result = await service.GetAllLibrosAsync();
            return result.Any() ? Ok(result) : NoContent();
        }

        // GET api/<LibroController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LibroDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await service.GetLibroByIdAsync(id);
            return result != null ? Ok(result) : NoContent();
        }

        // POST api/<LibroController>
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(LibroDto? dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var result = await service.InsertLibroAsync(dto);
            return result > 0 ? CreatedAtAction("Post", result) : BadRequest();
        }

        // PUT api/<LibroController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, LibroDto? dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var result = await service.UpdateLibroAsync(dto);
            return result != null ? CreatedAtAction("Post", result) : BadRequest(); 
        }

        // DELETE api/<LibroController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.DeleteLibroAsync(id);
            return result ? Ok() : BadRequest();        
        }
    }
}
