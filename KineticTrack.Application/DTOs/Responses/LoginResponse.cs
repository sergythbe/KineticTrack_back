using KineticTrack.Domain.Enums;

namespace KineticTrack.Application.DTOs.Responses;

public class LoginResponse
{
    public string Token { get; set; } = string.Empty;
    public bool RequiresPasswordChange { get; set; }
    public Guid UserId { get; set; }
    public string Email { get; set; } = string.Empty;
    public UserRole Role { get; set; }
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
}