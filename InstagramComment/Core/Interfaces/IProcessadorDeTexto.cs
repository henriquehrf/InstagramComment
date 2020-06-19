using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstagramComment
{
	public interface IProcessadorDeTexto
	{
		public string[] ProcessarContasDoInstagram(Task<string> contas);
	}
}
