using InstagramComment.Core.Exception;
using InstagramComment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InstagramComment.Core
{
	public class GravadorDeArquivoTxt : IGravadorArquivoTxt
	{
		public string Path { get; }

		public GravadorDeArquivoTxt(string path)
		{
			Path = path;
		}

		public void GravarConteudo(params string[] conteudo)
		{
			if (string.IsNullOrEmpty(Path))
				throw new ArquivoDeLogDaAplicacaoNaoConfiguradoException();

			using StreamWriter streamWriter = new StreamWriter(Path, append: true);
			foreach (var linha in conteudo)
				streamWriter.WriteLine(linha);

			streamWriter.Flush();
			streamWriter.Close();
		}
	}
}
