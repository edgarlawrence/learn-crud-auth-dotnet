using API_practice.Model;
using Microsoft.EntityFrameworkCore;

namespace API_practice.Context
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options) 
        {
        }
        public DbSet<Customers> Customers { get; set; }
    }
}
