using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Muchik.Market.Security.Domain.Entities;

namespace Muchik.Market.Security.Infrastructure.Configuration;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.Property(e => e.Id)
            .HasColumnName("ID_USER");

        builder.Property(e => e.Username)
            .HasColumnName("USERNAME");

        builder.Property(e => e.Password)
            .HasColumnName("PASSWORD");

        builder.HasNoDiscriminator();

    }
}
