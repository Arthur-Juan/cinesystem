using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services;

public interface ICryptoService
{
    string Encrypt(string text);
    bool Verify(string text, string hash);
}
