using Microsoft.EntityFrameworkCore;
using Mini_Projet.Data;
using Mini_Projet.Models;

namespace Mini_Projet.Repositories
{
    public class InterventionRepository : IInterventionRepository
    {
        private readonly AppDbContext _context;

        public InterventionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Intervention>> GetInterventions()
        {
            return await _context.Interventions
                .Include(i => i.Reclamation) // Inclure la réclamation associée
                .Include(i => i.Technicien) // Inclure le technicien assigné
                .ToListAsync();
        }

        public async Task<Intervention> GetInterventionById(int id)
        {
            return await _context.Interventions
                .Include(i => i.Reclamation)
                .Include(i => i.Technicien)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Intervention> AddIntervention(Intervention intervention)
        {
            var result = await _context.Interventions.AddAsync(intervention);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Intervention> UpdateIntervention(Intervention intervention)
        {
            var existingIntervention = await _context.Interventions.FirstOrDefaultAsync(i => i.Id == intervention.Id);
            if (existingIntervention != null)
            {
                existingIntervention.DateIntervention = intervention.DateIntervention;
                existingIntervention.SousGarantie = intervention.SousGarantie;
                existingIntervention.MontantFacture = intervention.MontantFacture;
                existingIntervention.TechnicienId = intervention.TechnicienId;

                await _context.SaveChangesAsync();
                return existingIntervention;
            }
            return null;
        }

        public async Task<Intervention> DeleteIntervention(int id)
        {
            var intervention = await _context.Interventions.FirstOrDefaultAsync(i => i.Id == id);
            if (intervention != null)
            {
                _context.Interventions.Remove(intervention);
                await _context.SaveChangesAsync();
                return intervention;
            }
            return null;
        }
    }
}
