using Microsoft.EntityFrameworkCore;

namespace GeekShooping.ProductAPI.Model.Context;

public class SqlContext : DbContext
{
    public SqlContext() { }

    public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData( new Product
        {
            Id = 5,
            Name = "Name2kasjfsadfs",
            Price = new decimal(100.25),
            Description = "Description",
            ImageUrl = "https://www.yahoo.com.br",
            CategoryName = "Exemplo1",
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 6,
            Name = "Name3asdfsadf",
            Price = new decimal(100.25),
            Description = "Description",
            ImageUrl = "https://www.uol.com.br",
            CategoryName = "Exemplo2",
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 7,
            Name = "Name4fas1df3sadfsda",
            Price = new decimal(100.25),
            Description = "Description",
            ImageUrl = "https://www.terra.com.br",
            CategoryName = "Exemplo3",
        });
    }
}
