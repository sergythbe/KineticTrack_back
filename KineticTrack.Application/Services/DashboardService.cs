using KineticTrack.Application.DTOs.Responses;
using KineticTrack.Domain.Repositories;

namespace KineticTrack.Application.Services;

public class DashboardService : IDashboardService
{
    private readonly ICareEpisodeRepository _careEpisodeRepository;

    public DashboardService(ICareEpisodeRepository careEpisodeRepository)
    {
        _careEpisodeRepository = careEpisodeRepository;
    }

    public async Task<DashboardSummaryResponse> GetSummaryAsync(Guid userId)
    {
        var activeEpisodesCount = await _careEpisodeRepository.CountOpenEpisodesAsync();
        var activePatientsCount = await _careEpisodeRepository.CountDistinctPatientsWithOpenEpisodesAsync();

        return new DashboardSummaryResponse
        {
            ActivePatientsCount = activePatientsCount,
            ActiveEpisodesCount = activeEpisodesCount
        };
    }

    public async Task<List<ActiveEpisodeResponse>> GetActiveEpisodesAsync(Guid userId)
    {
        var episodes = await _careEpisodeRepository.GetOpenEpisodesAsync();

        return episodes.Select(e => new ActiveEpisodeResponse
        {
            CareEpisodeId = e.CareEpisodeId,
            PatientFirstname = e.Patient.User.Firstname,
            PatientLastname = e.Patient.User.Lastname,
            Title = e.Title,
            Status = e.Status.ToString(),
            CreatedAt = e.CreatedAt
        }).ToList();
    }
}