using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mini_Projet.Data;
using Mini_Projet.Models;

namespace Mini_Projet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "ResponsableSAV")]
    public class InterventionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InterventionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Interventions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Intervention>>> GetInterventions()
        {
            return await _context.Interventions.ToListAsync();
        }

        // GET: api/Interventions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Intervention>> GetIntervention(int id)
        {
            var intervention = await _context.Interventions.FindAsync(id);

            if (intervention == null)
            {
                return NotFound();
            }

            return intervention;
        }

        // PUT: api/Interventions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIntervention(int id, Intervention intervention)
        {
            if (id != intervention.Id)
            {
                return BadRequest();
            }

            _context.Entry(intervention).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterventionExists(id))
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

        // POST: api/Interventions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Intervention>> PostIntervention(Intervention intervention)
        {
            _context.Interventions.Add(intervention);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIntervention", new { id = intervention.Id }, intervention);
        }

        // DELETE: api/Interventions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIntervention(int id)
        {
            var intervention = await _context.Interventions.FindAsync(id);
            if (intervention == null)
            {
                return NotFound();
            }

            _context.Interventions.Remove(intervention);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InterventionExists(int id)
        {
            return _context.Interventions.Any(e => e.Id == id);
        }

        [HttpPost("{id}/CalculateInvoice")]
        public async Task<IActionResult> CalculateInvoice(int id)
        {
            var intervention = await _context.Interventions
                .Include(i => i.Reclamation)
                .ThenInclude(r => r.Client)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (intervention == null)
            {
                return NotFound();
            }

            if (intervention.SousGarantie)
            {
                intervention.MontantFacture = 0; // Gratuit sous garantie
            }
            else
            {
                var pieces = await _context.Pieces
                    .Where(p => p.ArticleId == intervention.Reclamation.Client.Id)
                    .ToListAsync();

                intervention.MontantFacture = pieces.Sum(p => p.Prix) + 100; // Exemple : 100 pour main d'œuvre
            }

            await _context.SaveChangesAsync();
            return Ok(intervention.MontantFacture);
        }

    }
}
