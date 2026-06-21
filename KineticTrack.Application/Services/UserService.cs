using FluentValidation;
using KineticTrack.Application.Common.Utilities;
using KineticTrack.Application.DTOs.Requests;
using KineticTrack.Application.DTOs.Responses;
using KineticTrack.Application.Security;
using KineticTrack.Application.Validators;
using KineticTrack.Domain.Entities;
using KineticTrack.Domain.Enums;
using KineticTrack.Domain.Repositories;

namespace KineticTrack.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IValidator<RegisterPatientRequest> _patientValidator;
    private readonly IJwtService _jwtService;

    public UserService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IValidator<RegisterPatientRequest> patientValidator,
        IJwtService jwtService)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _patientValidator = patientValidator;
        _jwtService = jwtService;
    }

    public async Task<RegisterUserResponse> RegisterPatientAsync(RegisterPatientRequest request)
    {
        var validationResult = await _patientValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var emailExists = await _userRepository.ExistsByEmailAsync(request.Email);
        if (emailExists)
        {
            throw new InvalidOperationException("Cette adresse email est déjà utilisée.");
        }

        string temporaryPassword = PasswordGenerator.Generate();

        string passwordHash = _passwordHasher.Hash(temporaryPassword);

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

        await _userRepository.AddAsync(newUser);
        await _userRepository.SaveChangesAsync();

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
        throw new NotImplementedException();
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user is null)
            throw new UnauthorizedAccessException("Email ou mot de passe incorrect.");

        var isPasswordValid = _passwordHasher.Verify(request.Password, user.PasswordHash);
        if (!isPasswordValid)
            throw new UnauthorizedAccessException("Email ou mot de passe incorrect.");

        var role = DetermineRole(user);

        // Premier login — mot de passe temporaire, compte pas encore actif
        if (!user.IsPasswordChanged)
        {
            return new LoginResponse
            {
                UserId = user.UserId,
                Email = user.Email,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Role = role,
                Token = _jwtService.GenerateTempToken(user.UserId, user.Email),
                RequiresPasswordChange = true
            };
        }

        // Login normal — compte doit être actif
        if (!user.IsActive)
            throw new UnauthorizedAccessException("Ce compte est désactivé.");

        return new LoginResponse
        {
            UserId = user.UserId,
            Email = user.Email,
            Firstname = user.Firstname,
            Lastname = user.Lastname,
            Role = role,
            Token = _jwtService.GenerateToken(user.UserId, user.Email, user.Firstname, user.Lastname, role),
            RequiresPasswordChange = false
        };
    }

    public async Task ChangePasswordAsync(Guid userId, ChangePasswordRequest request)
    {
        var validator = new ChangePasswordValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null)
            throw new UnauthorizedAccessException("Utilisateur introuvable.");

        var isCurrentPasswordValid = _passwordHasher.Verify(request.CurrentPassword, user.PasswordHash);
        if (!isCurrentPasswordValid)
            throw new UnauthorizedAccessException("Le mot de passe actuel est incorrect.");

        var newPasswordHash = _passwordHasher.Hash(request.NewPassword);

        user.DefineFirstPersonalPassword(newPasswordHash);
        await _userRepository.SaveChangesAsync();
    }

    private static UserRole DetermineRole(User user)
    {
        if (user.Patient is not null)
            return UserRole.Patient;

        var cabinetRole = user.CabinetMemberships.FirstOrDefault()?.RoleAtCabinet
      ?? throw new InvalidOperationException("Utilisateur sans rôle défini.");



        return cabinetRole switch
        {
            CabinetRole.Admin => UserRole.Admin,
            CabinetRole.Practitioner => UserRole.Practitioner,
            CabinetRole.Secretary => UserRole.Secretary,
            _ => throw new InvalidOperationException("Rôle cabinet inconnu.")
        };
    }
}