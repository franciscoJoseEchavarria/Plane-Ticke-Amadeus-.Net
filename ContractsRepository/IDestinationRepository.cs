using AmadeusAPI.Models;

namespace AmadeusAPI.Interfaces;

public interface IDestinationRepository
{
    Task<IEnumerable<Destination>> GetAllDestinations();
    Task<Destination> GetDestinationById(int id);

    Task<Destination> AddDestination(Destination destination);
    Task<Destination> UpdateDestination(Destination destination);
    Task<Destination> DeleteDestination(int id);
    Task<(int firstCityId, int secondCityId)> GetCityIdsByHash(string hash);
}
