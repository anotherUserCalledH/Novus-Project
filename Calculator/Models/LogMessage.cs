using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models
{
	public class LogMessage
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int message_id { get; set; }
		public DateTime time { get; set; }
		public string message { get; set; }
	}
}
