namespace Deesix.Domain.Entities;

public class WorldSettings : IEquatable<WorldSettings>
{
    public int Id { get; set; }
    public int GameId { get; set; }
    public string Name { get; set; } = "Undefined";
    public string Description { get; set; } = "Undefined";
    public string Theme { get; set; } = "Undefined";
    public string ImageUrl { get; set; } = "https://via.placeholder.com/256";
    public int Seed { get; set; }
    public int Regions { get; set; }

    public override string ToString() => 
        $"Id: {Id}, GameId: {GameId}, Name: {Name}, Description: {Description}, Theme: {Theme}, ImageUrl: {ImageUrl}, Seed: {Seed}, Regions: {Regions}";
    public override bool Equals(object? obj) => Equals(obj as WorldSettings);
    public bool Equals(WorldSettings? other) => 
        other != null && 
        Id == other.Id &&
        GameId == other.GameId &&
        Name == other.Name && 
        Description == other.Description && 
        Theme == other.Theme &&
        ImageUrl == other.ImageUrl &&
        Seed == other.Seed &&
        Regions == other.Regions;

    public override int GetHashCode() => HashCode.Combine(Id, GameId, Name, Description, Theme, ImageUrl, Seed, Regions);
}