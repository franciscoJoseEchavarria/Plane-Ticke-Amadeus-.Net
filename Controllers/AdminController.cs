using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AmadeusAPI.Interfaces;
using AmadeusAPI.Models;
using go4it_amadeus.Models.DTO;
using AmadeusAPI.Interfaces;

namespace AmadeusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController: ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IAuthAdminService _authAdminService;

        public AdminController(IAdminService adminService, IAuthAdminService authAdminService)
        {
            _adminService = adminService;
            _authAdminService = authAdminService;
        }


        [HttpGet]
        public async Task<IEnumerable<Admin>> GetAdminAll()
        {
            return await _adminService.GetAdminAll();
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdminById(int id)
        {
            var admin = await _adminService.GetAdminById(id);
            if (admin == null)
            {
                return NotFound();
            }
            return admin;
        }

        [HttpPost]
        public async Task<ActionResult> AddAdmin(Admin admin)
        {
            await _adminService.AddAdmin(admin);
            return CreatedAtAction(nameof(GetAdminById), new { id = admin.Id }, admin);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdmin(int id, Admin admin)
        {
            if (id != admin.Id)
            {
                return BadRequest();
            }

            await _adminService.UpdateAdmin(admin);
            return NoContent();
        }

       [HttpPost("login")]
       public async Task<IActionResult> Login([FromBody] LoginDto loginDto)

       {
         var result = await _authAdminService.AuthenticateAsync(loginDto.Email, loginDto.Password);
        if (!result.Success)
        {
            return BadRequest(result.ErrorMessage);
        }
        return Ok(new { token = result.Token, expiration = result.Expiration });
       }


    }
}