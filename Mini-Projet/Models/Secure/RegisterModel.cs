using System.ComponentModel.DataAnnotations;

namespace Mini_Projet.Models.Secure
{
    public class RegisterModel
    {
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string Username { get; set; }
        [StringLength(128)]
        public string Email { get; set; }
        [StringLength(256)]
        public string Password { get; set; }

    }
}
