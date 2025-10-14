using ConcreteIOT.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConcreteIOT.Application;

public static class ApplicationServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IUserProjectService, UserProjectService>();
        services.AddScoped<IDeviceService, DeviceService>();
        return services;
    }
}