using Deesix.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Deesix.AI.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAIServices(this IServiceCollection services)
    {
        var openAiKey = Environment.GetEnvironmentVariable("OPEN_AI_KEY") ?? string.Empty;
        services.AddScoped<IGenerativeAIService>(provider => new GenerativeAIService(openAiKey));
        return services;
    }
}
