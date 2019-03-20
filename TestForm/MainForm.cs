using API.WebSocket;
using Newtonsoft.Json;
using NLog.Windows.Forms;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TestForm
{
    public partial class MainForm : Form
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private readonly string cfg_file = "app.cfg";

        private WebSocket socket;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RichTextBoxTarget.ReInitializeAllTextboxes(this);

            // read config
            try
            {
                var cfg = File.ReadAllText(cfg_file);
                if (!string.IsNullOrWhiteSpace(cfg))
                {
                    dynamic json = JsonConvert.DeserializeObject(cfg);
                    if (json?.pub != null)
                    {
                        tbPublic.Text = json?.pub.ToString();
                    }
                    if (json?.priv != null)
                    {
                        tbPrivate.Text = json?.priv.ToString();
                    }
                }
            }
            catch
            {
                // None
            }
        }

        ~MainForm()
        {
            SocketDisconnect();

            NLog.LogManager.Shutdown(); // Flush and close down internal threads and timers
        }

        private void SocketConnect(string public_key, string private_key)
        {
            if (socket != null)
            {
                SocketDisconnect();
            }

            socket = new WebSocket(public_key, private_key);
            socket.OnSocketOpen += Socket_OnSocketOpen;
            socket.OnSocketClose += Socket_OnSocketClose;
            socket.OnSocketError += Socket_OnSocketError;
            socket.OnAuthRequest += Socket_OnAuthRequest;
            socket.OnAuthSuccess += Socket_OnAuthSuccess;
            socket.OnAuthFail += Socket_OnAuthFail;
            socket.Start();
        }

        private void SocketDisconnect()
        {
            if (socket != null)
            {
                socket.Stop();
                socket.OnSocketOpen -= Socket_OnSocketOpen;
                socket.OnSocketClose -= Socket_OnSocketClose;
                socket.OnSocketError -= Socket_OnSocketError;
                socket.OnAuthRequest -= Socket_OnAuthRequest;
                socket.OnAuthSuccess -= Socket_OnAuthSuccess;
                socket.OnAuthFail -= Socket_OnAuthFail;
                socket = null;
            }
        }

        #region control event handler

        private void Connect_Click(object sender, EventArgs e)
        {
            tbPublic.Text = tbPublic.Text.Trim();
            tbPrivate.Text = tbPrivate.Text.Trim();

            if (string.IsNullOrWhiteSpace(tbPublic.Text))
            {
                MessageBox.Show("No public API key", "Warning");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbPrivate.Text))
            {
                MessageBox.Show("No private API key", "Warning");
                return;
            }

            SocketConnect(tbPublic.Text, tbPrivate.Text);

            // save config
            var cfg = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(new { pub = tbPublic.Text, priv = tbPrivate.Text }));
            using (var fs = new FileStream(cfg_file, FileMode.Create))
            {
                fs.Write(cfg, 0, cfg.Length);
                fs.Flush();
                fs.Close();
            }
        }

        private void Disconnect_Click(object sender, EventArgs e)
        {
            SocketDisconnect();
        }

        private void PublicAPI_Click(object sender, EventArgs e)
        {
            if (socket == null) return;

            var form = new PublicAPI(socket);
            form.Show();
        }

        private void UserAPI_Click(object sender, EventArgs e)
        {
            if (socket == null) return;

            var form = new UserAPI(socket);
            form.Show();
        }

        #endregion

        #region event handler

        private void Socket_OnSocketOpen()
        {
            try
            {
                this.BeginInvoke((Action)(() => {
                    clbSocketFlag.SetItemChecked(0, true);
                    clbSocketFlag.SetItemChecked(1, false);
                    clbSocketFlag.SetItemChecked(2, false);
                    clbSocketFlag.SetItemChecked(3, false);
                    clbSocketFlag.SetItemChecked(4, false);
                }));
            }
            catch { }
        }

        private void Socket_OnSocketClose(string mess)
        {
            try
            {
                this.BeginInvoke((Action)(() => {
                    clbSocketFlag.SetItemChecked(0, false);
                    clbSocketFlag.SetItemChecked(1, false);
                    clbSocketFlag.SetItemChecked(2, false);
                }));
            }
            catch { }
        }

        private void Socket_OnSocketError(string mess)
        {
            try
            {
                this.BeginInvoke((Action)(() => {
                    clbSocketFlag.SetItemChecked(4, true);
                }));
            }
            catch { }
        }

        private void Socket_OnAuthRequest()
        {
            try
            {
                this.BeginInvoke((Action)(() => {
                    clbSocketFlag.SetItemChecked(1, true);
                }));
            }
            catch { }
        }

        private void Socket_OnAuthSuccess()
        {
            try
            {
                this.BeginInvoke((Action)(() => {
                    clbSocketFlag.SetItemChecked(2, true);
                }));
            }
            catch { }
        }

        private void Socket_OnAuthFail()
        {
            try
            {
                this.BeginInvoke((Action)(() => {
                    clbSocketFlag.SetItemChecked(3, true);
                }));
            }
            catch { }
        }

        #endregion
    }
}
