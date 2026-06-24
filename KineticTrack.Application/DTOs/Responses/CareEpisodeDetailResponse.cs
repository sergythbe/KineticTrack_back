using System;
using System.Collections.Generic;
using System.Text;

namespace KineticTrack.Application.DTOs.Responses;

public class CareEpisodeDetailResponse
{
    public Guid CareEpisodeId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public List<EvaDataPointResponse> EvaDataPoints { get; set; } = new();
}
