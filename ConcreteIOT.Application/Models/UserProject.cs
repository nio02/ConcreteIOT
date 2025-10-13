namespace ConcreteIOT.Application.Models;

public class UserProject
{
    public Guid Id { get; set; }
    public ProjectRole Role { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public Guid ProjectId { get; set; }
    public Project Project { get; set; }
}

public enum ProjectRole
{
    OWNER,
    VISITOR
}