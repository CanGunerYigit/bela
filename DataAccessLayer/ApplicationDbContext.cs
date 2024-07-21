using Microsoft.EntityFrameworkCore;

namespace HesapMakinesiii.Data
{
    public class ApplicationDbContext : DbContext
    {
     
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CalculationHistory> CalculationHistories { get; set; }

       
    }
}
