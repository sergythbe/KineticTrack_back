using System;

namespace KineticTrack.Application.DTOs.Responses;

public class RegisterUserResponse
{
    public Guid UserId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;

    // C'est ici qu'on transmettra le mot de passe généré en clair 
    // pour que le front Angular puisse l'afficher à la secrétaire !
    public string TemporaryPassword { get; set; } = string.Empty;
}