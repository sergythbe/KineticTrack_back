using KineticTrack.Application.DTOs.Requests;
using KineticTrack.Application.DTOs.Responses;

namespace KineticTrack.Application.Services
{
    public interface IUserService
    {
        Task<RegisterUserResponse> RegisterPatientAsync(RegisterPatientRequest request);

        Task<RegisterUserResponse> RegisterStaffAsync(RegisterStaffRequest request);
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task ChangePasswordAsync(Guid userId, ChangePasswordRequest request);
    }
}