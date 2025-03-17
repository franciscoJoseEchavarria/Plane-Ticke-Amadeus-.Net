using AmadeusAPI.Interfaces;
using AmadeusAPI.Models;

    public class QuestionOptionService : IQuestionOptionService
    {
        private readonly IQuestionOptionRepository _repository;
        public QuestionOptionService(IQuestionOptionRepository repository) { _repository = repository; }
        public Task<IEnumerable<QuestionOption>> GetAllByQuestionIdAsync(int questionId) => _repository.GetAllByQuestionIdAsync(questionId);
        public Task<QuestionOption> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task AddAsync(QuestionOption option) => _repository.AddAsync(option);
        public Task UpdateAsync(QuestionOption option) => _repository.UpdateAsync(option);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }