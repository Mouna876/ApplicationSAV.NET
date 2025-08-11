namespace Mini_Projet.Models
{
    public class Reclamation
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateReclamation { get; set; }
        public string Statut { get; set; } // "En cours", "Terminée"
        public int ClientId { get; set; }
        public Client? Client { get; set; }
    }
}
