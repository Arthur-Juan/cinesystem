using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Services;

public class BCryptAdapter : ICryptoService
{
    public string Encrypt(string text)
    {
        return BCrypt.Net.BCrypt.HashPassword(text);
    }

    public bool Verify(string text, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(text, hash);
    }
}
