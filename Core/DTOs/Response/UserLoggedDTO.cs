using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response;

public record UserLoggedDTO(
    string FirstName,
    string LastName,
    string Email,
    string Token
    )

{
    public static UserLoggedDTO MapFromEntity(User? entity, string token)
    {
        return new UserLoggedDTO(
            entity?.FirstName,
            entity?.LastName,
            entity?.Email,
            token
            );
    }

}


