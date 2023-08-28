using Microsoft.EntityFrameworkCore;

namespace FleetManagement_MW.Models
{
    public class Appdbcontext : DbContext
    {
        public Appdbcontext()
        { }
        public Appdbcontext(DbContextOptions<Appdbcontext> options)
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
            .HasForeignKey(c => c.stateId);
        }
        public DbSet<CityMaster> CityMaster { get; set; }
        public DbSet<StateMaster> StateMaster { get; set; }
    }
    }


