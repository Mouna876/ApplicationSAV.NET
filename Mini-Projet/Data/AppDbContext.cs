using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mini_Projet.Models;
using Mini_Projet.Models.Secure;

namespace Mini_Projet.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Reclamation> Reclamations { get; set; }
        public DbSet<Intervention> Interventions { get; set; }
        public DbSet<Technicien> Techniciens { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Piece> Pieces { get; set; }

    }
}
