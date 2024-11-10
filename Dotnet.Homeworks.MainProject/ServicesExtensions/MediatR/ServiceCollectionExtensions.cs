using Dotnet.Homeworks.Features.Helpers;

namespace Dotnet.Homeworks.MainProject.ServicesExtensions.MediatR
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediatRDefault(this IServiceCollection services) 
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(AssemblyReference.Assembly);
            });

            return services;
        }
    }
}
