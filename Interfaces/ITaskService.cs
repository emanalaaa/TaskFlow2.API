using TaskFlow2.API.Models;
using TaskFlow2.API.DTOs;

namespace TaskFlow2.API.Interfaces;


public interface ITaskService
{
    Task<List<TaskItem>> GetAllAsync();
    Task<TaskItem?> GetByIdAsync (int id);
    Task<TaskItem> CreateAsync(CreateTaskDto dto);
    Task<bool> CompleteAsync(int id);

}