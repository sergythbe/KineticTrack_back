using KineticTrack.Application.DTOs.Responses;

namespace KineticTrack.Application.Services;

public interface IDashboardService
{
    Task<DashboardSummaryResponse> GetSummaryAsync(Guid userId);
    Task<List<ActiveEpisodeResponse>> GetActiveEpisodesAsync(Guid userId);
}