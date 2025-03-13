using AmadeusAPI.Models;

namespace AmadeusAPI.Interfaces;

    public interface ICityService
    {
        Task<IEnumerable<CityModel>> GetCityAlluser();
        Task<CityModel> GetCityById(int id);
        Task AddCity(CityModel city);
        Task UpdateCity(CityModel city);
        Task<CityModel> DeleteCity(int id);
    }
