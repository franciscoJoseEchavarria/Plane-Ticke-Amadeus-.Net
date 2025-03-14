using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AmadeusAPI.Models;
using AmadeusAPI.Repositories;

namespace AmadeusAPI.Services
{
    public class DestinationService
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

        public string GetHashedId(int id)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(id.ToString()));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}