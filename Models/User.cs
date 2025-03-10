using System.ComponentModel.DataAnnotations;

namespace AmadeusAPI.Models;

    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Full_name { get; set; }
        [Required]
        public string Email { get; set; }
    }
