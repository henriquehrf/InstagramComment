using Newtonsoft.Json;
using System.Collections.Generic;

namespace InstagramComment.Models
{
	public class Config
	{
		[JsonProperty("URL_INSTAGRAM")]
		public string UrlInstagram { get; set; }
		[JsonProperty("TENTATIVAS")]
		public int Tentativas { get; set; }
		[JsonProperty("CONTAS")]
		public string Contas { get; set; }
		[JsonProperty("COOKIE")]
		public IList<string> Cookies { get; set; }
	}
}
