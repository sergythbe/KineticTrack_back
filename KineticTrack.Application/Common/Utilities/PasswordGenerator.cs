using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace KineticTrack.Application.Common.Utilities;

public static class PasswordGenerator
{
    public static string Generate(int length = 10)
    {
        const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz23456789!@#$%";

        return new string(Enumerable.Range(0, length)
            .Select(_ => chars[RandomNumberGenerator.GetInt32(chars.Length)])
            .ToArray());
    }
}
