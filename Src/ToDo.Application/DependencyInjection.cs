using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SLA.Application.Abstractions.Behaviors;
using SLA.Application.Behaviors;
using System.Reflection;


namespace ToDo.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationStrapping(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(AssemblyReference.Assembly);

            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));

            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddAutoMapper(Assembly.GetExecutingAssembly());


        services.AddValidatorsFromAssembly(
            AssemblyReference.Assembly,
            includeInternalTypes: true);

        return services;
    }


}
