using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmadeusAPI.Models
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Full_name { get; set; }
        [Required]
        public string? Email { get; set; }  
        [Required]
        public string? Password { get; set; }
    }
}