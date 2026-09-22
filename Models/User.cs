using System;
namespace TaskFlow2.API.Models;

public class User
{
	public User()
	{
	}

	public int Id { get; set; }
	public string Email { get; set; } = "";
	public string PasswordHash { get; set; } = "";
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
