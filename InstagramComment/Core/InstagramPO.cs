using InstagramComment.Core.Interfaces;
using InstagramComment.Models;
using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace InstagramComment
{
	public class InstagramPO : IDisposable
	{
		private IWebDriver _driver;
		private ILogDaAplicacao _logDaAplicacao;
		private By _byLabelComentario;
		private By _byButtonConfirmComentario;
		private By _byComentariosPublicados;
		public static int _quantidadeDeComentariosValidos = 0;

		public InstagramPO(IWebDriver driver, ILogDaAplicacao logDaAplicacao)
		{
			_driver = driver;
			_logDaAplicacao = logDaAplicacao;
			_byLabelComentario = By.XPath("/html/body/div[1]/section/main/div/div[1]/article/div[2]/section[3]/div/form/textarea");
			_byButtonConfirmComentario = By.XPath("/html/body/div[1]/section/main/div/div[1]/article/div[2]/section[3]/div/form/button");
			_byComentariosPublicados = By.TagName("span");
		}

		public InstagramPO Navegar(string url, Cookie cookie)
		{
			if (!_driver.Manage().Cookies.AllCookies.Any(c => c.Name == cookie.Name && c.Value == cookie.Value))
				_driver.Manage().Cookies.DeleteAllCookies();
			
			_driver.Navigate().GoToUrl("http://instagram.com/");
			_driver.Manage().Cookies.AddCookie(cookie);
			_driver.Navigate().GoToUrl(url);
			return this;
		}

		public InstagramPO Comentar(string conteudo)
		{
			_driver.FindElement(_byLabelComentario).Click();
			_driver.FindElement(_byLabelComentario).SendKeys(conteudo);
			_driver.FindElement(_byButtonConfirmComentario).Click();
			Thread.Sleep(3000);
			IList<IWebElement> elementos = _driver.FindElements(_byComentariosPublicados);

			foreach (var item in elementos.AsParallel())
			{
				if (item.Text.Contains(conteudo))
				{
					_quantidadeDeComentariosValidos++;
					var logAplicacao = new LogAplicacao()
					{
						Conteudo = conteudo,
						DataHoraLog = DateTime.Now,
						Sequencia = _quantidadeDeComentariosValidos
					};
					_logDaAplicacao.RegistrarLog(JsonConvert.SerializeObject(logAplicacao));
				}
			}

			return this;
		}

		public InstagramPO FecharBrowser()
		{
			_driver.Quit();
			return this;
		}

		public void Dispose()
		{
			_driver.Dispose();
		}
	}
}
