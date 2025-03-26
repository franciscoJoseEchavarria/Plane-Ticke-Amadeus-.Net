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

        async Task<Admin> IAdminRepository.GetAdminById(int id)
        {
           var admin = await _context.Admin.FindAsync(id);
           if (admin == null)
           {
               throw new KeyNotFoundException($"Admin with id {id} not found.");
           }
           return admin;
        }

        async Task<IEnumerable<Admin>> IAdminRepository.GetAdminAll()
        {
            return await _context.Admin.ToListAsync();
        }

        async Task IAdminRepository.AddAdmin(Admin admin)
        {
            _context.Admin.Add(admin);
            await _context.SaveChangesAsync();
        }

        async Task IAdminRepository.UpdateAdmin(Admin admin)
        {
            _context.Update(admin).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        async Task<Admin?> IAdminRepository.DeleteAdmin(int id)
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
