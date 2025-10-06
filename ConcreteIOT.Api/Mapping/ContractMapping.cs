using ConcreteIOT.Application.Models;
using ConcreteIOT.Contracts.Requests;
using ConcreteIOT.Contracts.Responses;

namespace ConcreteIOT.Api.Mapping;

public static class ContractMapping
{
    public static User MapToUser(this CreateUserRequest request)
    {
        return new User
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            Password = request.Password,
            Role = Role.CLIENT
        };
    }

    public static UserResponse MapToResponse(this User user)
    {
        return new UserResponse
        {
            Id = user.Id,
            Email = user.Email
        };
    }
}