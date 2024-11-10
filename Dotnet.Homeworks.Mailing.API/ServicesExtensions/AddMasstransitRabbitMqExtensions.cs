using Dotnet.Homeworks.Mailing.API.Configuration;
using Dotnet.Homeworks.Mailing.API.Consumers;
using MassTransit;

namespace Dotnet.Homeworks.Mailing.API.ServicesExtensions;

public static class AddMasstransitRabbitMqExtensions
{
    public static IServiceCollection AddMasstransitRabbitMq(this IServiceCollection services,
        RabbitMqConfig rabbitConfiguration)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<EmailConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
                cfg.Host(rabbitConfiguration.Hostname, 5672, "/", h =>
                {
                    h.Username(rabbitConfiguration.Username);
                    h.Password(rabbitConfiguration.Password);
                });
            });
        });

        return services;
    }
}