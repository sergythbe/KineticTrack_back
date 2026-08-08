using System;
using System.Collections.Generic;
using System.Text;

namespace KineticTrack.Application.DTOs.Responses;

public class PatientDetailResponse
{
    public Guid PatientId { get; set; }
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateOnly Birthdate { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string? MedicalHistory { get; set; }
    public List<CareEpisodeDetailResponse> Episodes { get; set; } = new();
}