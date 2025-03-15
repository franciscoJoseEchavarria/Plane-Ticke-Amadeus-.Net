using Microsoft.AspNetCore.Mvc;
using AmadeusAPI.Models;
using AmadeusAPI.Interfaces;

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

        [HttpPost("hash")]
        public async Task<IActionResult> HashArray([FromBody] string[] array)
        {
            var hash = _destinationService.GetHashedArray(array);
            (int firstCityId, int secondCityId) = await _destinationService.GetCityIdsByHash(hash);
            return Ok(new { firstCityId, secondCityId });
        }
    }
}