using Moq;
using NUnit.Framework;

namespace Calculator.Tests
{
	public class Fixtures
	{
		[TestCase(1, 5, 6)]
		[TestCase(0, 5, 5)]
		[TestCase(-2312, -3124235, -3126547)]
		public void Add_A_With_B_Returns_Sum(int a, int b, int sum)
		{
			//Arrange
			Mock<IDiagnostics> mockDiagnostics = new Mock<IDiagnostics>();
			ISimpleCalculator calculator = new SimpleCalculator(mockDiagnostics.Object);

			//Act
			int output = calculator.Add(a, b);

			//Assert
			Assert.That(output, Is.EqualTo(sum));
			mockDiagnostics.Verify(x => x.Log(It.IsAny<string>()));
		}

		[TestCase(1, 5, -4)]
		[TestCase(0, 5, -5)]
		[TestCase(-2312, -3124235, 3121923)]
		public void Subtract_B_From_A_Returns_Difference(int a, int b, int difference)
		{
			//Arrange
			Mock<IDiagnostics> mockDiagnostics = new Mock<IDiagnostics>();
			ISimpleCalculator calculator = new SimpleCalculator(mockDiagnostics.Object);

			//Act
			int output = calculator.Subtract(a, b);

			//Assert
			Assert.That(output, Is.EqualTo(difference));
			mockDiagnostics.Verify(x => x.Log(It.IsAny<string>()));
		}

		[TestCase(1, 5, 5)]
		[TestCase(0, 5, 0)]
		[TestCase(-25, -10, 250)]
		public void Multiply_A_With_B_Returns_Product(int a, int b, int product)
		{
			//Arrange
			Mock<IDiagnostics> mockDiagnostics = new Mock<IDiagnostics>();
			ISimpleCalculator calculator = new SimpleCalculator(mockDiagnostics.Object);

			//Act
			int output = calculator.Multiply(a, b);

			//Assert
			Assert.That(output, Is.EqualTo(product));
			mockDiagnostics.Verify(x => x.Log(It.IsAny<string>()));
		}

		[TestCase(10, 2, 5)]
		[TestCase(-250, -10, 25)]
		public void Divide_A_By_B_Returns_Quotient(int a, int b, int quotient)
		{
			//Arrange
			Mock<IDiagnostics> mockDiagnostics = new Mock<IDiagnostics>();
			ISimpleCalculator calculator = new SimpleCalculator(mockDiagnostics.Object);

			//Act
			int output = calculator.Divide(a, b);

			//Assert
			Assert.That(output, Is.EqualTo(quotient));
			mockDiagnostics.Verify(x => x.Log(It.IsAny<string>()));
		}
		
		[Test]
		public void Divide_A_By_0_Throws_Exception()
		{
			Mock<IDiagnostics> mockDiagnostics = new Mock<IDiagnostics>();
			ISimpleCalculator calculator = new SimpleCalculator(mockDiagnostics.Object);
			int a = 5;
			int b = 0;

			Assert.That(() => calculator.Divide(a, b), Throws.TypeOf<DivideByZeroException>());
		}
	}
}
