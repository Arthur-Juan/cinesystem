using Domain.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Services;

public class JwtAdapter : ITokenService
{
    public Task<string> GenerateTokenAsync(User user)
    {
        return Task.Run( ()=> GetText() );
    }

    

    private string GetText()
    {
        return "token-mock";
    }
}
