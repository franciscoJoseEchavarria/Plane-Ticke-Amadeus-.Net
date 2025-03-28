using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AmadeusAPI.Models;
using AmadeusAPI.Interfaces;
using AmadeusAPI.Data;

namespace AmadeusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        private string GetHashedArray(string[] array)
        {
            using (var sha256 = SHA256.Create())
            {
                var concatenatedString = string.Join(",", array);
                var bytes = Encoding.UTF8.GetBytes(concatenatedString);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        
        [HttpPost("hash")]
        public async Task<IActionResult> HashArray([FromBody] string[] array)
        {
            var hash = GetHashedArray(array);
            (CityModel firstCity, CityModel secondCity) = await _destinationService.GetCitiesByHash(hash);
            return Ok(new[] { firstCity, secondCity });
        }
    }
}