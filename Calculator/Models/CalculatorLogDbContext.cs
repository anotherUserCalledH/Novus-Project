using Microsoft.EntityFrameworkCore;

namespace Calculator.Models
{
	public class CalculatorLogDbContext: DbContext
	{
		public CalculatorLogDbContext(DbContextOptions<CalculatorLogDbContext> options) : base (options)
		{
		}

		public DbSet<LogMessage> LogMessage { get; set; }
	}
}
