using InstagramComment.Core;
using InstagramComment.Core.Interfaces;
using InstagramComment.Models;
using Newtonsoft.Json;
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
		public readonly static string PATH_PROGRAMA = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		public readonly static string PATH_ARQUIVO_CONFIG = string.Concat(PATH_PROGRAMA, "\\config.txt");
		public readonly static string PATH_LOG_ERRO_APLICACAO = string.Concat(PATH_PROGRAMA, "\\error.txt");
		public readonly static string PATH_LOG_REGISTROS_APLICACAO = string.Concat(PATH_PROGRAMA, "\\registro.txt");
		public static Config _config;
		public static ILeitorDeArquivoTxt _leitorDeArquivo = new LeitorDeArquivoTxt();

		static void Main(string[] args)
		{
			ILogDaAplicacao logDaAplicacao = new GravadorDeLogDaAplicacao(new GravadorDeArquivoTxt(PATH_LOG_REGISTROS_APLICACAO));
			ILogDaAplicacao logErroDaAplicacao = new GravadorDeLogDaAplicacao(new GravadorDeArquivoTxt(PATH_LOG_ERRO_APLICACAO));

			try
			{
				_config = JsonConvert.DeserializeObject<Config>(_leitorDeArquivo.LerConteudoArquivoTxt(PATH_ARQUIVO_CONFIG));
				int tentativasExecutadas = 1;
				bool processamentoConcluido = false;
				IWebDriver driver = new ChromeDriver(PATH_PROGRAMA);
				ISeleniumComentario seleniumOperacao = new EngineSelenium(driver, logDaAplicacao, _config.UrlInstagram);
				Random random = new Random();
				IProcessadorDeContasDoInstagram processadorInstagram = new ProcessadorDeContasDoInstagram(_config.Contas);
				processadorInstagram.ProcessarContasDoInstagram(_config.NumeroDeContaPorComentario);
				while ((tentativasExecutadas < _config.Tentativas) && !processamentoConcluido)
				{
					try
					{
						int indiceDeCookie = 0;
						foreach (var conteudo in processadorInstagram.ContasProcessadas)
						{
							seleniumOperacao.Comentar(conteudo.Value, new Cookie("sessionid", _config.Cookies[indiceDeCookie]));
							tentativasExecutadas = 0;
							indiceDeCookie++;
							if (indiceDeCookie == _config.Cookies.Count)
							{
								indiceDeCookie = 0;
								Thread.Sleep(random.Next(1 * 60000, 3 * 60000));
							}
						}

						processamentoConcluido = true;
					}
					catch (Exception ex)
					{
						var logErro = new LogErro()
						{
							DataHoraLog = DateTime.Now,
							Erro = ex.Message
						};
						logErroDaAplicacao.RegistrarLog(JsonConvert.SerializeObject(logErro));
						tentativasExecutadas++;
						processadorInstagram.ReprocessarContasDoIntagram();
						Thread.Sleep(random.Next(1 * 60000, 5 * 60000));
					}
				}

			}
			catch (Exception ex)
			{
				var logErro = new LogErro()
				{
					DataHoraLog = DateTime.Now,
					Erro = ex.Message
				};
				logErroDaAplicacao.RegistrarLog(JsonConvert.SerializeObject(logErro));
			}
		}
	}
}
