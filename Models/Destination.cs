using System.ComponentModel.DataAnnotations;

namespace go4it_amadeus.Models
{
    public class Destination
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Combination { get; set; }

        [Required]
        public int FirstCityId { get; set; }

        [Required]
        public int SecondCityId { get; set; }
    }
}