using System;

namespace ConsoleChat
{
	public interface IProcessoPrincipal
	{
		IVisaoUsuario getVisaoUsuario();
		bool enviar(String ipRemoto, String textoMensagem); 
	}
}

