using Microsoft.EntityFrameworkCore;
// using AmadeusAPI.Models; // Cuando se creen los modelos, descomentar esta línea

namespace AmadeusAPI.Data
{
    public class AmadeusAPIDbContext : DbContext
    {
        public AmadeusAPIDbContext(DbContextOptions<AmadeusAPIDbContext> options) : base(options)
        {
        }
    }
}