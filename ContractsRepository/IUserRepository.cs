using System.Collections.Generic;
using System.Threading.Tasks;
using AmadeusAPI.Models;

namespace AmadeusAPI.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers();
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<User?> DeleteUser(int id);
        Task<User> GetUser(String email);
        Task<PagedResult<User>> GetPagedUsers(int page, int pageSize);
    }
}