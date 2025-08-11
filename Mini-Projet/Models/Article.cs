using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Pipelines;

namespace Mini_Projet.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public int Prix { get; set; }
        public bool SousGarantie { get; set; }
        public ICollection<Piece>? Pieces { get; set; }
    }
}
