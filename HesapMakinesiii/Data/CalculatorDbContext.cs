using System;
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

    public class Calculation
    {
        public int Id { get; set; }
        public string Expression { get; set; }
        public double Result { get; set; }
        public DateTime Timestamp { get; set; }
    }
}