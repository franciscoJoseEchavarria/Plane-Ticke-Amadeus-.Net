using AmadeusAPI.Interfaces;
using AmadeusAPI.Models;
using Microsoft.EntityFrameworkCore;
using AmadeusAPI.Data;

namespace AmadeusAPI.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AmadeusAPIDbContext _context;

        public QuestionRepository(AmadeusAPIDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await _context.Question.Include(q => q.Options).ToListAsync();
        }

        public async Task<Question> GetByIdAsync(int id)
        {
            return await _context.Question.Include(q => q.Options).FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task AddAsync(Question question)
        {
            _context.Question.Add(question);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Question question)
        {
            _context.Question.Update(question);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var question = await _context.Question.FindAsync(id);
            if (question != null)
            {
                _context.Question.Remove(question);
                await _context.SaveChangesAsync();
            }
        }
    }
}
