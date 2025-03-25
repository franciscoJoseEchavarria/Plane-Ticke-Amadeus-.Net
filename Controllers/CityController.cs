
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AmadeusAPI.Interfaces;
using AmadeusAPI.Models;
using Microsoft.AspNetCore.Authorization;


namespace AmadeusAPI.Controller
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
        public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }
    

        [HttpGet("protectedpath")]
        public async Task<IEnumerable<CityModel>> GetCityAlluser()
        {
            return await _cityService.GetCityAlluser();
        }
        //preguntar al profe que en esta parte aun con el tocken no me deja acceder a la informacion
        [HttpGet("{id}")]
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
        public async Task<ActionResult> AddCity(CityModel city)
        {
            await _cityService.AddCity(city);
            return CreatedAtAction(nameof(GetCityById), new { id = city.Id }, city);
        }

        [HttpPut("{id}")]
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