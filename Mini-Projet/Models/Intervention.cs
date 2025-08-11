using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Projet.Models
{
    public class Intervention
    {
        public int Id { get; set; }
        public DateTime DateIntervention { get; set; }
        public bool SousGarantie { get; set; }
        public int MontantFacture { get; set; }
        public int ReclamationId { get; set; }
        public Reclamation? Reclamation { get; set; }
        public int TechnicienId { get; set; }
        public Technicien? Technicien { get; set; }
    }
}
