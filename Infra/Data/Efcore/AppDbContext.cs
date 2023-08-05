using Domain.Entities;
using Infra.Data.Efcore.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Efcore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Chair> Chairs { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Category> Categories { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new EntityConfiguration());

        builder.ApplyConfiguration(new CinemaConfiguration());

        builder.ApplyConfiguration(new RoomConfiguration());

        builder.ApplyConfiguration(new SessionConfiguration());

        builder.ApplyConfiguration(new TicketConfiguration());

        builder.ApplyConfiguration(new MovieConfiguration());

        builder.ApplyConfiguration(new CategoryConfiguration());

        builder.ApplyConfiguration(new UserConfiguration());

        builder.ApplyConfiguration(new ChairConfiguration());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder.Properties<TimeOnly>()
            .HaveConversion<TimeOnlyConverter>();
    }
}
