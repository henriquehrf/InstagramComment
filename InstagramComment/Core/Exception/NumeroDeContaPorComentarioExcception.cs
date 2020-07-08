using System;

namespace InstagramComment.Core.Exception
{
	public class NumeroDeContaPorComentarioExcception : SystemException
	{
		public NumeroDeContaPorComentarioExcception(int numeroConta):base($"Não foi possivel realizar o processamento de {numeroConta} contas por comentário, favor revisar o arquivo config.txt")
		{
		}
	}
}
