using Deesix.Domain.Entities;

namespace Deesix.GameMechanics.Services;

public class GameService
{
    public Game NewGame()
    {
        return new Game();
    }
}
