using System;
using SuperSimpleTcp;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace client
{
    public partial class Client : Form
    {
        private SimpleTcpClient _client;
        private string _localComputerName;

        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            btnSend.Enabled = false;
            _localComputerName = GetLocalComputerName();
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            var messageReceived = Encoding.UTF8.GetString(e.Data.ToArray());

            // REQUESTNAME
            if (messageReceived.Contains("REQUESTNAME"))
                _client.Send("NAMEREQUEST+" + _localComputerName);
            else
            {
                Invoke((MethodInvoker)delegate
                {
                    tbInfo.Text +=
                        $@"{e.IpPort}: {messageReceived}{Environment.NewLine}";
                });
            }
        }

        private void Events_Disconnesso(object sender, ConnectionEventArgs e)
        {
            Invoke((MethodInvoker)delegate {

                tbInfo.Text += $@"Disonnesso al server.{Environment.NewLine}";
                btnSend.Enabled = false;
                btnConnect.Enabled = true;

            });
        }

        private void Events_Connesso(object sender, ConnectionEventArgs e)
        {
            Invoke((MethodInvoker)delegate {

                tbInfo.Text += $@"Connesso al server.{Environment.NewLine}";
            });
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                _client = new SimpleTcpClient(txtIP.Text);
                _client.Events.Connected += Events_Connesso;
                _client.Events.Disconnected += Events_Disconnesso;
                _client.Events.DataReceived += Events_DataReceived;
                _client.Connect();
                btnSend.Enabled = true;
                btnConnect.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Messaggio", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (_client.IsConnected)
            {
                if (!string.IsNullOrEmpty(txtMessage.Text))
                {
                    _client.Send(txtMessage.Text);
                    tbInfo.Text += $@"Io: {txtMessage.Text}{Environment.NewLine}";
                    txtMessage.Text = string.Empty;
                }
            }
        }

        public string GetLocalComputerName()
        {
            return Dns.GetHostName();
        }
    }
}
