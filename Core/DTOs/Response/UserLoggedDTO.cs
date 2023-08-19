using Domain.Entities;

namespace Application.DTOs.Response;

public record UserLoggedDTO(
    string? FirstName,
    string? LastName,
    string? Email,
    string? Token
    ){

    public static UserLoggedDTO mapFromEntity(User? entity, string? token)
    {
        return new UserLoggedDTO(
            entity?.FirstName,
            entity?.LastName,
            entity?.Email,
            token
            );
    }
}


