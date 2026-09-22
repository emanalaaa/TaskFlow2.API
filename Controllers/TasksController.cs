using Microsoft.AspNetCore.Mvc;
using TaskFlow2.API.DTOs;
using TaskFlow2.API.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace TaskFlow2.API.Controllers;

[ApiController]
[Route("api/[controller]")] // -> api/tasks
[Authorize]
public class TasksController : ControllerBase
{
    private readonly ITaskService _svc;
    public TasksController(ITaskService svc) => _svc = svc;

    // GET /api/tasks
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _svc.GetAllAsync());

    // GET /api/tasks/3
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var task = await _svc.GetByIdAsync(id);
        return task is null ? NotFound() : Ok(task);
        // NotFound() = 404, Ok() = 200
    }

    // POST /api/tasks
    [HttpPost]
    public async Task<IActionResult> Create(CreateTaskDto dto)
    {
        var task = await _svc.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById),
            new { id = task.Id }, task);  // 201 + Location header
    }

    // PUT /api/tasks/3/complete
    [HttpPut("{id}/complete")]
    public async Task<IActionResult> Complete(int id)
    {
        var found = await _svc.CompleteAsync(id);
        return found ? NoContent() : NotFound();
        // NoContent() = 204 (success, nothing to return)
    }
}

