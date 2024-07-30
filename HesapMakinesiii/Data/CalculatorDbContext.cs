using HesapMakinesiii.Models;
using Microsoft.EntityFrameworkCore;

namespace HesapMakinesiii.Data
{
    public class CalculatorDbContext : DbContext
    {
        public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options)
            : base(options)
        {
        }

        public DbSet<Calculation> Calculations { get; set; }
    }
}
