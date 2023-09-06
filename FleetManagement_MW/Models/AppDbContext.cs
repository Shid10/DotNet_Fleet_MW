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

          modelBuilder.Entity<BookingDetails>()
                .HasOne(bd => bd.booking)
                .WithMany()
                .HasForeignKey(bd => bd.bookingId)
                .OnDelete(DeleteBehavior.Restrict);

          modelBuilder.Entity<BookingDetails>()
                .HasOne(bd => bd.addOn)
                .WithMany()
                .HasForeignKey(bd => bd.addOnId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<BookingHeaderReservation>()
                .HasOne(br => br.cust)
                .WithMany()
                .HasForeignKey(br => br.customerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookingHeaderReservation>()
               .HasOne(br => br.carType)
               .WithMany()
               .HasForeignKey(br => br.carTypeId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CarMaster>()
               .HasOne(cm => cm.carType)
               .WithMany()
               .HasForeignKey(cm => cm.carTypeId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CarMaster>()
               .HasOne(cm => cm.hub)
               .WithMany()
               .HasForeignKey(cm => cm.hubId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CarTypeMaster>()
               .HasOne(ct => ct.hub)
               .WithMany()
               .HasForeignKey(ct => ct.hubId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InvoiceDetailTableReturn>()
               .HasOne(ir => ir.invoice)
               .WithMany()
               .HasForeignKey(ir => ir.invoiceId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InvoiceHeaderTableHandover>()
               .HasOne(th => th.booking)
               .WithMany()
               .HasForeignKey(th => th.bookingId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InvoiceHeaderTableHandover>()
                           .HasOne(th => th.cust)
                           .WithMany()
                           .HasForeignKey(th => th.customerId)
                           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InvoiceHeaderTableHandover>()
               .HasOne(th => th.car)
               .WithMany()
               .HasForeignKey(th=> th.carId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MembershipRegistration>()
               .HasOne(mr => mr.cust)
               .WithMany()
               .HasForeignKey(mr => mr.customerId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MembershipRegistration>()
               .HasOne(mr => mr.carType)
               .WithMany()
               .HasForeignKey(mr => mr.carTypeId)
               .OnDelete(DeleteBehavior.Restrict);



          /*  modelBuilder.Entity<CustomerMaster>()
                .HasOne(cu => cu.city)
                .WithMany()
                .HasForeignKey(cu => cu.cityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CustomerMaster>()
              .HasOne(cu => cu.state)
              .WithMany()
              .HasForeignKey(cu => cu.stateId)
          .OnDelete(DeleteBehavior.Restrict);*/
        }

        private void OnDelete(DeleteBehavior restrict)
        {
            throw new NotImplementedException();
        }

        public DbSet<CityMaster> CityMasters { get; set; }
        public DbSet<StateMaster> StateMasters { get; set; }

        public DbSet<HubMaster> HubMasters { get; set; }

        public DbSet<CustomerMaster> CustomerMasters { get; set; }

        public DbSet<AirportMaster> AirportMasters { get; set;}
        public DbSet<BookingDetails> BookingDetails { get; set; }

        public DbSet<BookingHeaderReservation> BookingHeaderReservations { get; set; }

        public DbSet<CarMaster> CarMasters { get; set; }    

        public DbSet<CarTypeMaster> CarTypeMasters { get; set; }
        public DbSet<AddOnMaster> AddOnMasters { get; set; } 
        public DbSet<InvoiceDetailTableReturn> InvoiceDetailTableReturns { get;}
        public DbSet<InvoiceHeaderTableHandover> InvoiceHeaderTableHandovers { get; set; }
        public DbSet<MembershipRegistration> MembershipRegistrations { get; set; }
        
    }
}