namespace ConcreteIOT.Contracts.Requests;

public class CreateUserRequest
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}