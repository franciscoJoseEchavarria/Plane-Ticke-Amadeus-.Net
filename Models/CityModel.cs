using System.ComponentModel.DataAnnotations;

namespace AmadeusAPI.Models;

    public class CityModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string nombreDestino { get; set; }
    [Required]
    public string img { get; set; }
    [Required]
    public string pais { get; set; }

    public string idioma { get; set; }
    public string lugarImperdible { get; set; }
}