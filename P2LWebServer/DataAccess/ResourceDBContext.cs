using Microsoft.EntityFrameworkCore;
using P2LWebServer.Model;

namespace P2LWebServer.DataAccess
{
    public class ResourceDBContext: DbContext
    {
        public DbSet<Resource> Resources { get; set; }     
        public DbSet<Booking> Bookings { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = P2L.db");
        }
    }
}