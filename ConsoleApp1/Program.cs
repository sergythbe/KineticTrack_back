
using KineticTrack.Security.Services.Tools;

var hasher = new PasswordHasherService();

Console.WriteLine(hasher.Hash("Admin@2026"));
// → colle ce résultat dans ton seed data
