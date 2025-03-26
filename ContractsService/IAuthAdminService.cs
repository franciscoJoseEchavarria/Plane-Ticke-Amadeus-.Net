
using go4it_amadeus.Models.Response; // Assuming AdminAuthResult is defined in this namespace

namespace AmadeusAPI.Interfaces;
   
    public interface IAuthAdminService

    {
        Task<AdminAuthResult> AuthenticateAsync(string email, string password);
    }
