﻿namespace BuildingBlocks.Messaging.MassTransit
{
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;
    using global::MassTransit;
    using Microsoft.Extensions.Configuration;

    public static class Extensions
    {
        public static IServiceCollection AddMessageBroker
            (this IServiceCollection services, IConfiguration configuration, Assembly? assembly = null)
        {
            services.AddMassTransit(config =>
            {
                config.SetKebabCaseEndpointNameFormatter();

                if (assembly != null)
                    config.AddConsumers(assembly);

                config.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(new Uri(configuration["MessageBroker:Host"]!), host =>
                    {
                        host.Username(configuration["MessageBroker:UserName"]);
                        host.Password(configuration["MessageBroker:Password"]);
                    });
                    configurator.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}
