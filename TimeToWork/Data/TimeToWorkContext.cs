using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeToWork.Models;
using ServiceProvider = TimeToWork.Models.ServiceProvider;

namespace TimeToWork.Data
{
    public class TimeToWorkContext : DbContext
    {
        public TimeToWorkContext (DbContextOptions<TimeToWorkContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().ToTable(nameof(Service))
                .HasMany(c => c.ServiceProviders)
                .WithMany(i => i.Services);
            modelBuilder.Entity<Client>().ToTable(nameof(Client));
            modelBuilder.Entity<ServiceProvider>().ToTable(nameof(ServiceProvider));
        }
    }
}
