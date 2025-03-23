using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmadeusAPI.Models;

namespace AmadeusAPI.Interfaces
{
    public interface IUser_answers
    {

        Task<User_answers> GetUser(int id);
        Task<IEnumerable<User_answers>> GetUsers();
        Task<User_answers> AddUser(User user);
        Task<User_answers> UpdateUser(User user);
        Task<User_answers?> DeleteUser(int id);

        
    }
}