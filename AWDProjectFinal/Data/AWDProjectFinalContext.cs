using AWDProjectFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace AWDProjectFinal.Data
{
    public class AWDProjectFinalContext :DbContext
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
        }
    }
}
