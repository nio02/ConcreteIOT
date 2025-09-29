using ConcreteIOT.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConcreteIOT.Infrastructure.Data.EntityMapping;

public class UserProjectMapping : IEntityTypeConfiguration<UserProject>
{
    public void Configure(EntityTypeBuilder<UserProject> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Role)
            .HasConversion(new EnumToStringConverter<ProjectRole>())
            .HasMaxLength(7)
            .HasDefaultValue(ProjectRole.OWNER);

        builder.HasOne(x => x.User)
            .WithMany(u => u.UserProjects)
            .HasForeignKey(x => x.UserId);

        builder.HasOne(x => x.Project)
            .WithMany(p => p.UserProjects)
            .HasForeignKey(x => x.ProjectId);

        builder.HasIndex(x => new { x.UserId, x.ProjectId }).IsUnique();
    }
}