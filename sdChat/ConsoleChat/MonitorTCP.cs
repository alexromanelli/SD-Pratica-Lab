using System;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace ConsoleChat
{
	public class MonitorTCP
	{
		public static int PORTA_CHAT = 13000;
		public static int TAM_BYTES_PACOTE = 4096;

		private static TcpListener tcpListener;
		private static Thread listenThread;

		public MonitorTCP ()
		{
		}

		public void preparaThreadServidor()
		{
			tcpListener = new TcpListener(IPAddress.Any, PORTA_CHAT);
			listenThread = new Thread(new ThreadStart(ListenForClients));
			listenThread.Start();
		}

		private void ListenForClients()
		{
			tcpListener.Start();

			while (true)
			{
				TcpClient client = tcpListener.AcceptTcpClient();
				Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
				clientThread.Start(client);
			}
		}

		private void HandleClientComm(object client)
		{
			TcpClient tcpClient = (TcpClient)client;
			NetworkStream clientStream = tcpClient.GetStream();

			byte[] message = new byte[TAM_BYTES_PACOTE];
			int bytesRead;

			while (true)
			{
				bytesRead = 0;

				try
				{
					bytesRead = clientStream.Read(message, 0, TAM_BYTES_PACOTE);
				}
				catch
				{
					break;
				}

				if (bytesRead == 0)
				{
					break;
				}

				String ipRemoto = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
				UTF8Encoding encoder = new UTF8Encoding();
				String textoRecebido = encoder.GetString (message, 0, bytesRead);

				MainClass.getInstance().getVisaoUsuario()
					.addHistoricoMensagem (OrigemMensagem.Remota, ipRemoto, textoRecebido);
				MainClass.getInstance ().getVisaoUsuario ()
					.exibeAviso (TipoMensagem.Informacao, "Mensagem recebida de " + ipRemoto);
			}

			tcpClient.Close();
		}
	}
}

