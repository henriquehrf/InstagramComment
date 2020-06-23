using InstagramComment.Core;
using InstagramComment.Core.Interfaces;
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
		const string PATH_INSTAGRAM_CONTAS = @"C:\Users\Henrique Firmino\Desktop\contas.txt";
		const string PATH_LOG_ERRO_APLICACAO = @"C:\Users\Henrique Firmino\Desktop\InstagramComment_Error_LogApp.txt";
		const string PATH_LOG_REGISTROS_APLICACAO = @"C:\Users\Henrique Firmino\Desktop\InstagramComment_LogApp.txt";
		const string URL_INSTAGRAM = @"https://www.instagram.com/p/CBjVIEHBKoh/";
		const int TENTATIVAS = 3;
		static void Main(string[] args)
		{
			int tentativasExecutadas = 0;
			bool processamentoConcluido = false;
			while ((tentativasExecutadas < TENTATIVAS) && !processamentoConcluido)
			{
				try
				{
					IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
					ILeitorDeArquivoTxt arquivoOperacao = new LeitorDeArquivoTxt(new ProcessadorDeArquivoTxt());
					ILogDaAplicacao logDaAplicacao = new GravadorDeLogDaAplicacao(new GravadorDeArquivoTxt(PATH_LOG_REGISTROS_APLICACAO));
					ISeleniumComentario seleniumOperacao = new EngineSelenium(driver, logDaAplicacao, URL_INSTAGRAM);
					Random random = new Random();
					var conteudo = arquivoOperacao.LerConteudoArquivoTxt(PATH_INSTAGRAM_CONTAS);
					for (int i = 0; i < conteudo.Length; i++)
					{
						for (int j = 0; j < conteudo.Length; j++)
						{
							for (int k = 0; k < conteudo.Length; k++)
							{
								if (i != j && i != k && j != k)
								{
									var registro = $"{conteudo[i]} {conteudo[j]} {conteudo[k]}";
									seleniumOperacao.Comentar(registro);
									Thread.Sleep(59250);
									Thread.Sleep(random.Next(105, 30000));
								}
							}
						}
					}
					processamentoConcluido = true;
				}
				catch (Exception ex)
				{
					ILogDaAplicacao logDaAplicacao = new GravadorDeLogDaAplicacao(new GravadorDeArquivoTxt(PATH_LOG_ERRO_APLICACAO));
					logDaAplicacao.RegistrarLog(ex.Message);
					tentativasExecutadas++;
					Thread.Sleep(60000);
				}
			}
		}
	}
}
