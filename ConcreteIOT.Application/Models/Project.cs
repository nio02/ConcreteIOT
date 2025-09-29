namespace ConcreteIOT.Application.Models;

public class Project
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Company { get; set; }
    
    public ICollection<UserProject> UserProjects { get; set; } = [];
    public ICollection<ConcreteMix> ConcreteMixes { get; set; } = [];
    public ICollection<Element> Elements { get; set; } = [];
}