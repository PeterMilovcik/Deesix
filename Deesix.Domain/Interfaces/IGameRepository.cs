using Deesix.Domain.Entities;

namespace Deesix.Domain.Interfaces;

public interface IGameRepository
{
    Game CreateGame(Game game);
}
