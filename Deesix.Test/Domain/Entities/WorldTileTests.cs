using Deesix.Domain.Entities;

namespace Deesix.Test.Domain.Entities;

[TestFixture]
public class WorldTileTests
{
    [Test]
    public void WorldTile_Equals_ReturnsTrue_WhenTilesAreEqual()
    {
        // Arrange
        var tile1 = new WorldTile(5, 10);
        var tile2 = new WorldTile(5, 10);

        // Act
        bool result = tile1.Equals(tile2);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void WorldTile_Equals_ReturnsFalse_WhenTilesAreNotEqual()
    {
        // Arrange
        var tile1 = new WorldTile(5, 10);
        var tile2 = new WorldTile(6, 11);

        // Act
        bool result = tile1.Equals(tile2);

        // Assert
        Assert.IsFalse(result);
    }    

    [Test]
    public void WorldTile_GetHashCode_ReturnsSameValue_WhenTilesAreEqual()
    {
        // Arrange
        var tile1 = new WorldTile(5, 10);
        var tile2 = new WorldTile(5, 10);

        // Act
        int hashCode1 = tile1.GetHashCode();
        int hashCode2 = tile2.GetHashCode();

        // Assert
        Assert.That(hashCode1, Is.EqualTo(hashCode2));
    }
    
    [Test]
    public void WorldTile_GetHashCode_ReturnsDifferentValue_WhenTilesAreNotEqual()
    {
        // Arrange
        var tile1 = new WorldTile(5, 10);
        var tile2 = new WorldTile(6, 11);

        // Act
        int hashCode1 = tile1.GetHashCode();
        int hashCode2 = tile2.GetHashCode();

        // Assert
        Assert.That(hashCode1, Is.Not.EqualTo(hashCode2));
    }

    [Test]
    public void WorldTile_OperatorEquals_ReturnsTrue_WhenTilesAreEqual()
    {
        // Arrange
        var tile1 = new WorldTile(5, 10);
        var tile2 = new WorldTile(5, 10);

        // Act
        bool result = tile1 == tile2;

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void WorldTile_OperatorEquals_ReturnsFalse_WhenTilesAreNotEqual()
    {
        // Arrange
        var tile1 = new WorldTile(5, 10);
        var tile2 = new WorldTile(6, 11);

        // Act
        bool result = tile1 != tile2;

        // Assert
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void WorldTile_ToString_ReturnsStringRepresentationOfTileWithPositiveCoordinates()
    {
        // Arrange
        var tile = new WorldTile(5, 10);
        string expectedRepresentation = "(5, 10) Id: 0, WorldId: 0, TerrainId: 0, BiomeId: 0";

        // Act
        string actualRepresentation = tile.ToString();

        // Assert
        Assert.That(actualRepresentation, Is.EqualTo(expectedRepresentation));
    }

    [Test]
    public void WorldTile_ToString_ReturnsStringRepresentationOfTileWithNegativeCoordinates()
    {
        // Arrange
        var tile = new WorldTile(-5, -10);
        string expectedRepresentation = "(-5, -10) Id: 0, WorldId: 0, TerrainId: 0, BiomeId: 0";

        // Act
        string actualRepresentation = tile.ToString();

        // Assert
        Assert.That(actualRepresentation, Is.EqualTo(expectedRepresentation));
    }

    [Test]
    public void WorldTile_ToString_ReturnsStringRepresentationOfTileWithZeroCoordinates()
    {
        // Arrange
        var tile = new WorldTile(0, 0);
        string expectedRepresentation = "(0, 0) Id: 0, WorldId: 0, TerrainId: 0, BiomeId: 0";

        // Act
        string actualRepresentation = tile.ToString();

        // Assert
        Assert.That(actualRepresentation, Is.EqualTo(expectedRepresentation));
    }    
}
