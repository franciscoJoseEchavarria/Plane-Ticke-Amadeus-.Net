using AmadeusAPI.Interfaces;
using AmadeusAPI.Models;
using AmadeusAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AmadeusAPI.Repositories;

public class DestinationRepository : IDestinationRepository
{
    private readonly AmadeusAPIDbContext _context;

    public DestinationRepository(AmadeusAPIDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Destination>> GetAllDestinations()
    {
        return await _context.Destinations.ToListAsync();
    }

    public async Task<Destination> GetDestinationById(int id)
    {
        var destination = await _context.Destinations.FindAsync(id);
        if (destination == null)
        {
            throw new Exception($"Destination with id {id} not found.");
        }
        return destination;
    }

    public async Task<Destination> AddDestination(Destination destination)
    {
        await _context.Destinations.AddAsync(destination);
        await _context.SaveChangesAsync();
        return destination;
    }

    public async Task<Destination> UpdateDestination(Destination destination)
    {
        _context.Destinations.Update(destination);
        await _context.SaveChangesAsync();
        return destination;
    }

    public async Task<Destination?> DeleteDestination(int id)
    {
        var destination = await _context.Destinations.FindAsync(id);
        if (destination != null)
        {
            _context.Set<Destination>().Remove(destination);
            await _context.SaveChangesAsync();
            return destination;
        }
        return null;
    }

    public async Task<(CityModel firstCity, CityModel secondCity)> GetCitiesByHash(string hash)
    {
        var cities = await _context.City
            .Where(c => c.CityHash == hash)
            .ToListAsync();

        if (cities.Count() == 0)
        {
            var defaultCity1 = await _context.City.FindAsync(39);
            var defaultCity2 = await _context.City.FindAsync(40);

            if (defaultCity1 == null || defaultCity2 == null)
            {
                throw new Exception("Default cities not found.");
            }
            
            return (defaultCity1, defaultCity2);
        }

        return (cities[0], cities[1]);
    }
}
