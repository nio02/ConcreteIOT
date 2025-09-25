using ConcreteIOT.Application.Models;
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
}