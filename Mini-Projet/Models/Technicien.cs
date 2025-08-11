namespace Mini_Projet.Models
{
    public class Technicien
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Specialisation { get; set; }
        public ICollection<Intervention>? Interventions { get; set; }
    }
}
