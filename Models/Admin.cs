using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AmadeusAPI.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string? Full_name { get; set; }
        [Required]
        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}