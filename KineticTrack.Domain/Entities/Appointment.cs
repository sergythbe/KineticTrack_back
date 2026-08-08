  using KineticTrack.Domain.Enums;

namespace KineticTrack.Domain.Entities;

public class Appointment
{
    public Guid AppointmentId { get; private set; }
    public DateTime ScheduledAt { get; private set; }
    public string Reason { get; private set; } = string.Empty;
    public AppointmentStatus Status { get; private set; }

    // FKs
    public Guid PatientId { get; private set; }
    public Guid PractitionerId { get; private set; }
    public Guid? CareEpisodeId { get; private set; }  

    // Navigation
    public Patient Patient { get; private set; } = null!;
    public Practitioner Practitioner { get; private set; } = null!;
    public CareEpisode? CareEpisode { get; private set; }

    private Appointment() { }  // EF Core

    public Appointment(
        Guid appointmentId,
        DateTime scheduledAt,
        string reason,
        Guid patientId,
        Guid practitionerId,
        Guid? careEpisodeId = null,
        AppointmentStatus status = AppointmentStatus.Scheduled)
    {
        AppointmentId = appointmentId;
        ScheduledAt = scheduledAt;
        Reason = reason.Trim();
        PatientId = patientId;
        PractitionerId = practitionerId;
        CareEpisodeId = careEpisodeId;
        Status = status;
    }
}