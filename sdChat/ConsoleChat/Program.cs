using System;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Text;
using System.IO;

namespace ConsoleChat
{
	class MainClass : IProcessoPrincipal
	{
		private static MainClass INSTANCE;
		private IVisaoUsuario visaoUsuario;
		private MonitorTCP monitorTCP;

		#region IProcessoPrincipal implementation

		public IVisaoUsuario getVisaoUsuario ()
		{
			return visaoUsuario;
		}

		public bool enviar(String ipRemoto, String textoMensagem)
		{
			String server = ipRemoto;
			String message = textoMensagem;

			try 
			{
				Int32 port = MonitorTCP.PORTA_CHAT;
				TcpClient client = new TcpClient(server, port);

				Byte[] data = System.Text.Encoding.UTF8.GetBytes(message);

				NetworkStream stream = client.GetStream();
					stream.Write(data, 0, data.Length);
			} 
			catch (IOException e) {
				visaoUsuario.exibeAviso (TipoMensagem.Erro, e.Message);
				return false;
			} 
			catch (SocketException e) {
				visaoUsuario.exibeAviso (TipoMensagem.Erro, e.Message);
				return false;
			}

			visaoUsuario.exibeAviso (TipoMensagem.Informacao, "Mensagem enviada para " + ipRemoto);
			return true;
		}

		#endregion

		public static MainClass getInstance ()
		{
			return INSTANCE;
		}

		public MainClass() {
			INSTANCE = this;
			visaoUsuario = new ConsoleUsuario ();
			monitorTCP = new MonitorTCP ();
		}

		public static void Main (string[] args)
		{
			MainClass program = new MainClass ();
			program.getVisaoUsuario().apresentaVisaoUsuario ();
			program.monitorTCP.preparaThreadServidor ();

			String ipRemoto = "";
			String textoParaEnviar = "";

			while (true) {
				program.getVisaoUsuario().leCampos (out ipRemoto, out textoParaEnviar);
				if (textoParaEnviar.Equals ("quit")) {
					Console.SetCursorPosition (0, Console.WindowHeight - 1);
					break;
				}
				program.getVisaoUsuario().addHistoricoMensagem (OrigemMensagem.Local, ipRemoto, textoParaEnviar);
				program.enviar (ipRemoto, textoParaEnviar);
			}
		}

	}
}
