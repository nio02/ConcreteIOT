using ConcreteIOT.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConcreteIOT.Infrastructure.Data.EntityMapping;

public class ConcreteMixMapping : IEntityTypeConfiguration<ConcreteMix>
{
    public void Configure(EntityTypeBuilder<ConcreteMix> builder)
    {
        builder.HasKey(c => c.Id);
    }
}