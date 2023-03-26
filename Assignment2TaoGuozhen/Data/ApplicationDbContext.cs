using Assignment2TaoGuozhen.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Assignment2TaoGuozhen.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Foodcourt_FishingSpot>().HasKey(ff => new
            {
                ff.FoodcourtId,
                ff.FishingSpotId
            });

            modelBuilder.Entity<Foodcourt_FishingSpot>().HasOne(f => f.FishingSpot)
                .WithMany(ff => ff.Foodcourts_FishingSpots).HasForeignKey(f => f.FishingSpotId);

            modelBuilder.Entity<Foodcourt_FishingSpot>().HasOne(f => f.Foodcourt)
                .WithMany(ff => ff.Foodcourts_FishingSpots).HasForeignKey(f => f.FoodcourtId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ManageCompany> ManageCompanies { get; set; }

        public DbSet<Park> Parks { get; set; }

        public DbSet<Foodcourt> Foodcourts { get; set; }

        public DbSet<FishingSpot> FishingSpots { get; set;}

        public DbSet<Foodcourt_FishingSpot> FoodcourtsFishingSpots { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public DbSet<Promotion> Promotions { get; set; }
    }
}