using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API250416.Models;

namespace API250416.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParalimpiumsController : ControllerBase
    {
        private readonly ParalimpiaDbContext _context;

        public ParalimpiumsController(ParalimpiaDbContext context)
        {
            _context = context;
        }

        // GET: api/Paralimpiums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paralimpium>>> GetParalimpia()
        {
            return await _context.Paralimpia.ToListAsync();
        }

        // GET: api/Paralimpiums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paralimpium>> GetParalimpium(int id)
        {
            var paralimpium = await _context.Paralimpia.FindAsync(id);

            if (paralimpium == null)
            {
                return NotFound();
            }

            return paralimpium;
        }

        // PUT: api/Paralimpiums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParalimpium(int id, Paralimpium paralimpium)
        {
            if (id != paralimpium.Id)
            {
                return BadRequest();
            }

            _context.Entry(paralimpium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParalimpiumExists(id))
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

        // POST: api/Paralimpiums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Paralimpium>> PostParalimpium(Paralimpium paralimpium)
        {
            _context.Paralimpia.Add(paralimpium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParalimpium", new { id = paralimpium.Id }, paralimpium);
        }

        // DELETE: api/Paralimpiums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParalimpium(int id)
        {
            var paralimpium = await _context.Paralimpia.FindAsync(id);
            if (paralimpium == null)
            {
                return NotFound();
            }

            _context.Paralimpia.Remove(paralimpium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParalimpiumExists(int id)
        {
            return _context.Paralimpia.Any(e => e.Id == id);
        }
    }
}
