//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodOrdering.Models
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions options):base(options)
        {
        }
        //public DbSet<Registration> Registrations { get; set; }
        public DbSet<Customers>Customers { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Feedback> Feedback{ get; set; }
        
    }
}
