using Deesix.Domain.Entities;

namespace Deesix.Domain.Interfaces;

public interface IGenerativeAIService
{
    Task<WorldSettings> GenerateWorldSettingsAsync(CancellationToken cancellationToken = default);
}