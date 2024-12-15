using SuperSimpleTcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace tcp.server
{
    public partial class Server : Form
    {
        //struttura dati e server globali
        private SimpleTcpServer _server;
        private Dictionary<string, string> _table;

        public Server()
        {
            InitializeComponent();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            tbIP.Text = TrovaIndirizzoIpLocale() + @":9001";
            _table = new Dictionary<string, string>();
            btInvia.Enabled = false;
        }

        private void Events_ClientConnesso(object sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                tbInfo.Text += $@"{e.IpPort} connesso.{Environment.NewLine}";

                //[HEADER] + [MESSAGGIO]
                _server.Send(e.IpPort, "REQUESTNAME");

            });
        }

        private void Events_ClientDisconnesso(object sender, ConnectionEventArgs e)
        {
            var ipAddressWithPort = e.IpPort;
            var computerToRemove = string.Empty;

            this.Invoke((MethodInvoker)delegate
            {
                tbInfo.Text += $@"{e.IpPort} disconnesso.{Environment.NewLine}";
                foreach (var item in _table)
                {
                    if (item.Key.Equals(ipAddressWithPort))
                    {
                        computerToRemove = item.Value;

                    }
                }

                lbClientIP.Items.Remove(computerToRemove);
                _table.Remove(ipAddressWithPort);
            });
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            string messageReceived = Encoding.UTF8.GetString(e.Data.ToArray());

            if (messageReceived.Contains("NAMEREQUEST"))
            {
                var clientComputerName = string.Empty;
                char[] splitter = { '+' };
                string[] messageSplit = messageReceived.Split(splitter, StringSplitOptions.RemoveEmptyEntries);

                //richiesta nome + nome computer
                foreach (var item in messageSplit)
                {
                    if (item.Equals("NAMEREQUEST"))
                        continue;
                    clientComputerName = item;

                    // COMPUTERNAME
                    _table.Add(e.IpPort, clientComputerName);

                    this.Invoke((MethodInvoker)delegate
                    {
                        lbClientIP.Items.Add(clientComputerName);
                    });
                }
            }

            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    tbInfo.Text += $@"{e.IpPort}: {Encoding.UTF8.GetString(e.Data.ToArray())}{Environment.NewLine}";
                });
            }

        }

        private void btInizia_Click(object sender, EventArgs e)
        {
            //caricare il server qua permette all'utente di cambiare server
            _server = new SimpleTcpServer(tbIP.Text);
            _server.Events.ClientConnected += Events_ClientConnesso;
            _server.Events.ClientDisconnected += Events_ClientDisconnesso;
            _server.Events.DataReceived += Events_DataReceived;
            _server.Start();

            tbInfo.Text += $@"Inizializzando...{Environment.NewLine}";
            btnStart.Enabled = false;
            btInvia.Enabled = true;
        }

        private void btInvia_Click(object sender, EventArgs e)
        {
            string ipConnection = string.Empty;

            if (_server.IsListening)
            {
                // check if message box is empty or if no client is selected
                if (!string.IsNullOrEmpty(tbMessage.Text) && lbClientIP.SelectedItem != null)
                {
                    foreach (var item in _table)
                    {
                        // <socket> <computer name>
                        if (item.Value == lbClientIP.SelectedItem.ToString())
                        {
                            ipConnection = item.Key;
                        }
                    }


                    _server.Send(ipConnection, tbMessage.Text);

                    tbInfo.Text += $@"Server: {tbMessage.Text}{Environment.NewLine}";
                    tbMessage.Text = string.Empty;
                }
            }
        }

        public static string TrovaIndirizzoIpLocale()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            }
            throw new Exception("Nessuna scheda di rete con indirizzo IPv4 trovata all'interno della macchina!");
        }
    }
}
