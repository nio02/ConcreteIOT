using ConcreteIOT.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConcreteIOT.Infrastructure.Data.EntityMapping;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        
        builder.Property(u => u.Role)
            .HasConversion(new EnumToStringConverter<Role>())
            .HasMaxLength(6)
            .HasDefaultValue(Role.CLIENT);

        builder.HasIndex(u => u.Email).IsUnique();
    }
}