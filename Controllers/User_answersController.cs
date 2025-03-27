using AmadeusAPI.Interfaces;
using AmadeusAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AmadeusAPI.Controller;

    [Route("api/[controller]")]
    [ApiController]
    public class User_answersController : ControllerBase
    {
        private readonly IUser_answersService _userService;

        public User_answersController(IUser_answersService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<User_answers>>> GetUsers()
        {
            return Ok(await _userService.GetUsers());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<ActionResult<User_answers>> GetUser(int id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("userAnswers/{userId}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<ActionResult<IEnumerable<User_answers>>> GetUserAnswersByUserId(int userId)
        {
            return Ok(await _userService.GetUserAnswersByUserId(userId));
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(User_answers user)
        {
            await _userService.AddUser(user);
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser(int id, User_answers user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await _userService.UpdateUser(user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.DeleteUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }

