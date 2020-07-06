using InstagramComment.Core;
using InstagramComment.Core.Interfaces;
using InstagramComment.Models;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
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
			//var teste = new List<string>();
			//teste.Add("916846849%3AIkOyBcKBCCgyxU%3A13");
			//teste.Add("33394755582%3Ar4mIBkIsNQJaIL%3A6");
			//JsonConvert.SerializeObject(teste);
			_config = JsonConvert.DeserializeObject<Config>(_leitorDeArquivo.LerConteudoArquivoTxt(PATH_ARQUIVO_CONFIG));
			int tentativasExecutadas = 1;
			bool processamentoConcluido = false;
			IWebDriver driver = new ChromeDriver(PATH_PROGRAMA);
			ILogDaAplicacao logDaAplicacao = new GravadorDeLogDaAplicacao(new GravadorDeArquivoTxt(PATH_LOG_REGISTROS_APLICACAO));
			ISeleniumComentario seleniumOperacao = new EngineSelenium(driver, logDaAplicacao, _config.UrlInstagram);
			Random random = new Random();
			IProcessadorDeContasDoInstagram processadorInstagram = new ProcessadorDeContasDoInstagram(_config.Contas);
			processadorInstagram.ProcessarContasDoInstagram();
			while ((tentativasExecutadas < _config.Tentativas) && !processamentoConcluido)
			{
				try
				{
					int indiceDeCookie = 0;
					foreach (var conteudo in processadorInstagram.ContasProcessadas)
					{
						seleniumOperacao.Comentar(conteudo.Value, new Cookie("sessionid", _config.Cookies[indiceDeCookie]));
						indiceDeCookie++;
						if (indiceDeCookie == _config.Cookies.Count)
						{
							indiceDeCookie = 0;
							Thread.Sleep(random.Next(1 * 60000, 5 * 60000));
						}
					}

					processamentoConcluido = true;
				}
				catch (Exception ex)
				{
					ILogDaAplicacao logErroDaAplicacao = new GravadorDeLogDaAplicacao(new GravadorDeArquivoTxt(PATH_LOG_ERRO_APLICACAO));
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
	}
}
