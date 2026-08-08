namespace KineticTrack.Application.DTOs.Responses;

public class AppointmentResponse
{
    public Guid AppointmentId { get; set; }
    public DateTime ScheduledAt { get; set; }
    public string Reason { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string PatientFirstname { get; set; } = string.Empty;
    public string PatientLastname { get; set; } = string.Empty;
    public Guid PatientId { get; set; }
    public string? CareEpisodeTitle { get; set; }
    public Guid? CareEpisodeId { get; set; }
}