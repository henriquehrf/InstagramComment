using System.IO;

namespace InstagramComment
{
	public class LeitorDeArquivoTxt : ILeitorDeArquivoTxt
	{
		public string LerConteudoArquivoTxt(string path)
		{
			using StreamReader file = new StreamReader(path);
			return file.ReadToEnd();
		}


	}
}
