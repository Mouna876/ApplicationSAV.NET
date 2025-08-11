using Mini_Projet.Models;

namespace Mini_Projet.Repositories
{
    public interface IInterventionRepository
    {
        Task<IEnumerable<Intervention>> GetInterventions();
        Task<Intervention> GetInterventionById(int id);
        Task<Intervention> AddIntervention(Intervention intervention);
        Task<Intervention> UpdateIntervention(Intervention intervention);
        Task<Intervention> DeleteIntervention(int id);
    }
}
