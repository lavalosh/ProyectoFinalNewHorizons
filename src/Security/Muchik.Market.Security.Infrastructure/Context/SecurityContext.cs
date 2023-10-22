using Microsoft.EntityFrameworkCore;
using Muchik.Market.Security.Domain.Entities;
using Muchik.Market.Security.Infrastructure.Configuration;

namespace Muchik.Market.Security.Infrastructure.Context;

public class SecurityContext : DbContext
{
    public SecurityContext(DbContextOptions<SecurityContext> options) : base(options) { }

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("USERS");
        modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
