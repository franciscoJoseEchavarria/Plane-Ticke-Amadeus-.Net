using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace AmadeusAPI.Models;

    public class User_answers
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User_id")]
        [Required]
        [Column("user_id")]
        public int User_id { get; set; }

        [ValidateNever] // Esto evita que se valide la propiedad User
        [JsonIgnore]
        public User? User { get; set; }

        [Required]
        public string[] Answers { get; set; }
        [Required]
        public int Date { get; set; }
    }
