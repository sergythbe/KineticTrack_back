using KineticTrack.Domain.Entities;

namespace KineticTrack.Domain.Repositories;

public interface IAppointmentRepository
{
    Task<List<Appointment>> GetTodayAppointmentsAsync(Guid practitionerId);
}