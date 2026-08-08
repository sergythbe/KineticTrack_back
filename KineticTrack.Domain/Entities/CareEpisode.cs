// KineticTrack.Domain/Entities/CareEpisode.cs
using KineticTrack.Domain.Enums;

namespace KineticTrack.Domain.Entities;

public class CareEpisode
{
    public Guid CareEpisodeId { get; private set; }
    public string Title { get; private set; }
    public CareEpisodeStatus Status { get; private set; }  
    public DateTime CreatedAt { get; private set; }
    public Guid PatientId { get; private set; }

    // Navigation
    public Patient Patient { get; private set; } = null!;
    public ICollection<Protocol> Protocols { get; private set; } = new List<Protocol>();

    private CareEpisode() { Title = string.Empty; }

    public CareEpisode(Guid careEpisodeId, string title, Guid patientId,
        CareEpisodeStatus status = CareEpisodeStatus.Open, DateTime? createdAt = null)
    {
        CareEpisodeId = careEpisodeId;
        Title = title.Trim();
        Status = status;
        PatientId = patientId;
        CreatedAt = createdAt ?? DateTime.UtcNow;
    }
}