using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
	public class ConsoleDiagnostics : IDiagnostics
	{
		public void Log(string message)
		{
			Console.WriteLine(message);
		}
	}
}
