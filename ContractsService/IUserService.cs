using System.Collections.Generic;
using System.Threading.Tasks;
using AmadeusAPI.Models;
namespace AmadeusAPI.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers();
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(int id);
    }
}