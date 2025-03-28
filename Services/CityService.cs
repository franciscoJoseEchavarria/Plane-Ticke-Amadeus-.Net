// filepath: Services/CityService.cs
using AmadeusAPI.Interfaces;
using AmadeusAPI.Models;

namespace  AmadeusAPI.Services;

    public class CityService:ICityService
    {

        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<IEnumerable<CityModel>> GetCityAlluser()
        {
            return await _cityRepository.GetCityAllUser();
        }

        public async Task<CityModel> GetCityById(int id)
        {
            return await _cityRepository.GetCityById(id);
        }

        public async Task AddCity(CityModel city)
        {
            await _cityRepository.AddCity(city);
        }

        public async Task UpdateCity(CityModel city)
        {
            await _cityRepository.UpdateCity(city);
        }
        
        public async Task<CityModel> DeleteCity(int id)
        {
            return await _cityRepository.DeleteCity(id);
        }
    }
