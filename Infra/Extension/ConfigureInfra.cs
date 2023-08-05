using Infra.Data.Efcore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infra.Mapper;

namespace Infra.Extension;

public static class ConfigureInfra
{
    public static void ConfigInfra(this IServiceCollection services, string connection)  
    {
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(connection);
        });

        services.AddAutoMapper(typeof(AutoMapperConfig));
    }
}
