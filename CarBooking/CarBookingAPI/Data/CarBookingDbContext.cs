using CarBookingAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CarBookingAPI.Data
{
    public class CarBookingDbContext : DbContext
    {
        public CarBookingDbContext(DbContextOptions<CarBookingDbContext> options) : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }
    }
}
