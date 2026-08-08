using KineticTrack.Domain.Entities;

namespace KineticTrack.Domain.Repositories;

public interface IPatientRepository
{
    Task AddAsync(Patient patient);
    Task<Patient?> GetByIdWithDetailsAsync(Guid patientId);
}