using System.ComponentModel.DataAnnotations;

namespace AmadeusAPI.Models;

    public class CityModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? CityName { get; set; }
    [Required]
    public string? Image { get; set; }
    [Required]
    public string? Country { get; set; }
    public string? Language { get; set; }
    public string? UnmissablePlace { get; set; }
    public string? Continent { get; set; }
    public string? CityHash  { get; set; }
}