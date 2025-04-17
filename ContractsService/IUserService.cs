using AmadeusAPI.Models;

namespace AmadeusAPI.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserByEmail(string email);
        Task<User> GetUser(int id);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(int id);
        
        Task<PagedResult<User>> GetPagedUsers(int page, int pageSize);
    }
}