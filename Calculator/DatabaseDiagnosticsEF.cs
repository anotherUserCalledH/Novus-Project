using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calculator
{
	public class DatabaseDiagnosticsEF : IDiagnostics
	{
		private readonly LogMessageRepository _repository;

		public DatabaseDiagnosticsEF(LogMessageRepository repository)
		{
			_repository = repository;
		}
		public void Log(string message)
		{
			LogMessage logMessage = new LogMessage();
			logMessage.message = message;
			logMessage.time = DateTime.Now;
			_repository.AddNewMessage(logMessage);
		}
	}
}
