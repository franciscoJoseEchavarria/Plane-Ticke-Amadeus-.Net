using AmadeusAPI.Models;

namespace AmadeusAPI.Interfaces;

public interface IQuestionOptionRepository

{
    Task<IEnumerable<QuestionOption>> GetAllAsync(); // ✅ Agregado para evitar el error
    Task<IEnumerable<QuestionOption>> GetAllByQuestionIdAsync(int questionId);
    Task<QuestionOption> GetByIdAsync(int id);
    Task AddAsync(QuestionOption option);
    Task UpdateAsync(QuestionOption option);
    Task DeleteAsync(int id);
}