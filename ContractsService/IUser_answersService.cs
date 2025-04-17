using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmadeusAPI.Models;

namespace AmadeusAPI.Interfaces
{
    public interface IUser_answersService
    {
        Task<IEnumerable<User_answers>> GetUsers();
       
        Task<User_answers> GetUser(int id);
        Task  AddUser(User_answers user);
        Task  UpdateUser(User_answers user);
        Task<User_answers> DeleteUser(int id);
        Task<IEnumerable<User_answers>> GetUserAnswersByUserId(int userId);
    }
}
