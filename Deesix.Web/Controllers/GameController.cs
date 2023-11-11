using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Deesix.GameMechanics.Services;
using Deesix.Domain.Entities;

namespace Deesix.Web.Controllers;

//[Authorize]
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
    public async Task<ActionResult<Game>> NewGameAsync()
    {
        try
        {
            var newGame = await GameService.NewGameAsync();
            return Ok(newGame);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
