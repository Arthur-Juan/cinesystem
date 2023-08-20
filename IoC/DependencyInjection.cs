using AutoMapper;
using Application.DTOs.Requests;
using Application.DTOs.Response;
using Application.Features.Authentication;
using Application.Interfaces;
using Domain.Entities;
using Domain.Services;
using Infra.Data.Efcore;
using Infra.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;

namespace IoC
{
    public static class DependencyInjection
    {
        public static void ConfigureDependency(this WebApplicationBuilder builder, string? connection)
        {
            ConfigureInfra(builder, connection);
            ConfigureApp(builder);
        }

        public static void ConfigureApp( WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ISignup, Signup>();
        }

        public static void ConfigureInfra(WebApplicationBuilder builder, string? connection)
        {

            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(connection);
            });

            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
            builder.Services.AddScoped<ICryptoService, BCryptAdapter>();
            builder.Services.AddScoped<ITokenService>(x =>
            {
                return new JwtAdapter(builder.Configuration["Jwt:Key"]!);

            });
            
        }
    }
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User, UserSignupDTO>().ReverseMap();

           /* CreateMap<User, UserLoggedDTO>().ReverseMap()
                .ForCtorParam(nameof(User.FirstName), opt => opt.MapFrom(source => source.FirstName))
                .ForCtorParam(nameof(User.LastName), opt => opt.MapFrom(source => source.LastName))
                .ForCtorParam(nameof(User.Email), opt => opt.MapFrom(source => source.Email))
                .ForAllMembers(opt => opt.Ignore());*/

        }
    }
}
