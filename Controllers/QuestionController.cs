using AmadeusAPI.Interfaces;
using AmadeusAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmadeusAPI.Controllers;

[ApiController]
[Route("api/questions")]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService _service;
    public QuestionController(IQuestionService service) { _service = service; }
    [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
    [HttpGet("{id}")] public async Task<IActionResult> Get(int id) => Ok(await _service.GetByIdAsync(id));
    [HttpPost] public async Task<IActionResult> Create([FromBody] Question question) { await _service.AddAsync(question); return Ok(); }
    [HttpPut] public async Task<IActionResult> Update([FromBody] Question question) { await _service.UpdateAsync(question); return Ok(); }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) { await _service.DeleteAsync(id); return Ok(); }
}