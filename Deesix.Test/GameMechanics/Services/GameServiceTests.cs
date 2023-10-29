using Deesix.Domain.Entities;
using Deesix.GameMechanics.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Deesix.Test.GameMechanics.Services;

public class GameServiceTests : TestFixture
{
    private GameService GameService { get; set; }

    [SetUp]
    public override void SetUp()
    {
        base.SetUp();
        GameService = ServiceProvider.GetRequiredService<GameService>();
    }

    [Test]
    public void NewGameReturnsGameObject()
    {
        var result = GameService.NewGame();
        Assert.That(result, Is.Not.Null, "Expected result object to not be null.");
        Assert.That(result, Is.InstanceOf<Game>(), $"Expected result object to be an instance of {typeof(Game)}.");
        Assert.That(result.Id, Is.Not.EqualTo(0), $"Expected {nameof(result.Id)} to not be 0.");
    }
}