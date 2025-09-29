using ConcreteIOT.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConcreteIOT.Infrastructure.Data.EntityMapping;

public class ElementMapping : IEntityTypeConfiguration<Element>
{
    public void Configure(EntityTypeBuilder<Element> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.Project)
            .WithMany(p => p.Elements)
            .HasForeignKey(e => e.ProjectId);
        
        builder.HasOne(e => e.ConcreteMix)
            .WithMany(c => c.Elements)
            .HasForeignKey(e => e.ConcreteMixId);
    }
}