using AmadeusAPI.Interfaces;
using AmadeusAPI.Models;
using Microsoft.AspNetCore.Mvc;
using DnsClient;
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

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userService.GetUsers();
        }

        [HttpGet("{id}")]
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
            // Verificar duplicidad: se asume que el servicio o repositorio tiene un método GetUserByEmail
            var existingUser = await _userService.GetUser(user.Email);
            if (existingUser != null)
            {
                var errorResponse = new MistakeResponse(
                    409, 
                    "El correo ya se encuentra registrado.", 
                    "Por favor, utilice otro correo."
                );
                return BadRequest(errorResponse);
            }
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
}

