using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Calculator
{
	public class Program
	{
		static void Main(string[] args)
		{
			ServiceProvider serviceProvider = new ServiceCollection().AddSingleton<IDiagnostics, ConsoleDiagnostics>().AddTransient<SimpleCalculator>().BuildServiceProvider();
			SimpleCalculator calculator = serviceProvider.GetRequiredService<SimpleCalculator>();

			calculator.Add(5, 5);
		}
	}
}
