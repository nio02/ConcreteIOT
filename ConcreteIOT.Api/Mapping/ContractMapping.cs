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
    //Just for development
    public static Project MapToProject(this CreateProjectRequest request)
    {
        return new Project
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Company = request.Company
        };
    }

    public static ProjectResponse MapToResponse(this Project project)
    {
        return new ProjectResponse
        {
            Name = project.Name,
            Company = project.Company
        };
    }

    public static ConcreteMix MapToConcreteMix(this CreateConcreteMixRequest request)
    {
        return new ConcreteMix
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            MixA = request.MixA,
            MixB = request.MixB
        };
    }

    public static ConcreteMixResponse MapToResponse(this ConcreteMix mix)
    {
        return new ConcreteMixResponse
        {
            Id = mix.Id,
            Name = mix.Name,
            MixA = mix.MixA,
            MixB = mix.MixB
        };
    }
}