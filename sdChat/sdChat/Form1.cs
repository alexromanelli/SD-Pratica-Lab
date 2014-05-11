using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace sdChat
{
    public partial class FormChat : Form
    {
        private TcpListener tcpListener;
        private Thread listenThread;

        public FormChat()
        {
            InitializeComponent();
        }

        private void button_Enviar_Click(object sender, EventArgs e)
        {
            String server = text_IP.Text;
            String message = text_Mensagem.Text;
            addText("[você] " + message);

            Int32 port = 13000;
            TcpClient client = new TcpClient(server, port);

            Byte[] data = System.Text.Encoding.UTF8.GetBytes(message);

            NetworkStream stream = client.GetStream();
            stream.Write(data, 0, data.Length);
        }

        private void FormChat_Load(object sender, EventArgs e)
        {
            this.tcpListener = new TcpListener(IPAddress.Any, 13000);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
        }

        private void ListenForClients()
        {
            this.tcpListener.Start();

            while (true)
            {
                TcpClient client = this.tcpListener.AcceptTcpClient();
                Thread clientThread = 
					new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }

        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    break;
                }

                if (bytesRead == 0)
                {
                    break;
                }

                String ipRemoto = ((IPEndPoint)tcpClient.Client.RemoteEndPoint)
					.Address.ToString();
                UTF8Encoding encoder = new UTF8Encoding();
                addText("[" + ipRemoto + "] " + encoder.GetString(message, 0, bytesRead));
            }

            tcpClient.Close();
        }

        // esta parte do código é usada para atualizar o TextBox a partir de outra thread
        private void addText(string text)
        {
            text += Environment.NewLine;

            if (this.textBox_Chat.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(addText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox_Chat.AppendText(text);
            }
        }
        delegate void SetTextCallback(string text);
    }
}
