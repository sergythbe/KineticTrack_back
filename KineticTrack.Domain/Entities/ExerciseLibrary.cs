namespace KineticTrack.Domain.Entities;

public class ExerciseLibrary
{
    public Guid ExerciseLibraryId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string? MediaUrl { get; private set; }
    public string? Category { get; private set; } 
    public DateTime CreatedAt { get; private set; }

    // Navigation
    public ICollection<ActivityLog> ActivityLogs { get; private set; } = new List<ActivityLog>();
    public ICollection<ProtocolExercise> ProtocolExercises { get; private set; } = new List<ProtocolExercise>();


    private ExerciseLibrary()
    {
        Name = string.Empty;
        Description = string.Empty;
    }

    public ExerciseLibrary(Guid exerciseLibraryId, string name, string description,
        string? mediaUrl = null, string? category = null, DateTime? createdAt = null)
    {
        ExerciseLibraryId = exerciseLibraryId;
        Name = name.Trim();
        Description = description.Trim();
        MediaUrl = mediaUrl;
        Category = category?.Trim();
        CreatedAt = createdAt ?? DateTime.UtcNow;
    }
}