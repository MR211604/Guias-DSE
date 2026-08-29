using LibrosAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Text.Json;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class LibrosController : ControllerBase
{
    private readonly LibrosDbContext _context;
    private readonly IConnectionMultiplexer _redis;

    public LibrosController(LibrosDbContext context, IConnectionMultiplexer redis)
    {
        _context = context;
        _redis = redis;
    }

    // GET: api/Libro
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Libro>>> GetLibro()
    {
        var dbRedis = _redis.GetDatabase();
        var cacheKey = "libros_list";
        var librosCache = await _redis.GetDatabase().StringGetAsync(cacheKey);
        
        if (!librosCache.IsNullOrEmpty)
        {
            return JsonSerializer.Deserialize<List<Libro>>((string)librosCache);
        }
        // Caso contrario, se obtienen los productos desde la base de datos
        var libros = await _context.Libros.AsNoTracking().ToListAsync();
        // Se almacena la lista obtenida en la cache por 10 minutos
        await dbRedis.StringSetAsync(cacheKey, JsonSerializer.Serialize(libros),
       TimeSpan.FromMinutes(10));
        return libros;
    }

    // GET: api/Libro/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Libro>> GetLibro(int id)
    {
        var dbRedis = _redis.GetDatabase();
        var cacheKey = $"libro_{id}";
        var libroCache = await _redis.GetDatabase().StringGetAsync(cacheKey);
        if (!libroCache.IsNullOrEmpty)
        {
            return JsonSerializer.Deserialize<Libro>((string)libroCache);
        }
        var libro = await _context.Libros.FindAsync(id);
        if (libro == null)
        {
            return NotFound();
        }
        await dbRedis.StringSetAsync(cacheKey, JsonSerializer.Serialize(libro),
       TimeSpan.FromMinutes(10));
        return libro;
    }

    // PUT: api/Libro/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutLibro(int? id, Libro libro)
    {
        if (id != libro.Id)
        {
            return BadRequest();
        }
        _context.Entry(libro).State = EntityState.Modified;
        try
        {
            var dbRedis = _redis.GetDatabase();
            var cacheKeyLibro = $"libro_{id}";
            var cacheKeyLista = "libros_list";
            
            // Elimina el producto de la cache
            await dbRedis.KeyDeleteAsync(cacheKeyLibro);
            
            // Elimina la lista de productos de la cache
            await dbRedis.KeyDeleteAsync(cacheKeyLista);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LibroExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();

    }

    // POST: api/Libro
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Libro>> PostLibro(Libro libro)
    {
        _context.Libros.Add(libro);
        
        await _context.SaveChangesAsync();
        
        var dbRedis = _redis.GetDatabase();
        var cacheKeyLista = "libros_list";
        
        await dbRedis.KeyDeleteAsync(cacheKeyLista);
        
        return CreatedAtAction("GetLibro", new { id = libro.Id }, libro);
    }

    // DELETE: api/Libro/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLibro(int? id)
    {
        var libro = await _context.Libros.FindAsync(id);
        
        if (libro == null)
        {
            return NotFound();
        }
        
        _context.Libros.Remove(libro);
        await _context.SaveChangesAsync();
        
        var dbRedis = _redis.GetDatabase();
        var cacheKeyLibro= $"libro_{id}";
        var cacheKeyLista = "libros_list";
        
        await dbRedis.KeyDeleteAsync(cacheKeyLibro);
        await dbRedis.KeyDeleteAsync(cacheKeyLista);
        
        return NoContent();

    }

    private bool LibroExists(int? id)
    {
        return _context.Libros.Any(e => e.Id == id);
    }
}
