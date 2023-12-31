using Deesix.Domain.Entities;

namespace Deesix.Test.Domain.Entities
{
    [TestFixture]
    public class TerrainTests
    {
        [Test]
        public void Terrain_Defaults()
        {
            var terrain = new Terrain();

            Assert.That(terrain.Id, Is.EqualTo(0));
            Assert.That(terrain.Name, Is.EqualTo("Unknown"));
            Assert.That(terrain.Description, Is.EqualTo("Unknown"));
            Assert.That(terrain.MovementModifier, Is.EqualTo(1.0f));
        }

        [Test]
        public void Terrain_SetValues()
        {
            var terrain = new Terrain
            {
                Id = 1,
                Name = "Grass",
                Description = "Grassy",
                MovementModifier = 1.5f
            };

            Assert.That(terrain.Id, Is.EqualTo(1));
            Assert.That(terrain.Name, Is.EqualTo("Grass"));
            Assert.That(terrain.Description, Is.EqualTo("Grassy"));
            Assert.That(terrain.MovementModifier, Is.EqualTo(1.5f));
        }

        [Test]
        public void Terrain_ToString()
        {
            var terrain = new Terrain
            {
                Id = 1,
                Name = "Grass",
                Description = "Grassy",
                MovementModifier = 1.5f
            };

            Assert.That(terrain.ToString(), Is.EqualTo("Grass"));
        }
        
        [Test]
        public void Terrain_Equals()
        {
            var terrain1 = new Terrain
            {
                Id = 1,
                Name = "Grass",
                Description = "Grassy",
                MovementModifier = 1.5f
            };

            var terrain2 = new Terrain
            {
                Id = 1,
                Name = "Grass",
                Description = "Grassy",
                MovementModifier = 1.5f
            };

            Assert.That(terrain1.Equals(terrain2), Is.True);
        }

        [Test]
        public void Terrain_GetHashCode()
        {
            var terrain1 = new Terrain
            {
                Id = 1,
                Name = "Grass",
                Description = "Grassy",
                MovementModifier = 1.5f
            };

            var terrain2 = new Terrain
            {
                Id = 1,
                Name = "Grass",
                Description = "Grassy",
                MovementModifier = 1.5f
            };

            Assert.That(terrain1.GetHashCode(), Is.EqualTo(terrain2.GetHashCode()));
        }

        [Test]
        public void Terrain_OperatorEquals()
        {
            var terrain1 = new Terrain
            {
                Id = 1,
                Name = "Grass",
                Description = "Grassy",
                MovementModifier = 1.5f
            };

            var terrain2 = new Terrain
            {
                Id = 1,
                Name = "Grass",
                Description = "Grassy",
                MovementModifier = 1.5f
            };

            Assert.That(terrain1 == terrain2, Is.True);
        }

        [Test]
        public void Terrain_OperatorNotEquals()
        {
            var terrain1 = new Terrain
            {
                Id = 1,
                Name = "Grass",
                Description = "Grassy",
                MovementModifier = 1.5f
            };

            var terrain2 = new Terrain
            {
                Id = 2,
                Name = "Grass",
                Description = "Grassy",
                MovementModifier = 1.5f
            };

            Assert.That(terrain1 != terrain2, Is.True);
        }

        [Test]
        public void Terrain_Unknown()
        {
            var terrain = Terrain.Unknown;

            Assert.That(terrain.Id, Is.EqualTo(0));
            Assert.That(terrain.Name, Is.EqualTo("Unknown"));
            Assert.That(terrain.Description, Is.EqualTo("Unknown"));
            Assert.That(terrain.MovementModifier, Is.EqualTo(1.0f));
        }
    }
}
