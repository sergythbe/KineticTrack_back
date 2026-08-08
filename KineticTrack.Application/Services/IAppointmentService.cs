using KineticTrack.Application.DTOs.Responses;

namespace KineticTrack.Application.Services;

public interface IAppointmentService
{
    Task<List<AppointmentResponse>> GetTodayAppointmentsAsync(Guid practitionerId);
}