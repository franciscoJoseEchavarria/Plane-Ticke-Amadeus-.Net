using AmadeusAPI.Interfaces;
using AmadeusAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmadeusAPI.Controller;

    [Route("api/[controller]")]
    [ApiController]
    public class User_answersController : ControllerBase
    {
        private readonly IUserService _userService;

        public User_answersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await _userService.GetUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            await _userService.AddUser(user);
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await _userService.UpdateUser(user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _userService.DeleteUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }

