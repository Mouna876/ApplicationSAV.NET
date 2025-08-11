using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mini_Projet.Data;
using Mini_Projet.Models;

namespace Mini_Projet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechniciensController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TechniciensController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Techniciens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Technicien>>> GetTechniciens()
        {
            return await _context.Techniciens.ToListAsync();
        }

        // GET: api/Techniciens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Technicien>> GetTechnicien(int id)
        {
            var technicien = await _context.Techniciens.FindAsync(id);

            if (technicien == null)
            {
                return NotFound();
            }

            return technicien;
        }

        // PUT: api/Techniciens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTechnicien(int id, Technicien technicien)
        {
            if (id != technicien.Id)
            {
                return BadRequest();
            }

            _context.Entry(technicien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechnicienExists(id))
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

        // POST: api/Techniciens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Technicien>> PostTechnicien(Technicien technicien)
        {
            _context.Techniciens.Add(technicien);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTechnicien", new { id = technicien.Id }, technicien);
        }

        // DELETE: api/Techniciens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechnicien(int id)
        {
            var technicien = await _context.Techniciens.FindAsync(id);
            if (technicien == null)
            {
                return NotFound();
            }

            _context.Techniciens.Remove(technicien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TechnicienExists(int id)
        {
            return _context.Techniciens.Any(e => e.Id == id);
        }
    }
}
