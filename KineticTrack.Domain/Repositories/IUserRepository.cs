using KineticTrack.Domain.Entities;

namespace KineticTrack.Domain.Repositories;

public interface IUserRepository
{
    Task<bool> ExistsByEmailAsync(string email);
    Task AddAsync(User user);
    Task SaveChangesAsync();
}