using Microsoft.EntityFrameworkCore;
using Mini_Projet.Data;
using Mini_Projet.Models;

namespace Mini_Projet.Repositories
{
    public class ReclamationRepository : IReclamationRepository
    {
        private readonly AppDbContext _context;

        public ReclamationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reclamation>> GetReclamations()
        {
            return await _context.Reclamations
                .Include(r => r.Client) // Inclure les informations du client
                .ToListAsync();
        }

        public async Task<Reclamation> GetReclamationById(int id)
        {
            return await _context.Reclamations
                .Include(r => r.Client) // Inclure les informations du client
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Reclamation> AddReclamation(Reclamation reclamation)
        {
            var result = await _context.Reclamations.AddAsync(reclamation);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Reclamation> UpdateReclamation(Reclamation reclamation)
        {
            var existingReclamation = await _context.Reclamations.FirstOrDefaultAsync(r => r.Id == reclamation.Id);
            if (existingReclamation != null)
            {
                existingReclamation.Description = reclamation.Description;
                existingReclamation.DateReclamation = reclamation.DateReclamation;
                existingReclamation.Statut = reclamation.Statut;

                await _context.SaveChangesAsync();
                return existingReclamation;
            }
            return null;
        }

        public async Task<Reclamation> DeleteReclamation(int id)
        {
            var reclamation = await _context.Reclamations.FirstOrDefaultAsync(r => r.Id == id);
            if (reclamation != null)
            {
                _context.Reclamations.Remove(reclamation);
                await _context.SaveChangesAsync();
                return reclamation;
            }
            return null;
        }
    }
}
