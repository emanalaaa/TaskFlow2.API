using Microsoft.EntityFrameworkCore;
using TaskFlow2.API.Data;
using TaskFlow2.API.Interfaces;
using TaskFlow2.API.Models;
using TaskFlow2.API.DTOs;

namespace TaskFlow2.API.Services;
public class TaskService : ITaskService //service implemints the contract
{
    private readonly AppDbContext _db;
    public TaskService(AppDbContext db) => _db = db;
    
    public async Task<List<TaskItem>> GetAllAsync()=>
        await _db.Tasks.ToListAsync();

    public async Task<TaskItem?> GetByIdAsync(int id)
      => await _db.Tasks.FindAsync(id);  // returns null if not found

    public async Task<TaskItem> CreateAsync(CreateTaskDto dto)
    {
        var task = new TaskItem
        {
            Title = dto.Title,
            Description = dto.Description,
            CreatedAt = DateTime.UtcNow
        };
        _db.Tasks.Add(task);
        await _db.SaveChangesAsync();
        return task;
    }

    public async Task<bool> CompleteAsync(int id)
    {
        var task = await _db.Tasks.FindAsync(id);
        if (task is null) return false;  // task not found

        task.IsCompleted = true;
        await _db.SaveChangesAsync();
        return true;
    }
}