using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KineticTrack.Application.Repositories; 
using KineticTrack.Domain.Entities;         
using KineticTrack.Infrastructure.Database.Context; 

namespace KineticTrack.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
<<<<<<< Updated upstream:KineticTrack.Infrastructure/Repositories/UserRepository.cs
    internal class UserRepository
=======
    private readonly KineticTrackDbContext _context;

    // On injecte le DbContext d'EF Core pour KineticTrack
    public UserRepository(KineticTrackDbContext context)
>>>>>>> Stashed changes:KineticTrack.Infrastructure/Repositories/UserRepositories.cs
    {
        _context = context;
    }

    // 1. Vérifie si l'email existe déjà dans la table USERS (géré par le package en snake_case)
    public async Task<bool> ExistsByEmailAsync(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;
        return await _context.Users
            .AnyAsync(u => u.Email == email.Trim().ToLower());
    }

    // 2. Prépare l'ajout de l'utilisateur (sera traduit en INSERT lors du SaveChanges)
    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    // 3. Matérialise la transaction et applique les changements en base de données
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}