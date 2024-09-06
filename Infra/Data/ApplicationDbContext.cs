﻿namespace IWantApp.Infra.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<IdentityUser>(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Ignore<Notification>();

        modelBuilder.Entity<Product>().Property(propertyExpression => propertyExpression.Name).IsRequired();
        modelBuilder.Entity<Product>().Property(propertyExpression => propertyExpression.Description).HasMaxLength(255);
        modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(10,2)").IsRequired();

        modelBuilder.Entity<Category>().Property(propertyExpression => propertyExpression.Name).IsRequired();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().HaveMaxLength(100);
        base.ConfigureConventions(configurationBuilder);
    }
}
