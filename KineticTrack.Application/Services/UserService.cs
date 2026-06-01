using FluentValidation;
using KineticTrack.Application.DTOs.Requests;
using KineticTrack.Application.DTOs.Responses;
using KineticTrack.Application.Security;
using KineticTrack.Domain.Entities;
using KineticTrack.Domain.Repositories;

namespace KineticTrack.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IValidator<RegisterPatientRequest> _patientValidator;

        public UserService(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            IValidator<RegisterPatientRequest> patientValidator)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _patientValidator = patientValidator;
        }

        public async Task<RegisterUserResponse> RegisterPatientAsync(RegisterPatientRequest request)
        {
            // 1. Étape de validation de sécurité
            var validationResult = await _patientValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            // 2. Vérification métier : l'email est-il unique ?
            var emailExists = await _userRepository.ExistsByEmailAsync(request.Email);
            if (emailExists)
            {
                throw new InvalidOperationException("Cette adresse email est déjà utilisée.");
            }

            // 3. Application de la Stratégie B : Génération du mot de passe temporaire
            // On peut générer une chaîne aléatoire propre (ici un exemple simple basé sur le nom)
            string temporaryPassword = $"{request.Lastname.ToUpper()}{DateTime.Today.Year}!";

            // 4. Hachage du mot de passe via notre contrat Security
            string passwordHash = _passwordHasher.Hash(temporaryPassword);

            // 5. Instanciation de notre Entité riche du Domaine
            // (IsActive et IsPasswordChanged passent automatiquement à false dans le constructeur)
            var userId = Guid.NewGuid();
            var newUser = new User(
                userId,
                passwordHash,
                request.Firstname,
                request.Lastname,
                request.Email
            );

            // TODO: Plus tard, lors du looping Patient, on instanciera ici l'entité Patient 
            // avec sa date de naissance, son genre et ses antécédents médicaux issus du MLD !

            // 6. Sauvegarde via le Repository (Persistance)
            await _userRepository.AddAsync(newUser);
            await _userRepository.SaveChangesAsync();

            // 7. On retourne la Response avec le mot de passe en clair pour l'écran Angular de la secrétaire
            return new RegisterUserResponse
            {
                UserId = userId,
                Email = newUser.Email,
                Firstname = newUser.Firstname,
                Lastname = newUser.Lastname,
                TemporaryPassword = temporaryPassword
            };
        }

        public async Task<RegisterUserResponse> RegisterStaffAsync(RegisterStaffRequest request)
        {
            // On codera cette partie un peu plus tard pour ne pas tout mélanger,
            // chaque chose en son temps !
            throw new NotImplementedException();
        }
    }
}