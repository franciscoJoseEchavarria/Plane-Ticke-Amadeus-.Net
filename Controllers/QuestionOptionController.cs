using AmadeusAPI.Interfaces;
using AmadeusAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmadeusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionOptionController : ControllerBase
    {
        private readonly IQuestionOptionRepository _questionOptionRepository;

        public QuestionOptionController(IQuestionOptionRepository questionOptionRepository)
        {
            _questionOptionRepository = questionOptionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionOption>>> GetAll()
        {
            var options = await _questionOptionRepository.GetAllAsync();
            return Ok(options);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionOption>> GetById(int id)
        {
            var option = await _questionOptionRepository.GetByIdAsync(id);
            if (option == null)
                return NotFound();
            return Ok(option);
        }

        [HttpGet("question/{questionId}")]
        public async Task<ActionResult<IEnumerable<QuestionOption>>> GetByQuestionId(int questionId)
        {
            var options = await _questionOptionRepository.GetAllByQuestionIdAsync(questionId);
            return Ok(options);
        }

        [HttpPost]
        public async Task<ActionResult> Create(QuestionOption option)
        {
            await _questionOptionRepository.AddAsync(option);
            return CreatedAtAction(nameof(GetById), new { id = option.Id }, option);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, QuestionOption option)
        {
            if (id != option.Id)
                return BadRequest();
            
            await _questionOptionRepository.UpdateAsync(option);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _questionOptionRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}