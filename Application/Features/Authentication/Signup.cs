using AutoMapper;
using Application.DTOs.Requests;
using Application.DTOs.Response;
using Application.Interfaces;
using Domain.Entities;
using Domain.Services;
using Infra.Data.Efcore;
using Application.Errors;
using Application.Errors.Exceptions;
using FluentValidation;

namespace Application.Features.Authentication;

public class Signup : ISignup
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;
    private readonly ICryptoService _cryptoService;
    public Signup(AppDbContext context, IMapper mapper, ITokenService tokenService, ICryptoService cryptoService) {
        _context = context;    
        _mapper = mapper;
        _tokenService = tokenService;
        _cryptoService = cryptoService;
    }

    public async Task<UserLoggedDTO> SignupAsync(UserSignupDTO dto)
    {
        var validator = new SignUpValidation();
        var isValid = validator.Validate(dto);
        if(!isValid.IsValid)
        {
            foreach(var fail in isValid.Errors)
            {
                throw new BadArgumentException(fail.ErrorMessage);
            }
        }

        var userAlreadyExists = _context.Users.Where(x => x.Email == dto.Email).FirstOrDefault();

        if (userAlreadyExists != null)
        {
            throw new BadArgumentException(DomainErrors.User.EmailAlreadyInUse);
        }

        var hash = _cryptoService.Encrypt(dto.Password);
        var entity = UserSignupDTO.MapToEntity(_mapper, dto);
        entity.Password = hash;

        await _context.AddAsync(entity);

        var token = await _tokenService.GenerateTokenAsync(entity);

        var result = UserLoggedDTO.MapFromEntity(entity, token);

        await _context.SaveChangesAsync();
        return result;
    }

    private class SignUpValidation : AbstractValidator<UserSignupDTO>
    {
        public SignUpValidation() 
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage(DomainErrors.User.InvalidEmailFormat);

            RuleFor(x => x.Password)
                .Equal(x => x.ConfirmPassword)
                .WithMessage(DomainErrors.User.PasswordDontMatch)
                .NotEmpty()
                .WithMessage($"The field password is Required");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First Name is Required");

            RuleFor(x => x.LastName)
               .NotEmpty()
               .WithMessage("Last Name is Required");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .WithMessage("Password Confirmation is required");

        }
    }


}
