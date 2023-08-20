using Domain.Entities;
using Domain.Services;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Services;

public class JwtAdapter : ITokenService
{
    private readonly string _secret;
    
    public JwtAdapter(string secret) 
    {
        _secret = secret;
    }

    public Task<string> GenerateTokenAsync(User user)
    {
        return Task.Run( () => Generate(user) );
    }

    

    private string Generate(User user)
    {
        var claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email.ToString()),
            new Claim(JwtRegisteredClaimNames.Name, user.GetFullName())

        };

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret)),
            SecurityAlgorithms.HmacSha256
            );

        var tokenConfig = new JwtSecurityToken(
                null,
                null,
                claims,
                null,
                DateTime.UtcNow.AddHours(8),
                signingCredentials
                );

        string token = new JwtSecurityTokenHandler().WriteToken(tokenConfig);
        return token;
    }


}
