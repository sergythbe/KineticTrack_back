// KineticTrack.Domain/Entities/Patient.cs
namespace KineticTrack.Domain.Entities;

public class Patient
{
    public Guid PatientId { get; private set; }
    public DateOnly Birthdate { get; private set; }
    public string Gender { get; private set; }
    public string? MedicalHistory { get; private set; }
    public Guid UserId { get; private set; }

    // Navigation
    public User User { get; private set; } = null!;
    public ICollection<CareEpisode> CareEpisodes { get; private set; } = new List<CareEpisode>();

    private Patient() { } // EF Core

    public Patient(Guid patientId, DateOnly birthdate, string gender, string? medicalHistory, Guid userId)
    {
        PatientId = patientId;
        Birthdate = birthdate;
        Gender = gender;
        MedicalHistory = medicalHistory;
        UserId = userId;
    }
}