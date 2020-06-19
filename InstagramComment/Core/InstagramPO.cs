using InstagramComment.Core.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace InstagramComment
{
	public class InstagramPO: IDisposable
	{
		private IWebDriver _driver;
		private ILogDaAplicacao _logDaAplicacao;
		private By _byLabelComentario;
		private By _byButtonConfirmComentario;

		public InstagramPO(IWebDriver driver, ILogDaAplicacao logDaAplicacao)
		{
			_driver = driver;
			_logDaAplicacao = logDaAplicacao;
			_byLabelComentario = By.XPath("/html/body/div[1]/section/main/div/div[1]/article/div[2]/section[3]/div/form/textarea");
			_byButtonConfirmComentario = By.XPath("/html/body/div[1]/section/main/div/div[1]/article/div[2]/section[3]/div/form/button");
		}

		public InstagramPO Navegar(string url)
		{
			_driver.Navigate().GoToUrl("http://instagram.com/");
			_driver.Manage().Cookies.AddCookie(new Cookie("ig_did", "50D04179-E938-4E51-9C36-F8A963C1BF67"));
			_driver.Manage().Cookies.AddCookie(new Cookie("mid", "Xrd8hAALAAE8GBX8goM0MapwYH2p"));
			_driver.Manage().Cookies.AddCookie(new Cookie("fbm_124024574287414", "base_domain=.instagram.com"));
			_driver.Manage().Cookies.AddCookie(new Cookie("csrftoken", "zDZCDffqmTlcigCLIXA32Gl7QqUqKSoe"));
			_driver.Manage().Cookies.AddCookie(new Cookie("ds_user_id", "916846849"));
			_driver.Manage().Cookies.AddCookie(new Cookie("sessionid", "916846849%3AIkOyBcKBCCgyxU%3A13"));
			_driver.Manage().Cookies.AddCookie(new Cookie("shbid", "18634"));
			_driver.Manage().Cookies.AddCookie(new Cookie("shbts", "1592502877.4127955"));
			_driver.Manage().Cookies.AddCookie(new Cookie("rur", "FTW"));
			_driver.Navigate().GoToUrl(url);
			return this;
		}

		public InstagramPO Comentar(string conteudo)
		{
			_driver.FindElement(_byLabelComentario).Click();
			_driver.FindElement(_byLabelComentario).SendKeys(conteudo);
			_driver.FindElement(_byButtonConfirmComentario).Click();
			Thread.Sleep(5000);
			IList<IWebElement> elementos = _driver.FindElements(By.TagName("a"));

			if (elementos.Any(a => a.Text.Contains("@henriquerfirmino")))
				_logDaAplicacao.RegistrarLog(conteudo);

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
