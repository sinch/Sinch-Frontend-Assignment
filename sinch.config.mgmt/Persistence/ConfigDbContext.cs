namespace Sinch.Config.Mgmt.Persistence;

public class ConfigDbContext : DbContext
{
    public ConfigDbContext(DbContextOptions<ConfigDbContext> options)
        : base(options)
    {
    }

    public DbSet<Application> Applications => Set<Application>();

    public DbSet<Environment> Environments => Set<Environment>();

    public DbSet<Configuration> Configurations => Set<Configuration>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        SeedData.Seed(modelBuilder);
    }
}
