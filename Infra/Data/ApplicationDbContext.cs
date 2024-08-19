namespace IWantApp.Infra.Data;

using IWantApp.Domain.Products;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().Property(propertyExpression => propertyExpression.Name).IsRequired();
        modelBuilder.Entity<Product>().Property(propertyExpression => propertyExpression.Description).HasMaxLength(255);

        modelBuilder.Entity<Category>().Property(propertyExpression => propertyExpression.Name).IsRequired();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().HaveMaxLength(100);
        base.ConfigureConventions(configurationBuilder);
    }
}
