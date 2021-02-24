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
    public DbSet<Customer> Customers {get; set; }
    public DbSet<CountryCustomer> CountryCustomers { get; set; }
    public DbSet<Incident> Incidents { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Registration> Registrations { get; set; }
    public DbSet<Technician> Technicians { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<CountryCustomer>().HasNoKey();
      modelBuilder.Entity<Registration>().HasNoKey();
    }

  }
}
