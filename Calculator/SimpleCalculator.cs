using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
	public class SimpleCalculator : ISimpleCalculator
	{
		IDiagnostics _diagnostics;

		public SimpleCalculator(IDiagnostics diagnostics)
		{
			_diagnostics = diagnostics;
		}

		public int Add(int a, int b)
		{
			int sum = a + b;
			_diagnostics.Log($"Adding {a} and {b}: {sum}");
			return sum;
		}

		public int Subtract(int a, int b)
		{
			int difference = a - b;
			_diagnostics.Log($"Subtracting {b} from {a}: {difference}");
			return difference;
		}

		public int Multiply(int a, int b)
		{
			int product = a * b;
			_diagnostics.Log($"Multiplying {a} and {b}: {product}");
			return product;
		}

		public int Divide(int a, int b)
		{
			int quotient = a / b;
			_diagnostics.Log($"Dividing {a} by {b}: {quotient}");
			return quotient;
		}
	}
}
