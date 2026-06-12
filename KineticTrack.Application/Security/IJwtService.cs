using System;
using System.Collections.Generic;
using System.Text;

namespace KineticTrack.Application.Security;

public interface IJwtService
{
    string GenerateToken(Guid userId, string email, string firstname, string lastname);
    string GenerateTempToken(Guid userId, string email);
}
