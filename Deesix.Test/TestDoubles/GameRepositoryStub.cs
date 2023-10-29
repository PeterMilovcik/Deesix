using Deesix.Domain.Entities;
using Deesix.Domain.Interfaces;

namespace Deesix.Test;

public class GameRepositoryStub : IGameRepository
{
    public List<Game> Games { get; set; } = new List<Game>();

    public Game CreateGame(Game game)
    {
        game.Id = Random.Shared.Next(1, int.MaxValue);
        Games.Add(game);
        return game;
    }
}
