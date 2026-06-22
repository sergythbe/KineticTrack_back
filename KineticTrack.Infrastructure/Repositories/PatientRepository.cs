using Microsoft.EntityFrameworkCore;
using KineticTrack.Domain.Entities;
using KineticTrack.Domain.Repositories;
using KineticTrack.Infrastructure.Database.Context;

namespace KineticTrack.Infrastructure.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly KineticTrackDbContext _context;

    public PatientRepository(KineticTrackDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Patient patient)
    {
        await _context.Patients.AddAsync(patient);
    }
}