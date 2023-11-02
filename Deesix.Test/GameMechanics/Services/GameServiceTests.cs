using Deesix.Domain.Entities;
using Deesix.Domain.Interfaces;
using Deesix.GameMechanics.Services;
using Deesix.Test.TestDoubles;
using Microsoft.Extensions.DependencyInjection;

namespace Deesix.Test.GameMechanics.Services;

public class GameServiceTests : TestFixture
{
    private GameService GameService { get; set; }
    private GenerativeAIServiceStub? GenerativeAIServiceStub { get; set; }

    [SetUp]
    public override void SetUp()
    {
        base.SetUp();
        GameService = ServiceProvider.GetRequiredService<GameService>();
    }

    [Test]
    public async Task NewGameReturnsGameObject()
    {
        var testWorldSettings = new TestWorldSettings();
        var result = await GameService.NewGameAsync();
        Assert.That(result, Is.Not.Null, 
            "Expected result object to not be null.");
        Assert.That(result, Is.InstanceOf<Game>(), 
            $"Expected result object to be an instance of {typeof(Game)}.");
        Assert.That(result.Id, Is.Not.EqualTo(0), 
            $"Expected {nameof(result.Id)} to not be 0.");
        Assert.That(result.WorldSettings, Is.Not.Null, 
            $"Expected {nameof(result.WorldSettings)} to not be null.");
        Assert.That(result.WorldSettings.Name, Is.EqualTo(testWorldSettings.Name), 
            $"Expected {nameof(result.WorldSettings.Name)} to be {testWorldSettings.Name}.");
    }
}