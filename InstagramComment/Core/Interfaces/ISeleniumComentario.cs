using OpenQA.Selenium;

namespace InstagramComment
{
	public interface ISeleniumComentario
	{
		public void Comentar(string conteudo, Cookie cookie);
	}
}