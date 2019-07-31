using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrateursController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdministrateursController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Administrateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrateur>>> GetAdministrateur()
        {
            return await _context.Administrateur.ToListAsync();
        }

        // GET: api/Administrateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrateur>> GetAdministrateur(int id)
        {
            var administrateur = await _context.Administrateur.FindAsync(id);

            if (administrateur == null)
            {
                return NotFound();
            }

            return administrateur;
        }

        // PUT: api/Administrateurs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrateur(int id, Administrateur administrateur)
        {
            if (id != administrateur.ID)
            {
                return BadRequest();
            }

            _context.Entry(administrateur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministrateurExists(id))
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

        // POST: api/Administrateurs
        [HttpPost]
        public async Task<ActionResult<Administrateur>> PostAdministrateur(Administrateur administrateur)
        {
            _context.Administrateur.Add(administrateur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdministrateur", new { id = administrateur.ID }, administrateur);
        }

        // DELETE: api/Administrateurs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Administrateur>> DeleteAdministrateur(int id)
        {
            var administrateur = await _context.Administrateur.FindAsync(id);
            if (administrateur == null)
            {
                return NotFound();
            }

            _context.Administrateur.Remove(administrateur);
            await _context.SaveChangesAsync();

            return administrateur;
        }

        private bool AdministrateurExists(int id)
        {
            return _context.Administrateur.Any(e => e.ID == id);
        }
    }
}
