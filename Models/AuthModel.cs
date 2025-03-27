using System.ComponentModel.DataAnnotations;

namespace AmadeusAPI.Models
{
    // Esta clase representa la respuesta de autenticación que se envía al cliente después de un inicio de sesión exitoso.
    public class AuthResponse
    {
        // Token JWT generado para el usuario autenticado.
        public string Token { get; set; }

        // Fecha y hora de expiración del token.
        public string Expiration { get; set; }
    }

    // Esta clase representa la solicitud de inicio de sesión que el cliente envía al servidor.
    public class LoginRequest
    {
        // Dirección de correo electrónico del usuario que intenta iniciar sesión.
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}