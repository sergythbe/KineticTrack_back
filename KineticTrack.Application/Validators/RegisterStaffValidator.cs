using FluentValidation;
using KineticTrack.Application.DTOs.Requests;

namespace KineticTrack.Application.Validators;

public class RegisterStaffValidator : AbstractValidator<RegisterStaffRequest>
{
    public RegisterStaffValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("L'adresse email est obligatoire.")
            .EmailAddress().WithMessage("Le format de l'adresse email n'est pas valide.");

        RuleFor(x => x.Firstname)
            .NotEmpty().WithMessage("Le prénom est obligatoire.")
            .MinimumLength(2).WithMessage("Le prénom doit contenir au moins 2 caractères.");

        RuleFor(x => x.Lastname)
            .NotEmpty().WithMessage("Le nom de famille est obligatoire.")
            .MinimumLength(2).WithMessage("Le nom doit contenir au moins 2 caractères.");

        RuleFor(x => x.RoleAtCabinet)
            .NotEmpty().WithMessage("Le rôle au sein du cabinet est obligatoire.")
            .Must(role => role == "Practitioner" || role == "Secretary")
            .WithMessage("Le rôle doit être soit 'Praticien', soit 'Secrétaire'.");

        // --- VALIDATION CONDITIONNELLE (Basée sur ton MLD) ---

        // Le numéro de licence (INAMI) est requis UNIQUEMENT si c'est un Praticien
        RuleFor(x => x.LicenseNumber)
            .NotEmpty().WithMessage("Le numéro de licence (INAMI) est obligatoire pour un praticien.")
            .When(x => x.RoleAtCabinet == "Practitioner");

        // La spécialité est requise UNIQUEMENT si c'est un Praticien
        RuleFor(x => x.Speciality)
            .NotEmpty().WithMessage("La spécialité est obligatoire pour un praticien.")
            .When(x => x.RoleAtCabinet == "Practitioner");
    }
}