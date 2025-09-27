namespace ConcreteIOT.Application.Models;

public class DataSet
{
    public Guid Id { get; set; }
    public DateTime DateTime { get; set; }
    public double TempCore { get; set; }
    public double TempSurf { get; set; }
    public double DeltaTime { get; set; }
}