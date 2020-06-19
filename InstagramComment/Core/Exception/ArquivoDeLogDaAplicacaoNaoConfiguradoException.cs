using System;

namespace InstagramComment.Core.Exception
{
	public class ArquivoDeLogDaAplicacaoNaoConfiguradoException: SystemException
	{
		public ArquivoDeLogDaAplicacaoNaoConfiguradoException():base("O endereço do arquivo de log da aplição não foi configurado!")
		{
		}
	}
}
