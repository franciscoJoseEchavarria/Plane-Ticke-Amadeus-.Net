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
        public IActionResult HashArray([FromBody] string[] array)
        {
            var hashedArray = _destinationService.GetHashedArray(array);
            return Ok(hashedArray);
        }
    }
}