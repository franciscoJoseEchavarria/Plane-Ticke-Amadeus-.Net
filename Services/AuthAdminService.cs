
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AmadeusAPI.Interfaces;
using go4it_amadeus.Models.Response;
using AmadeusAPI.Models;
using AmadeusAPI.Interfaces;



namespace go4it_amadeus.Services
{
    public class AuthAdminService : IAuthAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IConfiguration _configuration;

        // Constructor que inyecta el repositorio de administradores y la configuración
        public AuthAdminService(IAdminRepository adminRepository, IConfiguration configuration)
        {
            _adminRepository = adminRepository;
            _configuration = configuration;
        }

        // Método para autenticar a un administrador
        public async Task<AdminAuthResult> AuthenticateAsync(string email, string password)
        {
            // Busca al administrador por su correo electrónico
            var admin = await _adminRepository.GetAdminByEmail(email);
            
            // Verifica si el administrador existe y si la contraseña es correcta
            if (admin == null || !BCrypt.Net.BCrypt.Verify(password, admin.Password))
            {
                return new AdminAuthResult { Success = false, ErrorMessage = "Credenciales inválidas" };
            }
            
            // Genera el token JWT y la fecha de expiración
            var (token, expiration) = GenerateToken(admin);
            return new AdminAuthResult { Success = true, Token = token, Expiration = expiration };
        }

        // Método privado para generar un token JWT
        private (string token, DateTime expiration) GenerateToken(Admin admin)
        {
            // Obtiene el tiempo de expiración del token desde la configuración
            int expirationMinutes = _configuration.GetValue<int>("Jwt:ExpiryInMinutes");
            var expiration = DateTime.UtcNow.AddMinutes(expirationMinutes);
            
            // Crea la clave de seguridad y las credenciales de firma
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Define los claims del token
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, admin.Email),
                new Claim(JwtRegisteredClaimNames.Email, admin.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()),
                new Claim(ClaimTypes.Role, "Admin")
            };

            // Crea el token JWT
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            // Devuelve el token generado y la fecha de expiración
            return (new JwtSecurityTokenHandler().WriteToken(token), expiration);
        }
    }
}