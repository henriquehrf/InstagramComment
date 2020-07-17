using InstagramComment.Core.Interfaces;
using InstagramComment.Models;
using OpenQA.Selenium;

namespace InstagramComment
{
	public class EngineSelenium: ISeleniumComentario
	{

		private IWebDriver _driver;
		private ILogDaAplicacao _logDaAplicacao;
		private Config _configuracao;
		public EngineSelenium(IWebDriver driver, 
							  ILogDaAplicacao logDaAplicacao,
							  Config configuracao)
		{
			_driver = driver;
			_logDaAplicacao = logDaAplicacao;
			_configuracao = configuracao;
		}

		public void Comentar(string conteudo, Cookie cookie)
		{
			new InstagramPO(_driver, _logDaAplicacao, _configuracao).Navegar(cookie)
									.Comentar(conteudo);
		}
	}
}
