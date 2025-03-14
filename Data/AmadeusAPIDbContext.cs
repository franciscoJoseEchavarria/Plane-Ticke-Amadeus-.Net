using Microsoft.EntityFrameworkCore;
using AmadeusAPI.Models; // Descomentar esta línea cuando se creen los modelos de User y User_answers 

namespace AmadeusAPI.Data
{
    public class AmadeusAPIDbContext : DbContext
    {
        public AmadeusAPIDbContext(DbContextOptions<AmadeusAPIDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<User_answers> User_answers { get; set;}
        public DbSet<CityModel> City { get; set; }
        public DbSet<Destination> Destinations { get; set; }

    }
}