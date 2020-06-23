using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramComment.Models
{
	public class LogAplicacao
	{
		public int Sequencia { get; set; }
		public string Conteudo { get; set; }
		public DateTime DataHoraLog { get; set; }
	}
}
