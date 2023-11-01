namespace Deesix.Domain.Entities;

public class Game
{
    public int Id { get; set; }
    public WorldSettings WorldSettings { get; set; } = new WorldSettings();
}
