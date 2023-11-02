using Deesix.Domain.Entities;
using Deesix.Domain.Interfaces;

namespace Deesix.GameMechanics.Services;

public class GameService
{
    private IGameRepository GameRepository { get; }
    private IGenerativeAIService GenerativeAIService { get; }

    public GameService(IGameRepository gameRepository, IGenerativeAIService generativeAIService)
    {
        GameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
        GenerativeAIService = generativeAIService ?? throw new ArgumentNullException(nameof(generativeAIService));
    }

    public async Task<Game> NewGameAsync()
    {
        var newGame = new Game();
        var newWorldSettings = await GenerativeAIService.GenerateWorldSettingsAsync();
        newGame.WorldSettings = newWorldSettings;
        return GameRepository.CreateGame(newGame);
    }
}
