using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AmadeusAPI.Models;


    [Table("question_option")] 
    public class QuestionOption
    {
            [Key]
            [Column("id")]
        public int Id { get; set; }

        [ForeignKey("Question")]
        [Column("question_id")]
        public int QuestionId { get; set; }
        public string? Text { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        [JsonIgnore] 
        public Question? Question { get; set; }
    }
