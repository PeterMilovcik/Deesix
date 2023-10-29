using Deesix.Domain.Entities;
using Deesix.GameMechanics.Services;

namespace Deesix.Test.Services;

public class GameServiceTests
{
    [Test]
    public void NewGameReturnsGameObject()
    {
        var sut = new GameService();
        var game = sut.NewGame();
        Assert.IsInstanceOf<Game>(game);
    }
}