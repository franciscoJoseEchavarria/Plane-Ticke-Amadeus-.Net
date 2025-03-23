using System.ComponentModel.DataAnnotations;

namespace AmadeusAPI.Models;

    public class User_answers
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int User_id { get; set; }
        [Required]
        //quitar esto
        public int Question_id { get; set; }
        [Required]
        public int Question_option_id { get; set; }
        //agrgar un array de tipo String con las respuestas del usuario
        public int Date { get; set; }
    }
