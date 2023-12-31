namespace Deesix.Domain.Entities;

public class Terrain
{
    public int Id { get; set; }
    public string Name { get; set; } = "Unknown";
    public string Description { get; set; } = "Unknown";
    public float MovementModifier { get; set; } = 1.0f;

    public override string ToString() => Name;

    public override bool Equals(object? obj)
    {
        if (obj is Terrain terrain)
        {
            return Id == terrain.Id &&
                   Name == terrain.Name &&
                   Description == terrain.Description &&
                   MovementModifier == terrain.MovementModifier;
        }

        return false;
    }

    public override int GetHashCode() => HashCode.Combine(Id, Name, Description, MovementModifier);

    public static bool operator ==(Terrain? left, Terrain? right) => EqualityComparer<Terrain>.Default.Equals(left, right);
    public static bool operator !=(Terrain? left, Terrain? right) => !(left == right);

    public static Terrain Unknown => new Terrain();    
}
