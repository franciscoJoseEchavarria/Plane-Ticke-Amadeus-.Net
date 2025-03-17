using AmadeusAPI.Interfaces;
using AmadeusAPI.Data;
using Microsoft.EntityFrameworkCore;
using AmadeusAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmadeusAPI.Repositories;

    public class CityRepository : ICityRepository
    {
        private readonly AmadeusAPIDbContext _context;
        
        public CityRepository(AmadeusAPIDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CityModel>> GetCityAllUser()
        {
            return await _context.City.ToListAsync();
        }

        public async Task<CityModel> GetCityById(int id)
        {
            return await _context.City.FindAsync(id) ?? throw new KeyNotFoundException($"City with id {id} not found.");
        }

        public async Task AddCity(CityModel city)
        {
            await _context.City.AddAsync(city);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCity(CityModel city)
        {
            _context.City.Update(city);
            await _context.SaveChangesAsync();
        }

        public async Task<CityModel> DeleteCity(int id)
        {
            var city = await _context.City.FindAsync(id);
            if (city != null)
            {
                _context.City.Remove(city);
                await _context.SaveChangesAsync();
            }
            return city ?? throw new KeyNotFoundException($"City with id {id} not found.");
        }
    }

