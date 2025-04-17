
using AmadeusAPI.Interfaces;
using AmadeusAPI.Models;
using AmadeusAPI.Repositories;

namespace AmadeusAPI.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository _destinationRepository;

        public DestinationService(IDestinationRepository destinationRepository)
        {
            _destinationRepository = destinationRepository;
        }

        public async Task<Destination> GetDestinationById(int id)
        {
            return await _destinationRepository.GetDestinationById(id);
        }

        public async Task<(CityModel firstCity, CityModel secondCity)> GetCitiesByHash(string hash)
        {
            return await _destinationRepository.GetCitiesByHash(hash);
        }
    }
}