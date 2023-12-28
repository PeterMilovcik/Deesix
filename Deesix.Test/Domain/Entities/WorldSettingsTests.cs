using Deesix.Domain.Entities;

namespace Deesix.Test.Domain.Entities;

[TestFixture]
public class WorldSettingsTests
{
    [Test]
    public void Properties_SetAndGetValues_CorrectValuesRetrieved()
    {
        var worldSettings = new WorldSettings
        {
            Id = 1,
            GameId = 2,
            Name = "Test World",
            Description = "A world for testing",
            Theme = "Fantasy"
        };

        Assert.That(worldSettings.Id, Is.EqualTo(1), "Id property not set correctly.");
        Assert.That(worldSettings.GameId, Is.EqualTo(2), "GameId property not set correctly.");
        Assert.That(worldSettings.Name, Is.EqualTo("Test World"), "Name property not set correctly.");
        Assert.That(worldSettings.Description, Is.EqualTo("A world for testing"), "Description property not set correctly.");
        Assert.That(worldSettings.Theme, Is.EqualTo("Fantasy"), "Theme property not set correctly.");
    }

    [Test]
    public void ToString_Override_ReturnsCorrectString()
    {
        var worldSettings = new WorldSettings
        {
            Id = 1,
            GameId = 2,
            Name = "Test World",
            Description = "A world for testing",
            Theme = "Fantasy"
        };

        string expected = "Id: 1, GameId: 2, Name: Test World, Description: A world for testing, Theme: Fantasy, ImageUrl: https://via.placeholder.com/256";
        Assert.That(worldSettings.ToString(), Is.EqualTo(expected), "ToString method did not return the correct string.");
    }

    [Test]
    public void Equals_CorrectComparison_TrueForEqualObjects()
    {
        var worldSettings1 = new WorldSettings
        {
            Id = 1,
            GameId = 2,
            Name = "Test World",
            Description = "A world for testing",
            Theme = "Fantasy"
        };
        var worldSettings2 = new WorldSettings
        {
            Id = 1,
            GameId = 2,
            Name = "Test World",
            Description = "A world for testing",
            Theme = "Fantasy"
        };

        Assert.That(worldSettings1.Equals(worldSettings2), Is.True, "Equals method did not return true for equal objects.");
    }

    [Test]
    public void Equals_CorrectComparison_FalseForUnequalObjects()
    {
        var worldSettings1 = new WorldSettings
        {
            Id = 1,
            GameId = 2,
            Name = "Test World",
            Description = "A world for testing",
            Theme = "Fantasy"
        };
        var worldSettings2 = new WorldSettings
        {
            Id = 2,
            GameId = 3,
            Name = "Different World",
            Description = "A different world for testing",
            Theme = "Sci-Fi"
        };

        Assert.That(worldSettings1.Equals(worldSettings2), Is.False, "Equals method did not return false for unequal objects.");
    }

    [Test]
    public void GetHashCode_ConsistentHashCodesForEqualObjects_HashCodesAreEqual()
    {
        var worldSettings1 = new WorldSettings
        {
            Id = 1,
            GameId = 2,
            Name = "Test World",
            Description = "A world for testing",
            Theme = "Fantasy"
        };
        var worldSettings2 = new WorldSettings
        {
            Id = 1,
            GameId = 2,
            Name = "Test World",
            Description = "A world for testing",
            Theme = "Fantasy"
        };

        Assert.That(worldSettings1.GetHashCode(), Is.EqualTo(worldSettings2.GetHashCode()), "GetHashCode did not return equal hash codes for equal objects.");
    }
}
