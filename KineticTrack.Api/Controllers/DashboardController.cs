using KineticTrack.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KineticTrack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Practitioner,Admin")]
public class DashboardController : ControllerBase
{
    private readonly IDashboardService _dashboardService;

    public DashboardController(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    [HttpGet("summary")]
    public async Task<IActionResult> GetSummary()
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var summary = await _dashboardService.GetSummaryAsync(userId);
        return Ok(summary);
    }

    [HttpGet("active-episodes")]
    public async Task<IActionResult> GetActiveEpisodes()
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var episodes = await _dashboardService.GetActiveEpisodesAsync(userId);
        return Ok(episodes);
    }
}