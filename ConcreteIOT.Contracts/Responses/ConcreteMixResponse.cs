namespace ConcreteIOT.Contracts.Responses;

public class ConcreteMixResponse
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public double MixA { get; set; }
    public double MixB { get; set; }
}