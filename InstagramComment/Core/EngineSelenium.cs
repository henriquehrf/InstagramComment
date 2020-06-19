using InstagramComment.Core.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace InstagramComment
{
	public class EngineSelenium: ISeleniumComentario
	{

		private IWebDriver _driver;
		private ILogDaAplicacao _logDaAplicacao;
		private string _url;

		public EngineSelenium(IWebDriver driver, ILogDaAplicacao logDaAplicacao, string url)
		{
			_driver = driver;
			_logDaAplicacao = logDaAplicacao;
			_url = url;
		}

		public void Comentar(string conteudo)
		{
			new InstagramPO(_driver, _logDaAplicacao).Navegar(_url)
									.Comentar(conteudo);
		}
	}
}
