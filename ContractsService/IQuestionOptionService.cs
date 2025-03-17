using AmadeusAPI.Models;

namespace AmadeusAPI.Interfaces;

public interface IQuestionOptionService
{
    Task<IEnumerable<QuestionOption>> GetAllByQuestionIdAsync(int questionId);
    Task<QuestionOption> GetByIdAsync(int id);
    Task AddAsync(QuestionOption option);
    Task UpdateAsync(QuestionOption option);
    Task DeleteAsync(int id);
}
