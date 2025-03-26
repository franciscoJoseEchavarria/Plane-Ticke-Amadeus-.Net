using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmadeusAPI.Models;

namespace AmadeusAPI.Interfaces
{
    public interface IAdminService
    {
        
        Task<IEnumerable<Admin>> GetAdminAll();
     
        Task<Admin> GetAdminById(int id);
        Task<Admin> AddAdmin(Admin admin);
        Task<Admin> UpdateAdmin(Admin admin);
        Task<Admin> DeleteAdmin(int id);
       
    }
}