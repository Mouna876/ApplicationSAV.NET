namespace Mini_Projet.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public ICollection<Reclamation>? Reclamations { get; set; }
    }
}
