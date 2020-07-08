using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstagramComment
{
	public interface IProcessadorDeContasDoInstagram
	{
		IDictionary<int, string> ContasProcessadas { get; }
		public void ProcessarContasDoInstagram(int numeroDeConta = 3);
		public void ReprocessarContasDoIntagram(int numeroDeConta = 3);
	}
}
