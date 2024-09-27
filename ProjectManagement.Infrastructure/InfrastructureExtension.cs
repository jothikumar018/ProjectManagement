using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using ProjectManagement.Application.Interfaces.Repositories.Base;
using ProjectManagement.Application.Interfaces.Security;
using ProjectManagement.Domain.Common;
using ProjectManagement.Infrastructure.Data;
using ProjectManagement.Infrastructure.Repositories.Base;
using ProjectManagement.Infrastructure.Security;


namespace ProjectManagement.Infrastructure;

public static class InfrastructureExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddPersistence(configuration)
                .AddApplicationSettings(configuration)
                .AddAuthorization()
                .AddHttpContextAccessor()
                .AddProblemDetails()
                .AddCommonServices()
                .AddAuthenticationOptions(configuration);


        services.AddIdentityApiEndpoints<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddTransient<IClaimsTransformation, CustomClaimsTransformation>();


        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, ConfigurationManager configuration)
    {
        var applicationSettings = configuration.GetSection(nameof(ApplicationSettings)).Get<ApplicationSettings>();

        services.AddDbContext<ApplicationDbContext>(Options =>
                       Options.UseSqlServer(configuration.GetConnectionString(applicationSettings!.DatabaseSettings.ConnectionString)));

        services.AddTransient<IUnitOfWork, UnitOfWork>();

        return services;
    }

    private static IServiceCollection AddCommonServices(this IServiceCollection services)
    {
        services.AddExceptionHandler<GlobalExceptionHandler>();

        services.AddScoped<ICurrentUserService, CurrentUserService>();

        return services;

    }

    private static IServiceCollection AddApplicationSettings(this IServiceCollection services, ConfigurationManager configuration)
    {
        var applicationSettings = configuration.GetSection(nameof(ApplicationSettings)).Get<ApplicationSettings>();
        services.Configure<ApplicationSettings>(options => configuration.GetSection(nameof(ApplicationSettings)).Bind(options));
        services.AddSingleton<ApplicationSettings>(x => x.GetRequiredService<IOptions<ApplicationSettings>>().Value);

        return services;
    }
    private static IServiceCollection AddAuthenticationOptions(this IServiceCollection service, ConfigurationManager configuration)
    {
        service.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Project Management API", Version = "v1" });
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "bearer"
            });

            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new string[]{}
                }
            });
        });

        service.AddAuthentication()
               .AddBearerToken();

        return service;
    }
}
