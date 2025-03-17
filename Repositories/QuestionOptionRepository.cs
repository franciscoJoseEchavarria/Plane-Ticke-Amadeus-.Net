using AmadeusAPI.Interfaces;
using AmadeusAPI.Models;
using Microsoft.EntityFrameworkCore;
using AmadeusAPI.Data;

namespace AmadeusAPI.Repositories
{
    public class QuestionOptionRepository : IQuestionOptionRepository
    {
        private readonly AmadeusAPIDbContext _context;

        public QuestionOptionRepository(AmadeusAPIDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<QuestionOption>> GetAllAsync()
        {
            return await _context.QuestionOption.AsNoTracking() 
        .ToListAsync();
        }

        public async Task<IEnumerable<QuestionOption>> GetAllByQuestionIdAsync(int questionId)
        {
            return await _context.QuestionOption.Where(qo => qo.QuestionId == questionId)
        .AsNoTracking()
        .ToListAsync();
        }

        public async Task<QuestionOption> GetByIdAsync(int id)
        {
            return await _context.QuestionOption.FindAsync(id);
        }

        public async Task AddAsync(QuestionOption option)
        {
            _context.QuestionOption.Add(option);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(QuestionOption option)
        {
            _context.QuestionOption.Update(option);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var option = await _context.QuestionOption.FindAsync(id);
            if (option != null)
            {
                _context.QuestionOption.Remove(option);
                await _context.SaveChangesAsync();
            }
        }
    }
}
