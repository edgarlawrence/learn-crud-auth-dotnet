using API_practice.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API_practice.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {
        }

        // override OnModelCreating
        // This method is executed when a model create
        // For instance, Seed method can call inside it and insert data inside the database when model wants to be created.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Genre>()
                .HasMany(p => p.Music)
                .WithOne(p => p.Genre)
                .HasForeignKey(c => c.GenreId);
        }

        public DbSet<Music> Music { get; set; }
        public DbSet<Genre> Genre { get; set; }
    }
}
