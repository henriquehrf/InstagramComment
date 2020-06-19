using System;

namespace InstagramComment.Core.Interfaces
{
	public interface IRegistroLoff
	{
		public void RegistrarLogDeComentarios(string conteudo);

		public void RegistrarLogDeExcessao(Exception exception);
	}
}
