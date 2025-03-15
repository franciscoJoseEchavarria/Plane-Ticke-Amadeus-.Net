using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AmadeusAPI.Interfaces;
using AmadeusAPI.Models;
using AmadeusAPI.Repositories;

namespace AmadeusAPI.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly DestinationRepository _destinationRepository;

        public DestinationService(DestinationRepository destinationRepository)
        {
            _destinationRepository = destinationRepository;
        }

        public async Task<Destination> GetDestinationById(int id)
        {
            return await _destinationRepository.GetDestinationById(id);
        }

        public string GetHashedArray(string[] array)
        {
            using (var sha256 = SHA256.Create())
            {
                var concatenatedString = string.Join(",", array);
                var bytes = Encoding.UTF8.GetBytes(concatenatedString);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public async Task<(int firstCityId, int secondCityId)> GetCityIdsByHash(string hash)
        {
            return await _destinationRepository.GetCityIdsByHash(hash);
        }
    }
}