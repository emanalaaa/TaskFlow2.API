using Microsoft.EntityFrameworkCore;
using TaskFlow2.API.Models;

namespace TaskFlow2.API.Data;
public class AppDbContext :DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }
	
// This property = the "Tasks" table in your database
    // _db.Tasks.ToList() → SELECT * FROM Tasks
    // _db.Tasks.Add(x)   → INSERT INTO Tasks
    public DbSet<TaskItem> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
}