namespace Deesix.Domain;

public interface IGenerativeAIService
{
    Task<WorldSettings> GenerateWorldSettingsAsync(CancellationToken cancellationToken = default);
}

public class WorldSettings
{
    public string Name { get; set; } = "Undefined";
    public string Description { get; set; } = "Undefined";
    public string Theme { get; set; } = "Undefined";
}