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


namespace IoC
{
    public static class DependencyInjection
    {
        public static void ConfigureDependency(this IServiceCollection services, string? connection)
        {
            ConfigureInfra(services, connection);
            ConfigureApp(services);
        }

        public static void ConfigureApp(IServiceCollection services)
        {
            services.AddScoped<ISignup, Signup>();
        }

        public static void ConfigureInfra(IServiceCollection services, string? connection)
        {

            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(connection);
            });

            services.AddAutoMapper(typeof(AutoMapperConfig));
            //services.AddScoped<ITokenService, JwtAdapter>();
            services.AddScoped<ICryptoService, BCryptAdapter>();
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

            CreateMap<User, UserLoggedDTO>()
                .ConstructUsing(x => new UserLoggedDTO(x.FirstName, x.LastName, x.Email, null));
        }
    }
}
