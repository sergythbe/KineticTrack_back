using KineticTrack.Domain.Entities;

namespace KineticTrack.Domain.Repositories;

public interface ICareEpisodeRepository
{
    Task<int> CountOpenEpisodesAsync();
    Task<int> CountDistinctPatientsWithOpenEpisodesAsync();
    Task<List<CareEpisode>> GetOpenEpisodesAsync();
}