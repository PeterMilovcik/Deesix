using Deesix.Domain.Entities;
using Deesix.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Deesix.Web.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class WorldSettingsController : ControllerBase
{
    private ILogger<WorldSettingsController> Logger { get; }
    private IGenerativeAIService GenerativeAIService { get; }

    public WorldSettingsController(
        ILogger<WorldSettingsController> logger, 
        IGenerativeAIService generativeAIService)
    {
        Logger = logger;
        GenerativeAIService = generativeAIService;
    }
    
    [HttpGet("create")]
    public async Task<ActionResult<WorldSettings>> CreateAsync()
    {
        try
        {
            var newWorldSettings = await GenerativeAIService.GenerateWorldSettingsAsync();
            return Ok(newWorldSettings);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }
}
