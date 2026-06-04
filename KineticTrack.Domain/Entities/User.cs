using System;

namespace KineticTrack.Domain.Entities;

public class User
{
    public Guid UserId { get; private set; }
    public string PasswordHash { get; private set; }
    public string Firstname { get; private set; }
    public string Lastname { get; private set; }
    public string Email { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool IsPasswordChanged { get; private set; }
    public bool IsActive { get; private set; }
    public bool IsDeleted { get; private set; }

    //permet à EF de créér un USER
    private User()
    {
        UserId = Guid.Empty;
        PasswordHash = string.Empty;
        Firstname = string.Empty;
        Lastname = string.Empty;
        Email = string.Empty;
    }

    public User(
      Guid userId,
      string passwordHash,
      string firstname,
      string lastname,
      string email,
      DateTime? createdAt = null,
      bool isActive = false,           
      bool isPasswordChanged = false,   
      bool isDeleted = false)           
    {
        UserId = userId;
        PasswordHash = passwordHash;
        Firstname = firstname.Trim();
        Lastname = lastname.Trim();
        Email = email.Trim().ToLower();

        CreatedAt = createdAt ?? DateTime.UtcNow;
        IsActive = isActive;
        IsPasswordChanged = isPasswordChanged;
        IsDeleted = isDeleted;
    }
    //Contructeur indispensable pour mon seed data
    public User(Guid userId, string passwordHash, string firstname, string lastname, string email, bool isActive, bool isPasswordChanged)
        : this(userId, passwordHash, firstname, lastname, email) 
    {
       
        IsActive = isActive;
        IsPasswordChanged = isPasswordChanged;
    }


    public void UpdateProfile(string lastname, string firstname)
    {
        Lastname = lastname.Trim();
        Firstname = firstname.Trim();
    }

    public void UpdateEmail(string email)
    {
        Email = email.Trim().ToLower();
    }

    public void DefineFirstPersonalPassword(string newPasswordHash)
    {
        PasswordHash = newPasswordHash;
        IsPasswordChanged = true; 
        IsActive = true;          
    }

    public void UpdatePassword(string passwordHash)
    {
        PasswordHash = passwordHash;
    }

    public void Deactivate() => IsActive = false;
    public void Activate() => IsActive = true;

    public void Delete()
    {
        IsDeleted = true;
        IsActive = false;
    }
}