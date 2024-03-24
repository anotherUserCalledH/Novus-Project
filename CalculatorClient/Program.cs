using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using CalculatorAPI;

namespace CalculatorClient
{
	internal class Program
	{
		private static async Task<int> SendApiRequest(HttpClient httpClient, string endPoint, CalculationRequest calcRequest)
		{
			string calcRequestString = JsonConvert.SerializeObject(calcRequest);

			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, endPoint);
			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			request.Content = new StringContent(calcRequestString);
			request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			HttpResponseMessage response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

			int result;
			using (Stream inputStream = await response.Content.ReadAsStreamAsync())
			{
				response.EnsureSuccessStatusCode();
				using (StreamReader streamReader = new StreamReader(inputStream))
				{
					using (JsonTextReader jsonReader = new JsonTextReader(streamReader))
					{
						JsonSerializer serializer = new JsonSerializer();
						result = serializer.Deserialize<int>(jsonReader);
					}
				}
			}

			return result;
		}

		public static async Task Main(string[] args)
		{
			HttpClient httpClient = new HttpClient();
			httpClient = new HttpClient();
			httpClient.BaseAddress = new Uri("http://localhost:5085/api/calculator/");
			httpClient.Timeout = new TimeSpan(0, 0, 30);

			Console.WriteLine("Welcome to the Integer Calculator");

			Dictionary<string, string> operators = new Dictionary<string, string>();
			operators.Add("+", "add");
			operators.Add("-", "subtract");
			operators.Add("*", "multiply");
			operators.Add("/", "divide");

			Console.WriteLine("Please enter one of the following operators");
			foreach (KeyValuePair<string, string> _operator in operators)
			{
				Console.WriteLine(_operator.Key);
			}
			Console.Write("Operator: ");

			string input = Console.ReadLine();
			KeyValuePair<string, string> chosenOperator = new KeyValuePair<string, string>(null, null);

			foreach (KeyValuePair<string, string> _operator in operators)
			{
				if (input == _operator.Key)
				{
					chosenOperator = _operator;
					break;
				}
			}

			if (chosenOperator.Key != null)
			{
				Console.WriteLine("Please enter an integer for your first operand");
				Console.Write("Operand A: ");
				string operandA = Console.ReadLine();
				Console.WriteLine("Please enter an integer for your second operand");
				Console.Write("Operand B: ");
				string operandB = Console.ReadLine();


				Console.Write($"Chosen Operation: {operandA} {chosenOperator.Key} {operandB}");
				CalculationRequest request = new CalculationRequest();
				
				try
				{
					request.NumberA = int.Parse(operandA);
					request.NumberB = int.Parse(operandB);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.StackTrace);
				}

				int result = await SendApiRequest(httpClient, chosenOperator.Value, request);
				Console.Write(" = " + result);				
			}
			else
			{
				Console.WriteLine("Error: Invalid Operator");
			}
			Console.ReadLine();
		}
	}
}
