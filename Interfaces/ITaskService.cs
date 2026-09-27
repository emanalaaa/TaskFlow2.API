using TaskFlow2.API.Models;
using TaskFlow2.API.DTOs;

namespace TaskFlow2.API.Interfaces;


public interface ITaskService
{
    Task<List<TaskItem>> GetAllAsync(int userId);
    Task<TaskItem?> GetByIdAsync (int id, int userId);
    Task<TaskItem> CreateAsync(CreateTaskDto dto, int userId);
    Task<bool> CompleteAsync(int id, int userId);

}