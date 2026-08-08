using System;
using System.Collections.Generic;
using System.Text;

namespace KineticTrack.Application.DTOs.Requests;

public class RegisterStaffRequest
{
    public string Email { get; set; } = string.Empty;
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;

    // Donnée pour la table TRAVAILLER (ex: "Secrétaire", "Praticien")
    public string RoleAtCabinet { get; set; } = string.Empty;

    // Données spécifiques à la table PRACTITIONER 
    // (Nullables car non applicables si c'est une secrétaire)
    public string? LicenseNumber { get; set; } // numéro INAMI
    public string? Speciality { get; set; }
}
