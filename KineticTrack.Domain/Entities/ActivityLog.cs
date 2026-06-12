namespace KineticTrack.Domain.Entities;

public class ActivityLog
{
    public Guid ActivityLogId { get; private set; }
    public DateTime ExecutionDate { get; private set; }
    public bool IsCompleted { get; private set; }
    public string? PatientComment { get; private set; }
    public string? EvaMetric { get; private set; }
    public string? PractitionerNote { get; private set; } 
    public Guid ExerciseLibraryId { get; private set; }
    public Guid ProtocolId { get; private set; }
    public Guid PatientId { get; private set; }

    // Navigation
    public ExerciseLibrary Exercise { get; private set; } = null!;
    public Protocol Protocol { get; private set; } = null!;
    public Patient Patient { get; private set; } = null!;

    private ActivityLog() { }

    public ActivityLog(Guid activityLogId, DateTime executionDate, bool isCompleted,
        string? patientComment, string? evaMetric, string? practitionerNote,
        Guid exerciseLibraryId, Guid protocolId, Guid patientId)
    {
        ActivityLogId = activityLogId;
        ExecutionDate = executionDate;
        IsCompleted = isCompleted;
        PatientComment = patientComment;
        EvaMetric = evaMetric;
        PractitionerNote = practitionerNote;
        ExerciseLibraryId = exerciseLibraryId;
        ProtocolId = protocolId;
        PatientId = patientId;
    }
}