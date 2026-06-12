using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KineticTrack.Domain.Repositories; 
using KineticTrack.Domain.Entities;         
using KineticTrack.Infrastructure.Database.Context; 

namespace KineticTrack.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly KineticTrackDbContext _context;

    public UserRepository(KineticTrackDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;
        return await _context.Users
            .AnyAsync(u => u.Email == email.Trim().ToLower());
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email.Trim().ToLower());
    }

    public async Task<User?> GetByIdAsync(Guid userId)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.UserId == userId);
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}