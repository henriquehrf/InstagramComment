using System;
using System.Collections.Generic;

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
		public void ProcessarContasDoInstagram()
		{

			for (int i = 0; i < _contasNaoProcessadas.Length; i++)
				for (int j = 0; j < _contasNaoProcessadas.Length; j++)
					for (int k = 0; k < _contasNaoProcessadas.Length; k++)
						if (i != j && i != k && j != k)
							ContasProcessadas.Add(
								new Random().Next(minValue: 1, maxValue: int.MaxValue),
								$"{_contasNaoProcessadas[i]} " +
								$"{_contasNaoProcessadas[j]} " +
								$"{_contasNaoProcessadas[k]}");
		}

		public void ReprocessarContasDoIntagram()
		{
			ContasProcessadas.Clear();
			ProcessarContasDoInstagram();
		}
	}
}
