using AmadeusAPI.Models;

namespace AmadeusAPI.Interfaces;

    public interface ICityRepository
    {
        Task<IEnumerable<CityModel>> GetCityAllUser();
        Task<CityModel> GetCityById(int id);
        Task AddCity(CityModel city);
        Task UpdateCity(CityModel city);
        Task<CityModel> DeleteCity(int id);
    }
