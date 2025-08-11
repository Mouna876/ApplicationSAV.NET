using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Mini_Projet.Models
{
    public class Piece
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Prix { get; set; }
        public int ArticleId { get; set; }
        [JsonIgnore]
        public Article? Article { get; set; }
    }
}
