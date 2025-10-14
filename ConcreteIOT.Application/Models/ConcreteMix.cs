namespace ConcreteIOT.Application.Models;

public class ConcreteMix
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double MixA { get; set; }
    public double MixB { get; set; }
    
    public Guid ProjectId { get; set; }
    public Project? Project { get; set; }
    
    public ICollection<Element> Elements { get; set; } = [];
}