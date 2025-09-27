using ConcreteIOT.Application.Models;
using ConcreteIOT.Infrastructure.Data.EntityMapping;
using Microsoft.EntityFrameworkCore;

namespace ConcreteIOT.Infrastructure.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) {}

    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<UserProject> UserProject { get; set; }
    public DbSet<ConcreteMix> ConcreteMixes { get; set; }
    public DbSet<Element> Elements { get; set; }
    public DbSet<DataSet> DataSets { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMapping());
        modelBuilder.ApplyConfiguration(new ProjectMapping());
        modelBuilder.ApplyConfiguration(new UserProjectMapping());
        modelBuilder.ApplyConfiguration(new ConcreteMixMapping());
        modelBuilder.ApplyConfiguration(new ElementMapping());
        modelBuilder.ApplyConfiguration(new DataSetMapping());
    }
}