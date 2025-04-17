using AmadeusAPI.Interfaces;
using AmadeusAPI.Models;
using Microsoft.AspNetCore.Mvc;
using DnsClient;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mail;


namespace AmadeusAPI.Controller{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       private readonly IUserService _userService;
       private readonly ILookupClient _dnsClient;


        public UserController(IUserService userService)
        {
            _userService = userService;
            _dnsClient = new LookupClient();
        }


        //METODOS PARA UTILIZAR EN EL CRUD
            // Valida el formato del correo utilizando MailAddress
            private bool IsValidEmailFormat(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

         // Verifica si el dominio del correo posee registros MX válidos
        private bool HasValidMxRecords(string email)
        {
            try
            {
                string domain = email.Split('@')[1];
                var result = _dnsClient.Query(domain, QueryType.MX);
                return result.Answers.MxRecords().Any();
            }
            catch
            {
                return false;
            }
        }
             private bool IsValidEmail(string email)
        {
            return IsValidEmailFormat(email) && HasValidMxRecords(email);
        }
        

        [HttpGet("GetEmail/{email}")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmail(email);
            if (user == null)
            {
                var errorResponse = new MistakeResponse(
                    404, 
                    "Usuario no encontrado.", 
                    "El usuario con el correo proporcionado no existe."
                );
                return NotFound(errorResponse);
            }

            return Ok(user);
        }


        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userService.GetUsers();
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                var MistaResponse = new MistakeResponse(
                    404, 
                    "Usuario no encontrado.", 
                    "El usuario con el id proporcionado no existe."
                );
                return NotFound(MistaResponse);
            }

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
              // Validación del correo
            if (string.IsNullOrWhiteSpace(user.Email) || !IsValidEmail(user.Email))
            {
                var errorResponse = new MistakeResponse(
                    400, 
                    "El correo no es válido.", 
                    "El formato del correo o el dominio no son correctos."
                );
                return BadRequest(errorResponse);
            }
            // Verificar si el usuario existe
            var existingUser = await _userService.GetUserByEmail(user.Email);
            if (existingUser != null)
            {
                // Si el usuario existe, devolver éxito con el usuario existente
                return Ok(new { 
                    user = existingUser,
                    message = "Usuario existente autenticado con éxito"
                });
            }

            // Si el usuario no existe, crear uno nuevo
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

        [HttpGet("paged")]
        public async Task<ActionResult<PagedResult<User>>> GetPagedUsers(int page = 1, int pageSize = 10)
        {
            var result = await _userService.GetPagedUsers(page, pageSize);
            return Ok(result);
        }
    }
            
}

