using Mini_Projet.Models;

namespace Mini_Projet.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClients();
        Task<Client> GetClientById(int id);
        Task<Client> AddClient(Client client);
        Task<Client> UpdateClient(Client client);
        Task<Client> DeleteClient(int id);
    }
}
