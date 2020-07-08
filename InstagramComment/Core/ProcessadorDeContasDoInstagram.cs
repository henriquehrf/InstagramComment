using InstagramComment.Core.Exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramComment
{
	public class ProcessadorDeContasDoInstagram : IProcessadorDeContasDoInstagram
	{
		private readonly string[] _contasNaoProcessadas;

		public IDictionary<int, string> ContasProcessadas { get; }

		public ProcessadorDeContasDoInstagram(string contas)
		{
			_contasNaoProcessadas = contas.Trim().Split(',');
			ContasProcessadas = new SortedDictionary<int, string>();
		}
		public void ProcessarContasDoInstagram(int numeroDeConta)
		{
			if (numeroDeConta >= _contasNaoProcessadas.Length || numeroDeConta <= 0)
				throw new NumeroDeContaPorComentarioExcception(numeroDeConta);

			foreach (var conta in _contasNaoProcessadas)
			{
				var conteudo = new StringBuilder();
				int contasAdicionada = 1;
				conteudo.Append(conta);
				conteudo.Append(" ");
				foreach (var proximaConta in _contasNaoProcessadas)
					if (contasAdicionada != numeroDeConta && conta != proximaConta)
					{
						conteudo.Append(proximaConta);
						conteudo.Append(" ");
						contasAdicionada++;
					}

				ContasProcessadas.Add(
					new Random().Next(minValue: 1, maxValue: int.MaxValue),
					conteudo.ToString()
					);
			}
		}

		public void ReprocessarContasDoIntagram(int numeroDeConta)
		{
			ContasProcessadas.Clear();
			ProcessarContasDoInstagram(numeroDeConta);
		}
	}
}
