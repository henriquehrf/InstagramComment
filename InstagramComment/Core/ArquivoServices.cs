using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InstagramComment
{
	public class ArquivoServices : IArquivoOperacao
	{
		IProcessarArquivoTxt _processadorDeTxt;
		public ArquivoServices(IProcessarArquivoTxt processadorTxt)
		{
			_processadorDeTxt = processadorTxt;
		}
		public string[] LerConteudoArquivoTxt(string path)
		{
			using StreamReader file = new StreamReader(path);
			return _processadorDeTxt.ProcessarContasDoInstagram(file.ReadToEndAsync());
		}


	}
}
