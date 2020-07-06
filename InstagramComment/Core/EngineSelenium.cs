using InstagramComment.Core.Interfaces;
using OpenQA.Selenium;

namespace InstagramComment
{
	public class EngineSelenium: ISeleniumComentario
	{

		private IWebDriver _driver;
		private ILogDaAplicacao _logDaAplicacao;
		private string _url;
		public EngineSelenium(IWebDriver driver, 
							  ILogDaAplicacao logDaAplicacao,
							  string url)
		{
			_driver = driver;
			_logDaAplicacao = logDaAplicacao;
			_url = url;
		}

		public void Comentar(string conteudo, Cookie cookie)
		{
			new InstagramPO(_driver, _logDaAplicacao).Navegar(_url, cookie)
									.Comentar(conteudo);
		}
	}
}
