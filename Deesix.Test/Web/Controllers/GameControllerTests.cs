using Deesix.Domain.Entities;
using Deesix.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Deesix.Test.Web.Controllers;

[TestFixture]
public class GameControllerTests : TestFixture
{
    private GameController GameController { get; set; }

    override public void SetUp()
    {
        base.SetUp();
        GameController = ServiceProvider.GetRequiredService<GameController>();
    }

    [Test]
    public async Task NewGameReturnsGameResult()
    {
        var result = await GameController.NewGameAsync();
        Assert.That(result, Is.Not.Null, "Expected result object to not be null.");
        Assert.That(result.Result, Is.InstanceOf<OkObjectResult>(), $"Expected result object to be an instance of {typeof(OkObjectResult)}.");
        var okResult = result.Result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null, "Expected result.Result to not be null.");
        Assert.That(okResult.Value, Is.Not.Null, "Expected result.Value to not be null.");
        Assert.That(okResult.Value, Is.InstanceOf<Game>(), $"Expected result.Value to be an instance of {typeof(Game)}.");
    }
}
