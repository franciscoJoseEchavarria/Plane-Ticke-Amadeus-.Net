using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmadeusAPI.Models;

namespace AmadeusAPI.Interfaces
{
    public interface IUser_answersRepository
    {

        Task<User_answers> GetUser_answer(int id);
        Task<IEnumerable<User_answers>> GetUser_answer();
        Task AddUser(User_answers user);
        Task UpdateUser(User_answers user);
        Task<User_answers?> DeleteUser(int id);

        
    }
}