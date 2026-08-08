namespace KineticTrack.Domain.Entities;

public class ProtocolExercise
{
    public Guid ProtocolId { get; private set; }
    public Guid ExerciseLibraryId { get; private set; }
    public string? Parameters { get; private set; }
    public string? Order { get; private set; }

    // Navigation
    public Protocol Protocol { get; private set; } = null!;
    public ExerciseLibrary Exercise { get; private set; } = null!;

    private ProtocolExercise() { }

    public ProtocolExercise(Guid protocolId, Guid exerciseLibraryId, string? parameters = null, string? order = null)
    {
        ProtocolId = protocolId;
        ExerciseLibraryId = exerciseLibraryId;
        Parameters = parameters;
        Order = order;
    }
}