using System;
using System.Collections.Generic;
using System.Text;

namespace KineticTrack.Application.DTOs.Responses;

public class ActiveEpisodeResponse
{
    public Guid CareEpisodeId { get; set; }
    public string PatientFirstname { get; set; } = string.Empty;
    public string PatientLastname { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
