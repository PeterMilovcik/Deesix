namespace Deesix.Domain.Entities;

public class WorldTile
{
    public int Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int WorldId { get; set; }
    public int TerrainId { get; set; }
    public int BiomeId { get; set; }

    public WorldTile(int x, int y)
    {
        X = x;
        Y = y;
    }
    
    public override bool Equals(object? obj) => 
        obj is WorldTile tile ? 
            tile.X == X && tile.Y == Y : 
            false;

    public override int GetHashCode() => HashCode.Combine(X, Y, WorldId, TerrainId, BiomeId);

    public static bool operator ==(WorldTile left, WorldTile right) => left.Equals(right);
    public static bool operator !=(WorldTile left, WorldTile right) => !(left == right);
    
    public override string ToString() => $"({X}, {Y}) Id: {Id}, WorldId: {WorldId}, TerrainId: {TerrainId}, BiomeId: {BiomeId}";
}