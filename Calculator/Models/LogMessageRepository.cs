using Microsoft.EntityFrameworkCore;

namespace Calculator.Models;

public class LogMessageRepository
{
	private readonly CalculatorLogDbContext _dbContext;

	public LogMessageRepository(CalculatorLogDbContext dbContext)
	{
		_dbContext = dbContext;
	}
	public IEnumerable<LogMessage> AllMessages
	{
		get
		{
			return _dbContext.LogMessage;
		}
	}

	public LogMessage GetMessageById(int message_id)
	{
		return _dbContext.LogMessage.FirstOrDefault(l => l.message_id == message_id);
	}

	public void AddNewMessage(LogMessage message)
	{
		_dbContext.LogMessage.Add(message);
		_dbContext.SaveChanges();
	}
}
