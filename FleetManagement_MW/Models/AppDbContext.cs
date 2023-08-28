using Microsoft.EntityFrameworkCore;
using System;

namespace FleetManagement_MW.Models
{
    public class AppDbContext : DbContext

    {
        public AppDbContext()
        { }
        public AppDbContext(DbContextOptions<AppDbContext> options)
              : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=fleet;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CityMaster>()
            .HasOne(c => c.state)
            .WithMany()
            .HasForeignKey(c => c.stateId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HubMaster>()
              .HasOne(h => h.city)
              .WithMany()
              .HasForeignKey(h => h.cityId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HubMaster>()
                .HasOne(h => h.state)
                .WithMany()
                .HasForeignKey(h => h.stateId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AirportMaster>()
               .HasOne(a => a.state)
               .WithMany()
               .HasForeignKey(a => a.stateId)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AirportMaster>()
              .HasOne(a => a.city)
              .WithMany()
              .HasForeignKey(a => a.cityId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AirportMaster>()
             .HasOne(a => a.hub)
             .WithMany()
             .HasForeignKey(a => a.hubId)
           .OnDelete(DeleteBehavior.Restrict);


        }

        private void OnDelete(DeleteBehavior restrict)
        {
            throw new NotImplementedException();
        }

        public DbSet<CityMaster> CityMaster { get; set; }
        public DbSet<StateMaster> StateMaster { get; set; }

        public DbSet<HubMaster> HubMaster { get; set; }
    }
}