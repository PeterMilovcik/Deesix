namespace Deesix.Domain.Entities;

public class Biome
{
    public int Id { get; set; }
    public string Name { get; set; } = "Unknown";
    public string Description { get; set; } = "Unknown";    
    public string Climate { get; set; } = "Unknown";

    public override string ToString() => Name;

    public override bool Equals(object? obj)
    {
        if (obj is Biome biome)
        {
            return Id == biome.Id &&
                   Name == biome.Name &&
                   Description == biome.Description &&
                   Climate == biome.Climate;
        }

        return false;
    }

    public override int GetHashCode() => HashCode.Combine(Id, Name, Description, Climate);

    public static bool operator ==(Biome? left, Biome? right) => EqualityComparer<Biome>.Default.Equals(left, right);
    public static bool operator !=(Biome? left, Biome? right) => !(left == right);

    public static Biome Unknown => new Biome();
}
