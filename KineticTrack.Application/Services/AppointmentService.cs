using KineticTrack.Application.DTOs.Responses;
using KineticTrack.Domain.Repositories;

namespace KineticTrack.Application.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;

    public AppointmentService(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<List<AppointmentResponse>> GetTodayAppointmentsAsync(Guid practitionerId)
    {
        var appointments = await _appointmentRepository.GetTodayAppointmentsAsync(practitionerId);

        return appointments.Select(a => new AppointmentResponse
        {
            AppointmentId = a.AppointmentId,
            ScheduledAt = a.ScheduledAt,
            Reason = a.Reason,
            Status = a.Status.ToString(),
            PatientFirstname = a.Patient.User.Firstname,
            PatientLastname = a.Patient.User.Lastname,
            PatientId = a.PatientId,
            CareEpisodeTitle = a.CareEpisode?.Title,
            CareEpisodeId = a.CareEpisodeId
        }).ToList();
    }
}