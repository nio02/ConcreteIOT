using ConcreteIOT.Application.Models;

namespace ConcreteIOT.Contracts.Responses;

public class UserResponse
{
    public required Guid Id { get; init; }
    public required string Email { get; init; }
}