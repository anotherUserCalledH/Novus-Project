
using Calculator;
using Calculator.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CalculatorAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);


			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

/*			builder.Services.AddDbContext<CalculatorLogDbContext>(
				options =>
				{
					options.UseSqlServer(builder.Configuration["ConnectionStrings:ConnectionString"]);
				});
			builder.Services.AddScoped<LogMessageRepository>();
			builder.Services.AddScoped<IDiagnostics, DatabaseDiagnosticsEF>();*/

			builder.Services.AddScoped<SqlConnection>(provider =>
			{
				string connectionString = builder.Configuration["ConnectionStrings:ConnectionString"];
				return new SqlConnection(connectionString);
			});
			builder.Services.AddScoped<IDiagnostics, DatabaseDiagnosticsSQL>();

			builder.Services.AddScoped<ISimpleCalculator, SimpleCalculator>();


			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
