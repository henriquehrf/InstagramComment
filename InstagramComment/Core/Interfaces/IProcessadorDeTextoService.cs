using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstagramComment
{
	public interface IProcessadorDeTextoService
	{
		public string[] ProcessarContasDoInstagram(Task<string> contas);
	}
}
