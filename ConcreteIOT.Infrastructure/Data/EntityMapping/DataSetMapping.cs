using ConcreteIOT.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConcreteIOT.Infrastructure.Data.EntityMapping;

public class DataSetMapping : IEntityTypeConfiguration<DataSet>
{
    public void Configure(EntityTypeBuilder<DataSet> builder)
    {
        builder.HasKey(d => d.Id);

        builder.HasOne(d => d.Element)
            .WithMany(e => e.DataSets)
            .HasForeignKey(d => d.ElementId);
        
        builder.HasOne(d => d.Device)
            .WithMany(e => e.DataSets)
            .HasForeignKey(d => d.DeviceId);
    }
}