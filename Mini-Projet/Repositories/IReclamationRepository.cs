using Mini_Projet.Models;

namespace Mini_Projet.Repositories
{
    public interface IReclamationRepository
    {
        Task<IEnumerable<Reclamation>> GetReclamations();
        Task<Reclamation> GetReclamationById(int id);
        Task<Reclamation> AddReclamation(Reclamation reclamation);
        Task<Reclamation> UpdateReclamation(Reclamation reclamation);
        Task<Reclamation> DeleteReclamation(int id);
    }
}
