using AWDProjectFinal.Areas.Identity.Data;
using AWDProjectFinal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AWDProjectFinal.Data
{
    public class AWDProjectFinalContext : IdentityDbContext<ApplicationUser>
    {
        public AWDProjectFinalContext(DbContextOptions<AWDProjectFinalContext> options ): base(options)
        {

        }
        public DbSet<ApartmentModel> ApartmentModels { get; set; }
        public DbSet<OwnerApartment> OwnerApartments { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OwnerApartment>()
                .HasMany(o => o.Apartments)
                .WithOne(a => a.Owner)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }
    }
}
