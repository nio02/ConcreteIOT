namespace ConcreteIOT.Contracts.Requests;

public class CreateProjectRequest
{
    public required string Name { get; set; } 
    public string? Company { get; set; }
    //Just for Development
    public required Guid userId { get; set; }
}