using Deesix.Domain.Entities;

namespace Deesix.Test.Domain.Entities;

[TestFixture]
public class BiomeTests
{
    [Test]
    public void Biome_Defaults()
    {
        // Arrange
        var biome = new Biome();

        // Assert
        Assert.That(biome.Id, Is.EqualTo(0));
        Assert.That(biome.Name, Is.EqualTo("Unknown"));
        Assert.That(biome.Description, Is.EqualTo("Unknown"));
        Assert.That(biome.Climate, Is.EqualTo("Unknown"));
    }

    [Test]
    public void Biome_CustomValues()
    {
        // Arrange
        var biome = new Biome
        {
            Id = 1,
            Name = "Forest",
            Description = "A dense forest biome",
            Climate = "Temperate"
        };

        // Assert
        Assert.That(biome.Id, Is.EqualTo(1));
        Assert.That(biome.Name, Is.EqualTo("Forest"));
        Assert.That(biome.Description, Is.EqualTo("A dense forest biome"));
        Assert.That(biome.Climate, Is.EqualTo("Temperate"));
    }

    [Test]
    public void Biome_ToString()
    {
        // Arrange
        var biome = new Biome
        {
            Id = 1,
            Name = "Forest",
            Description = "A dense forest biome",
            Climate = "Temperate"
        };

        // Assert
        Assert.That(biome.ToString(), Is.EqualTo("Forest"));
    }

    [Test]
    public void Biome_Equals()
    {
        // Arrange
        var biome1 = new Biome
        {
            Id = 1,
            Name = "Forest",
            Description = "A dense forest biome",
            Climate = "Temperate"
        };

        var biome2 = new Biome
        {
            Id = 1,
            Name = "Forest",
            Description = "A dense forest biome",
            Climate = "Temperate"
        };

        // Assert
        Assert.That(biome1, Is.EqualTo(biome2));
    }

    [Test]
    public void Biome_GetHashCode()
    {
        // Arrange
        var biome1 = new Biome
        {
            Id = 1,
            Name = "Forest",
            Description = "A dense forest biome",
            Climate = "Temperate"
        };

        var biome2 = new Biome
        {
            Id = 1,
            Name = "Forest",
            Description = "A dense forest biome",
            Climate = "Temperate"
        };

        // Assert
        Assert.That(biome1.GetHashCode(), Is.EqualTo(biome2.GetHashCode()));
    }

    [Test]
    public void Biome_EqualsOperator()
    {
        // Arrange
        var biome1 = new Biome
        {
            Id = 1,
            Name = "Forest",
            Description = "A dense forest biome",
            Climate = "Temperate"
        };

        var biome2 = new Biome
        {
            Id = 1,
            Name = "Forest",
            Description = "A dense forest biome",
            Climate = "Temperate"
        };

        // Assert
        Assert.That(biome1 == biome2, Is.True);
    }

    [Test]
    public void Biome_NotEqualsOperator()
    {
        // Arrange
        var biome1 = new Biome
        {
            Id = 1,
            Name = "Forest",
            Description = "A dense forest biome",
            Climate = "Temperate"
        };

        var biome2 = new Biome
        {
            Id = 2,
            Name = "Desert",
            Description = "A dry desert biome",
            Climate = "Arid"
        };

        // Assert
        Assert.That(biome1 != biome2, Is.True);
    }

    [Test]
    public void Biome_Unknown()
    {
        // Arrange
        var biome = Biome.Unknown;

        // Assert
        Assert.That(biome.Id, Is.EqualTo(0));
        Assert.That(biome.Name, Is.EqualTo("Unknown"));
        Assert.That(biome.Description, Is.EqualTo("Unknown"));
        Assert.That(biome.Climate, Is.EqualTo("Unknown"));
    }
}
