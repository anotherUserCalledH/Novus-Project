using Calculator;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorAPI.Controllers
{
	[ApiController]
	[Route("api/calculator/")]
	public class CalculatorController : ControllerBase
	{
		private readonly ISimpleCalculator _calculator;
		public CalculatorController(ISimpleCalculator calculator)
		{
			_calculator = calculator;
		}

		[HttpPost("add")]
		public ActionResult GetSum(CalculationRequest request)
		{
			int sum = _calculator.Add(request.NumberA, request.NumberB);
			return Ok(sum);
		}

		[HttpPost("subtract")]
		public ActionResult GetDifference(CalculationRequest request)
		{
			int difference = _calculator.Subtract(request.NumberA, request.NumberB);
			return Ok(difference);
		}

		[HttpPost("multiply")]
		public ActionResult GetProduct(CalculationRequest request)
		{
			int product = _calculator.Multiply(request.NumberA, request.NumberB);
			return Ok(product);
		}

		[HttpPost("divide")]
		public ActionResult GetQuotient(CalculationRequest request)
		{
			int quotient = _calculator.Divide(request.NumberA, request.NumberB);
			return Ok(quotient);
		}
	}
}
