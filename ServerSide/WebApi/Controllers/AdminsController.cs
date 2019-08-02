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
    public class AdminsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdminsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Admins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmin()
        {
            return await _context.Admins.ToListAsync();
        }

        // GET: api/Admins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdmin(int id)
        {
            var Admin = await _context.Admins.FindAsync(id);

            if (Admin == null)
            {
                return NotFound();
            }

            return Admin;
        }

        // PUT: api/Admins/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin(int id, Admin Admin)
        {
            if (id != Admin.ID)
            {
                return BadRequest();
            }

            _context.Entry(Admin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(id))
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

        // POST: api/Admins
        [HttpPost]
        public async Task<ActionResult<Admin>> PostAdmin(Admin Admin)
        {
            _context.Admins.Add(Admin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdmin", new { id = Admin.ID }, Admin);
        }

        // DELETE: api/Admins/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Admin>> DeleteAdmin(int id)
        {
            var Admin = await _context.Admins.FindAsync(id);
            if (Admin == null)
            {
                return NotFound();
            }

            _context.Admins.Remove(Admin);
            await _context.SaveChangesAsync();

            return Admin;
        }

        private bool AdminExists(int id)
        {
            return _context.Admins.Any(e => e.ID == id);
        }
    }
}
