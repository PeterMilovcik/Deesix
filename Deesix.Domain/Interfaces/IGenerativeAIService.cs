using Deesix.Domain.Entities;

namespace Deesix.Domain;

public interface IGenerativeAIService
{
    Task<WorldSettings> GenerateWorldSettingsAsync(CancellationToken cancellationToken = default);
}