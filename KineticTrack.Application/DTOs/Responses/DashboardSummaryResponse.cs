using System;
using System.Collections.Generic;
using System.Text;

namespace KineticTrack.Application.DTOs.Responses;


public class DashboardSummaryResponse
{
    public int ActivePatientsCount { get; set; }
    public int ActiveEpisodesCount { get; set; }
}
