using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting2021_Caeruleum.Models
{
  public class CaeruleumContext : DbContext
  {
    public CaeruleumContext(DbContextOptions<CaeruleumContext> options)
    : base(options)
    {

    }

    public DbSet<Country> Countries { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Incident> Incidents { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Registration> Registrations { get; set; }
    public DbSet<Technician> Technicians { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<Customer>().HasIndex(c => c.Email).IsUnique();
      modelBuilder.Entity<Country>().HasData(
        new Country() { Id = 1, Name = "Austria" },
        new Country() { Id = 2, Name = "Canada" },
        new Country() { Id = 3, Name = "England" },
        new Country() { Id = 4, Name = "France" },
        new Country() { Id = 5, Name = "Germany" },
        new Country() { Id = 6, Name = "Greece" },
        new Country() { Id = 7, Name = "Hungary" },
        new Country() { Id = 8, Name = "Italy" },
        new Country() { Id = 9, Name = "Ireland" },
        new Country() { Id = 10, Name = "Portugal" },
        new Country() { Id = 11, Name = "Scotland" },
        new Country() { Id = 12, Name = "Spain" },
        new Country() { Id = 13, Name = "United States" }
        );
    }

  }
}
