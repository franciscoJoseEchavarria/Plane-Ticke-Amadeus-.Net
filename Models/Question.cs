using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AmadeusAPI.Models;

 [Table("Question")] 
public class Question
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("category")] 
    public string Category { get; set; }

   [Column("text")]
    public string Text { get; set; }
    [JsonIgnore] // Evita el ciclo

    public List<QuestionOption> Options { get; set; } = new();
}


