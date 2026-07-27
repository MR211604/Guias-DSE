using Biblioteca.BL.Interfaces;
using Biblioteca.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController(IEditorialService service) : ControllerBase
    {
        // GET: api/<AutorController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<IEnumerable<EditorialDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            IEnumerable<EditorialDto> result = await service.GetAllEditorialesAsync();
            return result.Any() ? Ok(result) : NoContent();
        }

        // GET api/<AutorController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EditorialDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await service.GetEditorialByIdAsync(id);
            return result != null ? Ok(result) : NoContent();
        }

        // POST api/<AutorController>
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(EditorialDto? dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var result = await service.InsertEditorialAsync(dto);
            return result > 0 ? CreatedAtAction("Post", result) : BadRequest();
        }

        // PUT api/<AutorController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, EditorialDto? dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var result = await service.UpdateEditorialAsync(dto);
            return result != null ? CreatedAtAction("Post", result) : BadRequest();
        }

        // DELETE api/<AutorController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.DeleteEditorialAsync(id);
            return result ? Ok(result) : BadRequest();
        }
    }
}
