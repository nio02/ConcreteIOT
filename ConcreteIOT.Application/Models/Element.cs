namespace ConcreteIOT.Application.Models;

public class Element
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public Guid ProjectId { get; set; }
    public required Project Project { get; set; }
    
    public Guid ConcreteMixId { get; set; }
    public required ConcreteMix ConcreteMix { get; set; }
    
    public ICollection<DataSet> DataSets { get; set; } = [];
}