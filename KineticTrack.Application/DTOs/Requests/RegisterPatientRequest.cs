using KineticTrack.Domain.Enums;

namespace KineticTrack.Application.DTOs.Requests;

public class RegisterPatientRequest
{
    public string Email { get; set; } = string.Empty;
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;

    // Données spécifiques à la table PATIENT
    public DateTime Birthdate { get; set; }
    public Gender Gender { get; set; }
    public string MedicalHistory { get; set; } = string.Empty;
}
