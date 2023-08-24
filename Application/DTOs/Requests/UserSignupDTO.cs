using AutoMapper;
using Domain.Entities;
using Infra.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Requests;

public record UserSignupDTO(
    string? FirstName,
    string? LastName,
    string? Email,
    string? Password,
    string? ConfirmPassword
    )
{
    public static User MapToEntity(IMapper _mapper, UserSignupDTO dto)
    {
        return _mapper.Map<User>(dto);
    }

}
