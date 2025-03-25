using AmadeusAPI.Interfaces;
using AmadeusAPI.Data;
using Microsoft.EntityFrameworkCore;
using AmadeusAPI.Models;

namespace AmadeusAPI.Models;

    public class User_answersRepository : IUser_answersRepository
    {
        private readonly AmadeusAPIDbContext _context;

        public User_answersRepository(AmadeusAPIDbContext context)
        {
            _context = context;
        }

        public async Task<User_answers> GetUser_answer(int id)
        {
            var userAnswer = await _context.User_answers.FindAsync(id);
          
            if (userAnswer == null)
            {
                throw new KeyNotFoundException($"User with id {id} not found.");
            }
            return userAnswer;
        }

        public async Task<IEnumerable<User_answers>> GetUserAnswersByUserId(int userId)
        {
            return await _context.User_answers
                        .Where(ua => ua.User_id == userId)
                        .ToListAsync();
        }

        public async Task<IEnumerable<User_answers>> GetUser_answer()
        {
            return await _context.User_answers.ToListAsync();
        }



        public async Task  AddUser(User_answers user)
        {
            _context.User_answers.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task  UpdateUser(User_answers user)
        {
            _context.Update(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
    
        }

        public async Task<User_answers?> DeleteUser(int id)
        {
            var user = await _context.User_answers.FindAsync(id);
            if (user == null)
            {
                return null;
            }

            _context.User_answers.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }