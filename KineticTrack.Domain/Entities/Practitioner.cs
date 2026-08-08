namespace KineticTrack.Domain.Entities;

public class Practitioner
{
    public Guid PractitionerId { get; private set; }
    public string LicenseNumber { get; private set; }
    public string Speciality { get; private set; }
    public Guid UserId { get; private set; }

    // Navigation
    public User User { get; private set; } = null!;

    private Practitioner() { } // EF Core

    public Practitioner(Guid practitionerId, string licenseNumber, string speciality, Guid userId)
    {
        PractitionerId = practitionerId;
        LicenseNumber = licenseNumber;
        Speciality = speciality;
        UserId = userId;
    }
}