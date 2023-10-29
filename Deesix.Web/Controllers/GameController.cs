using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Deesix.GameMechanics.Services;
using Deesix.Domain.Entities;

namespace Deesix.Web.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private ILogger<GameController> Logger { get; }
    private GameService GameService { get; }

    public GameController(ILogger<GameController> logger, GameService gameService)
    {
        Logger = logger;
        GameService = gameService;
    }

    [HttpPost("new-game")]
    public ActionResult<Game> NewGame()
    {
        try
        {
            var newGame = GameService.NewGame();
            return Ok(newGame);
        }
        catch (Exception ex)
        {
            // Handle exceptions
            return BadRequest(ex.Message);
        }
    }
}
