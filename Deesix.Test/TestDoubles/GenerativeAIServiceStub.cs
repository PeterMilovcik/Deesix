using Deesix.Domain.Entities;
using Deesix.Domain.Interfaces;

namespace Deesix.Test.TestDoubles;
public class GenerativeAIServiceStub : IGenerativeAIService
{
    public Task<WorldSettings> GenerateWorldSettingsAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new TestWorldSettings() as WorldSettings);
    }
}