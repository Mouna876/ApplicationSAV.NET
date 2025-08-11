using Microsoft.EntityFrameworkCore;
using Mini_Projet.Data;
using Mini_Projet.Models;

namespace Mini_Projet.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetClientById(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Client> AddClient(Client client)
        {
            var result = await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Client> UpdateClient(Client client)
        {
            var existingClient = await _context.Clients.FirstOrDefaultAsync(c => c.Id == client.Id);
            if (existingClient != null)
            {
                existingClient.Nom = client.Nom;
                existingClient.Email = client.Email;
                existingClient.Telephone = client.Telephone;

                await _context.SaveChangesAsync();
                return existingClient;
            }
            return null;
        }

        public async Task<Client> DeleteClient(int id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
                return client;
            }
            return null;
        }
    }
}
