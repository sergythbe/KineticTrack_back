using KineticTrack.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KineticTrack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Practitioner,Admin,Secretary")]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatientDetail(Guid id)
    {
        var patient = await _patientService.GetPatientDetailAsync(id);

        if (patient is null)
            return NotFound(new { message = "Patient introuvable." });

        return Ok(patient);
    }
}