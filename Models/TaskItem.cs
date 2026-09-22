namespace TaskFlow2.API.Models;

public class TaskItem
{
    public int Id { get; set; }          // PRIMARY KEY — EF Core detects "Id" automatically
    public string Title { get; set; } = "";
    public string? Description { get; set; }  // ? means nullable (optional field)
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}


//how efcore knew that id is detected  automatically
//what is opional field
//public string Title { get; set; } = "";