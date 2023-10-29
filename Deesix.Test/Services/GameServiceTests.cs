namespace Deesix.Test.Services;

public class GameServiceTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void NewGameReturnsGameObject()
    {
        var sut = new GameService();
        var game = sut.NewGame();
        Assert.IsInstanceOf<Game>(game);
    }
}

public class GameService
{
    public Game NewGame()
    {
        return new Game();
    }
}

public class Game{
    public int Id { get; set; }
}