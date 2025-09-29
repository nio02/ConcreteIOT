namespace ConcreteIOT.Application.Models;

public class UserProject
{
    public Guid Id { get; set; }
    public ProjectRole Role { get; set; }
    
    public Guid UserId { get; set; }
    public required User User { get; set; }
    
    public Guid ProjectId { get; set; }
    public required Project Project { get; set; }
}

public enum ProjectRole
{
    OWNER,
    VISITOR
}