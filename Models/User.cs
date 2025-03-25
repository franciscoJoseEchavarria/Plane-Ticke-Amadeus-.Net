using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AmadeusAPI.Models;

    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Full_name { get; set; }
        [Required]
        public string? Email { get; set; }
        [JsonIgnore]
        public ICollection<User_answers>? UserAnswers { get; set; }
    }
