namespace KineticTrack.Application.Security
{
    public interface IPasswordHasher
    {
        // Prend un mot de passe en clair (ex: "SANINOU2026!") et retourne sa version hachée
        string Hash(string password);

        // Permettra de vérifier lors du Login si le mot de passe en clair 
        // correspond au hash stocké dans la table USER_
        bool Verify(string password, string passwordHash);
    }
}