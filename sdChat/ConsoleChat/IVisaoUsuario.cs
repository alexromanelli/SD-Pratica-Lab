using System;

namespace ConsoleChat
{
	public enum OrigemMensagem {
		Local,
		Remota
	}

	public enum TipoMensagem {
		Informacao,
		Erro
	}

	public interface IVisaoUsuario
	{
		void apresentaVisaoUsuario();
		void leCampos(out String ipRemoto, out String textoMensagem);
		void addHistoricoMensagem(OrigemMensagem origem, String ipRemoto, String textoMensagem);
		void exibeAviso(TipoMensagem tipo, String textoAviso);
	}
}

