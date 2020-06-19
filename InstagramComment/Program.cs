using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace InstagramComment
{
	class Program
	{
		static void Main(string[] args)
		{
			string path = @"C:\Users\Henrique Firmino\Desktop\contas.txt";
			string urlInstagram = @"https://www.instagram.com/p/CBjVIEHBKoh/";
			IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
			IArquivoOperacao arquivoOperacao = new ArquivoServices(new ProcessadorDeArquivoTxt());
			ISeleniumOperacao seleniumOperacao = new SeleniumServices(driver, urlInstagram);
			var conteudo = arquivoOperacao.LerConteudoArquivoTxt(path);
			for (int i = 0; i < conteudo.Length; i++)
			{
				for (int j = 0; j < conteudo.Length; j++)
				{
					for (int k = 0; k < conteudo.Length; k++)
					{
						if(i != j && i !=k && j != k)
						{
							seleniumOperacao.Comentar($"{conteudo[i]},{conteudo[j]},{conteudo[k]}");
							Thread.Sleep(60000);
						}
					}
				}
			}
		}
	}
}
