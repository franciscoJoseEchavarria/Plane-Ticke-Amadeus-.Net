using AmadeusAPI.Interfaces;
using AmadeusAPI.Models;

namespace  AmadeusAPI.Services;
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _repository;
        public QuestionService(IQuestionRepository repository) { _repository = repository; }
        public Task<IEnumerable<Question>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Question> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task AddAsync(Question question) => _repository.AddAsync(question);
        public Task UpdateAsync(Question question) => _repository.UpdateAsync(question);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }