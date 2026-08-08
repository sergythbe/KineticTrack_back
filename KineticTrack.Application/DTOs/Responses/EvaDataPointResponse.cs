using System;
using System.Collections.Generic;
using System.Text;

namespace KineticTrack.Application.DTOs.Responses;

public class EvaDataPointResponse
{
    public DateTime ExecutionDate { get; set; }
    public string? EvaMetric { get; set; }
}