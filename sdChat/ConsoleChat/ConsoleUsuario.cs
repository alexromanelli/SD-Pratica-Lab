using System;
using System.Collections.Generic;

namespace ConsoleChat
{
	public class ConsoleUsuario : IVisaoUsuario
	{
		private static int linhaCampoIP = 3;
		private static int linhaCampoMensagem = 4;
		private static int colunaLabel = 5;
		private static int colunaEntrada = 17;
		private static int linhaInicioMensagens = 6;
		private static int colunaInicioMensagens = 5;
		/*
		 * o texto das mensagens terá início na coluna 40, pois é o suficiente para que
		 * na mesma linha seja exibido antes o texto no formato abaixo:
		 * "[localhost para 000.000.000.000] : "
		 * Este texto tem 35 caracteres. Somado ao afastamento colunaInicioMensagens,
		 * resulta em 40. Este valor é usado para alinhamentos de linhas adicionais de
		 * mensagens.
		 */
		private static int colunasAlinhamentoMensagens = 35;
		private static String prefixoAlinhamento = " >                                 ";

		private int numLinhasHistorico;
		private int numColunasHistorico;
		private int linhaAviso;

		private String[] mensagens;

		#region IVisaoUsuario implementation

		public void apresentaVisaoUsuario ()
		{
			preparaTela();
		}

		public void leCampos (out string ipRemoto, out string textoMensagem)
		{
			// limpa campos
			Console.SetCursorPosition (colunaEntrada, linhaCampoIP);
			Console.Write(new String (' ', numColunasHistorico - colunaEntrada));
			Console.SetCursorPosition (colunaEntrada, linhaCampoMensagem);
			Console.Write(new String (' ', numColunasHistorico - colunaEntrada));
			Console.SetCursorPosition (0, linhaCampoMensagem + 1);
			Console.Write(new String (' ', Console.WindowWidth));

			// lê propriamente
			Console.SetCursorPosition (colunaEntrada, linhaCampoIP);
			ipRemoto = Console.ReadLine ();
			Console.SetCursorPosition (colunaEntrada, linhaCampoMensagem);
			textoMensagem = Console.ReadLine ();
		}

		public void addHistoricoMensagem (OrigemMensagem origem, string ipRemoto, string textoMensagem)
		{
			switch (origem) {
			case OrigemMensagem.Local:
				addHistoricoMsgLocal (ipRemoto, textoMensagem);
				break;
			case OrigemMensagem.Remota:
				addHistoricoMsgRemota (ipRemoto, textoMensagem);
				break;
			}
		}

		public void exibeAviso (TipoMensagem tipo, string textoAviso)
		{
			// guarda posição atual
			int linha = Console.CursorTop;
			int coluna = Console.CursorLeft;

			// limpa
			Console.SetCursorPosition(colunaLabel, linhaAviso);
			for (int i = 0; i < numColunasHistorico; i++)
				Console.Write (" ");

			// escreve
			Console.SetCursorPosition(colunaLabel, linhaAviso);
			switch (tipo) {
			case TipoMensagem.Informacao:
				Console.Write ("Info: ");
				break;
			case TipoMensagem.Erro:
				Console.Write ("Erro: ");
				break;
			}
			Console.Write (textoAviso.Substring(0, 
			           (int)Math.Min (numColunasHistorico, textoAviso.Length)));

			// retorna cursor à posição inicial
			Console.SetCursorPosition (coluna, linha);
		}

		#endregion

		public ConsoleUsuario ()
		{
			numColunasHistorico = Console.WindowWidth - colunaInicioMensagens * 2;
			numLinhasHistorico = Console.WindowHeight - linhaInicioMensagens - 4;
			linhaAviso = Console.WindowHeight - 2;

			mensagens = new String[numLinhasHistorico];
			for (int i = 0; i < numLinhasHistorico; i++)
				mensagens [i] = "";
		}

		public void preparaTela() {
			Console.Clear();
			Console.SetCursorPosition (colunaLabel, linhaCampoIP);
			Console.Write ("IP destino: ");
			Console.SetCursorPosition (colunaLabel, linhaCampoMensagem);
			Console.Write ("Mensagem..: ");
		}

		public void deslocaMensagensHistorico () {
			for (int i = numLinhasHistorico - 1; i > 0; i--)
				mensagens [i] = mensagens [i - 1];
			mensagens [0] = "";
		}

		public void atualizaHistoricoMensagens() {
			for (int i = 0; i < numLinhasHistorico; i++) {
				// limpa linha
				Console.SetCursorPosition (colunaInicioMensagens, linhaInicioMensagens + i);
				for (int j = 0; j < numColunasHistorico; j++)
					Console.Write (" ");

				// escreve linha
				Console.SetCursorPosition (colunaInicioMensagens, linhaInicioMensagens + i);
				Console.Write (mensagens[i]);
			}
		}

		public void addHistoricoMsg(String mensagem) {
			deslocaMensagensHistorico ();
			mensagens [0] = mensagem;
			atualizaHistoricoMensagens ();
		}

		public void addHistoricoMsgRemota(String ipRemoto, String textoRecebido) {
			int left = Console.CursorLeft;
			int top = Console.CursorTop;

			String acaoMsg = "[" + ipRemoto + " para localhost]";
			formataMensagemEInsereHistorico (acaoMsg, textoRecebido);

			Console.SetCursorPosition (left, top);
		}

		public void addHistoricoMsgLocal(String ipRemoto, String textoParaEnviar) {
			String acaoMsg = "[localhost para " + ipRemoto + "]";
			formataMensagemEInsereHistorico (acaoMsg, textoParaEnviar);
		}

		private void formataMensagemEInsereHistorico(String acaoMsg, String texto) {
			String mensagem = acaoMsg;
			String sufixo = " : ";
			for (int i = mensagem.Length; i < colunasAlinhamentoMensagens - sufixo.Length; i++)
				mensagem = mensagem + " ";
			mensagem = mensagem + sufixo + texto;

			List<String> msgs = new List<String>();
			while (mensagem.Length > numColunasHistorico) {
				String msg = mensagem.Substring (0, numColunasHistorico);
				msgs.Add (msg);
				mensagem = prefixoAlinhamento + mensagem.Substring (numColunasHistorico);
			}
			msgs.Add (mensagem);
			msgs.Reverse ();

			foreach (String msg in msgs)
				addHistoricoMsg (msg);
		}
	}
}

