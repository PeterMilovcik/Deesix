using Deesix.Domain.Entities;
using Deesix.Domain.Interfaces;

namespace Deesix.GameMechanics.Services;

public class GameService
{
    private IGameRepository GameRepository { get; }

    public GameService(IGameRepository gameRepository)
    {
        GameRepository = gameRepository;
    }

    public Game NewGame()
    {
        var newGame = new Game();
        return GameRepository.CreateGame(newGame);
    }
}
