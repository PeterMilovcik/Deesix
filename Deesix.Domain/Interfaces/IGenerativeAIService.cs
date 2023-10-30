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
    public string FantasyLevel { get; set; } = "Undefined";
    public string ScifiLevel { get; set; } = "Undefined";
    public string TechLevel { get; set; } = "Undefined";
    public string MagicIntensity { get; set; } = "Undefined";
    public string MagicSource { get; set; } = "Undefined";
    public string Geography { get; set; } = "Undefined";
    public string SocietalStructure { get; set; } = "Undefined";
    public string DominantRace { get; set; } = "Undefined";
    public string DominantReligion { get; set; } = "Undefined";
    public string PoliticalSystem { get; set; } = "Undefined";
}