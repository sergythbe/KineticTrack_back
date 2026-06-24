
using KineticTrack.Application.DTOs.Responses;
using KineticTrack.Domain.Repositories;

namespace KineticTrack.Application.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;

    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<PatientDetailResponse?> GetPatientDetailAsync(Guid patientId)
    {
        var patient = await _patientRepository.GetByIdWithDetailsAsync(patientId);

        if (patient is null)
            return null;

        return new PatientDetailResponse
        {
            PatientId = patient.PatientId,
            Firstname = patient.User.Firstname,
            Lastname = patient.User.Lastname,
            Email = patient.User.Email,
            Birthdate = patient.Birthdate,
            Gender = patient.Gender,
            MedicalHistory = patient.MedicalHistory,
            Episodes = patient.CareEpisodes.Select(e => new CareEpisodeDetailResponse
            {
                CareEpisodeId = e.CareEpisodeId,
                Title = e.Title,
                Status = e.Status.ToString(),
                CreatedAt = e.CreatedAt,
                EvaDataPoints = new List<EvaDataPointResponse>() // à brancher plus tard via ActivityLog
            }).ToList()
        };
    }
}