using System;
using System.Collections.Generic;
using System.Linq;
using AmadeusAPI.Models; // Add this line if Admin class is in Models namespace
using System.Threading.Tasks;

namespace AmadeusAPI.Interfaces

{
    public interface IAdminRepository
    {
        Task<Admin> GetAdminById(int id);
        Task<Admin> GetAdminByEmail(string email);
        Task<IEnumerable<Admin>> GetAdminAll();
        Task AddAdmin(Admin admin);
        
        Task UpdateAdmin(Admin admin);
        Task<Admin?> DeleteAdmin(int id);
    }
}