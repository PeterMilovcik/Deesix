using Deesix.Domain.Interfaces;
using Deesix.Web.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Deesix.Test;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTestServices(this IServiceCollection services)
    {
        services.AddTransient<IGameRepository, GameRepositoryStub>();
        services.AddTransient<GameController>();
        services.AddLogging(config => config.AddConsole());
        return services;
    }
}
