using KineticTrack.Domain.Entities;
using KineticTrack.Domain.Repositories;
using KineticTrack.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace KineticTrack.Infrastructure.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly KineticTrackDbContext _context;

    public AppointmentRepository(KineticTrackDbContext context)
    {
        _context = context;
    }

    public async Task<List<Appointment>> GetTodayAppointmentsAsync(Guid practitionerId)
    {
        var today = DateTime.UtcNow.Date;

        return await _context.Appointments
            .Include(a => a.Patient)
                .ThenInclude(p => p.User)
            .Include(a => a.CareEpisode)
            .Where(a => a.PractitionerId == practitionerId
                     && a.ScheduledAt.Date == today)
            .OrderBy(a => a.ScheduledAt)
            .ToListAsync();
    }
}