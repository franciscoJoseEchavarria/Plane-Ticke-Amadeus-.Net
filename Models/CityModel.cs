using System.ComponentModel.DataAnnotations;

namespace AmadeusAPI.Models;

public class NewBaseType
{
    [Required]
    public string? CityName { get; set; }
}

public class CityModel : NewBaseType
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Image { get; set; }
    [Required]
    public string? Country { get; set; }
    [Required]
    public string? Language { get; set; }
    [Required]
    public string? UnmissablePlace { get; set; }
    [Required]
    public string? Continent { get; set; }
    [Required]
    public string? CityHash  { get; set; }
}