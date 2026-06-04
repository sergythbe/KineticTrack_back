using KineticTrack.Application.DTOs.Requests;
using KineticTrack.Application.Services;
using Microsoft.AspNetCore.Mvc;

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
        await _userService.RegisterPatientAsync(request);
        return Ok(new {message = "Patient enregistré avec succès."});
    }

    //public async Task<IActionResult> Register([FromBody] RegisterStaffRequest request)
    //{
    //    await _userService.RegisterStaffAsync(request);
    //    return Ok(new { message = "Membre staff  enregistré avec succès." });
    //}
}
