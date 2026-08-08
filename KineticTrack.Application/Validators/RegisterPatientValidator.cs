using FluentValidation;
using KineticTrack.Application.DTOs.Requests;

namespace KineticTrack.Application.Validators;

public class RegisterPatientValidator : AbstractValidator<RegisterPatientRequest>
{
    public RegisterPatientValidator()
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

        RuleFor(x => x.Birthdate)
            .NotEmpty().WithMessage("La date de naissance est obligatoire.")
            .LessThan(DateTime.Today).WithMessage("La date de naissance ne peut pas être dans le futur.");

        RuleFor(x => x.Gender)
            .IsInEnum().WithMessage("Le genre est obligatoire.");

    }
}
