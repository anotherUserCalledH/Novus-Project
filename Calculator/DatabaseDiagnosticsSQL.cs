using Calculator.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
	public class DatabaseDiagnosticsSQL : IDiagnostics
	{
		SqlConnection _connection;

		public DatabaseDiagnosticsSQL(SqlConnection connection)
		{
			_connection = connection;
		}

		public void Log(string message)
		{
			SqlCommand command = new SqlCommand("CreateLogMessage", _connection);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.AddWithValue("@LogTime", DateTime.Now);
			command.Parameters.AddWithValue("@Message", message);
			_connection.Open();
			command.ExecuteNonQuery();
			_connection.Dispose();
		}
	}
}
