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
    [Authorize(Roles = "User,Admin")]
    public async Task<IActionResult> GetAll()
     => Ok(await _service.GetAllAsync());
    
    [HttpGet("{id}")]
    [Authorize(Roles = "User,Admin")]
     public async Task<IActionResult> Get(int id) 
     => Ok(await _service.GetByIdAsync(id));
    
    [HttpPost] 
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] Question question) 
    { await _service.AddAsync(question);
     return Ok(); }
    
    [HttpPut] 
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update([FromBody] Question question)
     { await _service.UpdateAsync(question);
      return Ok(); }
    
    [HttpDelete("{id}")] 
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id) 
    { await _service.DeleteAsync(id); 
    return Ok(); }
}