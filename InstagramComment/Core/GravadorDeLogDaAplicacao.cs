using InstagramComment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramComment.Core
{
	public class GravadorDeLogDaAplicacao : ILogDaAplicacao
	{
		public IGravadorArquivoTxt _gravadorArquivoTxt;
		public GravadorDeLogDaAplicacao(IGravadorArquivoTxt gravadorArquivoTxt)
		{
			_gravadorArquivoTxt = gravadorArquivoTxt;
		}
		public void RegistrarLog(string conteudo)
		{
			_gravadorArquivoTxt.GravarConteudo(conteudo);
		}
	}
}
