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
   
    public async Task<List<TaskItem>> GetAllAsync(int userId) =>
    await _db.Tasks.Where(t => t.UserId == userId).ToListAsync();

    public async Task<TaskItem?> GetByIdAsync(int id, int userId) =>
    await _db.Tasks.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);  // returns null if not found

    public async Task<TaskItem> CreateAsync(CreateTaskDto dto, int userId)
    {
        var task = new TaskItem
        {
            Title = dto.Title,
            Description = dto.Description,
            UserId = userId,  // —»ÿ «· «”ﬂ »«·‹ user
            CreatedAt = DateTime.UtcNow
        };
        _db.Tasks.Add(task);
        await _db.SaveChangesAsync();
        return task;
    }

    public async Task<bool> CompleteAsync(int id, int userId)
    {
        var task = await _db.Tasks.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
        if (task is null) return false;  // task not found

        task.IsCompleted = true;
        await _db.SaveChangesAsync();
        return true;
    }
}