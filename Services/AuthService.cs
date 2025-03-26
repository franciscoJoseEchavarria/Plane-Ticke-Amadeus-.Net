using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using AmadeusAPI.Models;
using AmadeusAPI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

namespace AmadeusAPI.Services
{
    public class AuthService
    {
        private readonly IConfiguration _config;
        private readonly AmadeusAPIDbContext _context;

        // Constructor que inyecta la configuración y el contexto de la base de datos
        public AuthService(IConfiguration config, AmadeusAPIDbContext context)
        {
            _config = config;
            _context = context;
        }

        // Método para validar el usuario y generar un token JWT
        public async Task<(bool success, string token, DateTime expiration)> ValidateUserAndGenerateToken(string email)
        {
            // Busca el usuario en la base de datos por su correo electrónico
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);

            // Si el usuario no existe, devuelve false y un token nulo
            if (user == null)
            {
                return (false, null, DateTime.MinValue);
            }

            // Genera el token JWT y la fecha de expiración
            var (token, expiration) = GenerateToken(email);
            return (true, token, expiration);
        }

        // Método para generar un token JWT
        public (string token, DateTime expiration) GenerateToken(string email)
        {
            // Obtiene el tiempo de expiración del token desde la configuración
            var expirationMinutes = _config.GetValue<int>("Jwt:ExpiryInMinutes");
            var expiration = DateTime.UtcNow.AddMinutes(expirationMinutes);
        
            // Crea la clave de seguridad y las credenciales de firma
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Define los claims del token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, "User")
            };
        
            // Crea el token JWT
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            // Devuelve el token generado y la fecha de expiración
            return (new JwtSecurityTokenHandler().WriteToken(token), expiration);
        }
    }
}