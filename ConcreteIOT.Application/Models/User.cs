namespace ConcreteIOT.Application.Models;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public required Role Role { get; set; }
    
    public ICollection<UserProject> UserProjects { get; set; } = [];
}

public enum Role
{
    CLIENT,
    ADMIN
}