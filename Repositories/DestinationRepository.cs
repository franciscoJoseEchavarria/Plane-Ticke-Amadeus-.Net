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
        return await _context.Destinations.FindAsync(id);
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

    public async Task<Destination> DeleteDestination(int id)
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

    public async Task<(int firstCityId, int secondCityId)> GetCityIdsByHash(string hash)
    {
        var cities = await _context.City
            .Where(c => c.Hash == hash)
            .Select(c => c.Id)
            .ToListAsync();

        if (cities.Count() != 2)
        {
            throw new Exception("There should be exactly two cities with the given hash.");
        }

        return (cities[0], cities[1]);
    }
}
