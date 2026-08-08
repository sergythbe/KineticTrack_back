using KineticTrack.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KineticTrack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Practitioner,Admin,Secretary")]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpGet("today")]
    public async Task<IActionResult> GetTodayAppointments()
    {
        var practitionerId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var appointments = await _appointmentService.GetTodayAppointmentsAsync(practitionerId);
        return Ok(appointments);
    }
}