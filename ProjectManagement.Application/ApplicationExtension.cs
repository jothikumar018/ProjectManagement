using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Application.Interfaces.Services;
using ProjectManagement.Application.Services;


namespace ProjectManagement.Application;

public static class ApplicationExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDataProtection();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
       
        services.AddTransient<ITenentService, TenentService>();
        services.AddTransient<ICustomerService, CustomerService>();
        services.AddTransient<IProjectService, ProjectService>();
        services.AddTransient<IEnumerationsService, EnumerationsService>();

        return services;
    }
}
