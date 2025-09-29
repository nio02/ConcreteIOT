namespace ConcreteIOT.Application.Models;

public class Device
{
    public Guid Id { get; set; }
    public string Serial { get; set; }
    
    public ICollection<DataSet> DataSets { get; set; } = [];
}