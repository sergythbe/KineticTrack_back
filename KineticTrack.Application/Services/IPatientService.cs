
using KineticTrack.Application.DTOs.Responses;

namespace KineticTrack.Application.Services;

public interface IPatientService
{
    Task<PatientDetailResponse?> GetPatientDetailAsync(Guid patientId);
}