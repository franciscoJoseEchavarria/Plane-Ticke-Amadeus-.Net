using AmadeusAPI.Interfaces;
using AmadeusAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AmadeusAPI.Controllers;

[ApiController]
[Route("api/questions")]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService _service;
    public QuestionController(IQuestionService service) { _service = service; }
    
    [HttpGet] 
    [AllowAnonymous] // Change this to allow anonymous access
    public async Task<IActionResult> GetAll()
    {
        try 
        {
            var questions = await _service.GetAllAsync();
            return Ok(questions);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error fetching questions", error = ex.Message });
        }
    }
    
    [HttpGet("{id}")]
     public async Task<IActionResult> Get(int id) 
     => Ok(await _service.GetByIdAsync(id));
    
    [HttpPost] 
    public async Task<IActionResult> Create([FromBody] Question question) 
    { await _service.AddAsync(question);
     return Ok(); }
    
    [HttpPut] 
    public async Task<IActionResult> Update([FromBody] Question question)
     { await _service.UpdateAsync(question);
      return Ok(); }
    
    [HttpDelete("{id}")] 
    public async Task<IActionResult> Delete(int id) 
    { await _service.DeleteAsync(id); 
    return Ok(); }
}