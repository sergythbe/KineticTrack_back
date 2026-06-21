using Microsoft.EntityFrameworkCore;
using KineticTrack.Domain.Entities;
using KineticTrack.Domain.Enums;
using KineticTrack.Domain.Repositories;
using KineticTrack.Infrastructure.Database.Context;

namespace KineticTrack.Infrastructure.Repositories;

public class CareEpisodeRepository : ICareEpisodeRepository
{
    private readonly KineticTrackDbContext _context;

    public CareEpisodeRepository(KineticTrackDbContext context)
    {
        _context = context;
    }

    public async Task<int> CountOpenEpisodesAsync()
    {
        return await _context.CareEpisodes
            .CountAsync(e => e.Status == CareEpisodeStatus.Open);
    }

    public async Task<int> CountDistinctPatientsWithOpenEpisodesAsync()
    {
        return await _context.CareEpisodes
            .Where(e => e.Status == CareEpisodeStatus.Open)
            .Select(e => e.PatientId)
            .Distinct()
            .CountAsync();
    }

    public async Task<List<CareEpisode>> GetOpenEpisodesAsync()
    {
        return await _context.CareEpisodes
            .Include(e => e.Patient)
                .ThenInclude(p => p.User)
            .Where(e => e.Status == CareEpisodeStatus.Open)
            .OrderByDescending(e => e.CreatedAt)
            .ToListAsync();
    }
}