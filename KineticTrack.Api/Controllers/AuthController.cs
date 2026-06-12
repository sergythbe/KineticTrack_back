using FluentValidation;
using KineticTrack.Application.DTOs.Requests;
using KineticTrack.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KineticTrack.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    public AuthController(IUserService userService)
    {
       _userService = userService; 
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterPatientRequest request)
    {
        var response = await _userService.RegisterPatientAsync(request);
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        try
        {
            var response = await _userService.LoginAsync(request);
            return Ok(response);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [HttpPost("change-password")]
    [Authorize]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
    {
        try
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            await _userService.ChangePasswordAsync(userId, request);
            return Ok(new { message = "Mot de passe modifié avec succès." });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
        catch (ValidationException ex)
        {
            return BadRequest(new { errors = ex.Errors.Select(e => e.ErrorMessage) });
        }
    }

    //public async Task<IActionResult> Register([FromBody] RegisterStaffRequest request)
    //{
    //    await _userService.RegisterStaffAsync(request);
    //    return Ok(new { message = "Membre staff  enregistré avec succès." });
    //}
}
