
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using AmadeusAPI.Interfaces;
using AmadeusAPI.Models;

namespace AmadeusAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
        public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<CityModel>> GetCityAlluser()
        {
            return await _cityService.GetCityAlluser();
        }
        //preguntar al profe que en esta parte aun con el tocken no me deja acceder a la informacion
        [HttpGet("{id}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<ActionResult<CityModel>> GetCityById(int id)
        {
            var city = await _cityService.GetCityById(id);
            if (city == null)
            {
                return NotFound();
            }
            return city;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddCity(CityModel city)
        {
            await _cityService.AddCity(city);
            return CreatedAtAction(nameof(GetCityById), new { id = city.Id }, city);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCity(int id, CityModel city)
        {
            if (id != city.Id)
            {
                return BadRequest();
            }

            await _cityService.UpdateCity(city);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var city = await _cityService.DeleteCity(id);
            if (city == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}