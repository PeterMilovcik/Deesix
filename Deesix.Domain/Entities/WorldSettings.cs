namespace Deesix.Domain.Entities;

public class WorldSettings
{
    public string Name { get; set; } = "Undefined";
    public string Description { get; set; } = "Undefined";
    public string Theme { get; set; } = "Undefined";

    public override string ToString() => $"Name: {Name}, Description: {Description}, Theme: {Theme}";
}