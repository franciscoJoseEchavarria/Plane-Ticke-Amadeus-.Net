using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmadeusAPI.Interfaces;
using AmadeusAPI.Models;

namespace AmadeusAPI.Services
{
    public class AdminService: IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<Admin> GetAdminById(int id)
        {
            return await _adminRepository.GetAdminById(id);
        }
        public async Task<IEnumerable<Admin>> GetAdminAll()
        {
            return await _adminRepository.GetAdminAll();
        }


        public async Task<Admin> AddAdmin(Admin admin)
        {
            admin.Password = BCrypt.Net.BCrypt.HashPassword(admin.Password);
            await _adminRepository.AddAdmin(admin);
            return admin;
        }

        public async Task<Admin> UpdateAdmin(Admin admin)
        {
            await _adminRepository.UpdateAdmin(admin);
            return admin;
        }

        public async Task<Admin?> DeleteAdmin(int id)
        {
            return await _adminRepository.DeleteAdmin(id);
        }

    }
}