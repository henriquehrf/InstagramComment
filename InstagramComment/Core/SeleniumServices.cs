using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace InstagramComment
{
	public class SeleniumServices: ISeleniumOperacao
	{

		private IWebDriver _driver;
		private string _url;

		public SeleniumServices(IWebDriver driver, string url)
		{
			_driver = driver;
			_url = url;
		}

		public void Comentar(string conteudo)
		{
			new InstagramPO(_driver).Navegar(_url)
									.Comentar(conteudo);
		}
	}
}
