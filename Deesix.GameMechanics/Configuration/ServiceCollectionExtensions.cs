using Deesix.GameMechanics.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Deesix.GameMechanics;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGameMechanicsServices(this IServiceCollection services)
    {
        services.AddTransient<GameService>();
        return services;
    }
}
