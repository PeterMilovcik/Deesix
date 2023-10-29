using Deesix.Data.Repositories;
using Deesix.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Deesix.Data.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        services.AddTransient<IGameRepository, GameRepository>();
        return services;
    }
}
