﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstagramComment
{
	public class ProcessadorDeArquivoTxt : IProcessadorDeTextoService
	{
		public string[] ProcessarContasDoInstagram(Task<string> contas)
		{
			contas.Wait();
			return contas.Result.Trim().Split(',');
		}
	}
}
