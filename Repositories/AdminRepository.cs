using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmadeusAPI.Interfaces;
using AmadeusAPI.Models;
using Microsoft.EntityFrameworkCore;
using AmadeusAPI.Data; // Add this line

namespace AmadeusAPI.Repositories;

    public class AdminRepository: IAdminRepository
    {
         private readonly AmadeusAPIDbContext _context;

            public AdminRepository(AmadeusAPIDbContext context)
        {
            _context = context;
        }

        public async Task<Admin> GetAdminById(int id)
        {
           var admin = await _context.Admin.FindAsync(id);
           if (admin == null)
           {
               throw new KeyNotFoundException($"Admin with id {id} not found.");
           }
           return admin;
        }

        public async Task<Admin> GetAdminByEmail(string email)
        {
            var admin = await _context.Admin.FirstOrDefaultAsync(a => a.Email == email);
            if (admin == null)
            {
                throw new KeyNotFoundException($"Admin with email {email} not found.");
            }
            return admin;
        }
        
        public async Task<IEnumerable<Admin>> GetAdminAll()
        {
            return await _context.Admin.ToListAsync();
        }

        public async Task AddAdmin(Admin admin)
        {
            _context.Admin.Add(admin);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAdmin(Admin admin)
        {
            _context.Update(admin).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Admin?> DeleteAdmin(int id)
        {
            var admin = await _context.Admin.FindAsync(id);
            if (admin == null)
            {
                return null;
            }
            _context.Admin.Remove(admin);
            await _context.SaveChangesAsync();
            return admin;
        }

    }
