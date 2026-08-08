namespace KineticTrack.Domain.Entities;

public class Protocol
{
    public Guid ProtocolId { get; private set; }
    public string Title { get; private set; }
    public string? Description { get; private set; }  
    public DateTime CreatedAt { get; private set; }
    public Guid CareEpisodeId { get; private set; }

    // Navigation
    public CareEpisode CareEpisode { get; private set; } = null!;
    public ICollection<ProtocolExercise> ProtocolExercises { get; private set; } = new List<ProtocolExercise>();


    private Protocol() { Title = string.Empty; }

    public Protocol(Guid protocolId, string title, Guid careEpisodeId, string? description = null, DateTime? createdAt = null)
    {
        ProtocolId = protocolId;
        Title = title.Trim();
        Description = description?.Trim();
        CareEpisodeId = careEpisodeId;
        CreatedAt = createdAt ?? DateTime.UtcNow;
    }
}