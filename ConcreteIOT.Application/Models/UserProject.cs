namespace ConcreteIOT.Application.Models;

public class UserProject
{
    public Guid Id { get; set; }
    public ProjectRole Role { get; set; }
}

public enum ProjectRole
{
    OWNER,
    VISITOR
}