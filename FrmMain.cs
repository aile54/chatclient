using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.Linq;
using Matrix;
using Matrix.Xml;
using Matrix.Xmpp;
using Matrix.Xmpp.Client;
using Matrix.Xmpp.Register;
using Matrix.Xmpp.XData;
using MiniClient.Settings;
using Presence=Matrix.Xmpp.Client.Presence;
using RosterItem=Matrix.Xmpp.Roster.RosterItem;
using Subscription=Matrix.Xmpp.Roster.Subscription;
using EventArgs=Matrix.EventArgs;
using MiniClient.ClientDatabaseTableAdapters;
using System.Data.SqlServerCe;

namespace MiniClient
{
     
    public partial class FrmMain : Form
    {
        //WinAPI-Declaration for SendMessage
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr window, int message, int wparam, int lparam);

        const int WM_VSCROLL = 0x115;
        const int SB_BOTTOM = 7;

        private readonly Dictionary<string, ListViewGroup>  _dictContactGroups = new Dictionary<string, ListViewGroup>();
        private readonly Dictionary<Jid, RosterItem>        _dictContats = new Dictionary<Jid, RosterItem>();

        private Settings.Settings _settings;
        private Login _login;

        FileTransferManager fm = new FileTransferManager();

        public FrmMain()
        {
            InitializeComponent();
            SetLicense();

            RegisterCustomElements();
            InitSettings();
            InitContactList();
          
            fm.XmppClient = xmppClient;
            fm.OnFile += fm_OnFile;
            groupChatToolStripMenuItem.Enabled = false;
            settingToolStripMenuItem.Enabled = false;
        }
       
        private static void RegisterCustomElements()
        {
            Factory.RegisterElement<Settings.Settings>  ("ag-software:settings", "Settings");
            Factory.RegisterElement<Login>              ("ag-software:settings", "Login");
        }

        private void InitSettings()
        {
            _settings = Util.LoadSettings();
            if (_settings.Login == null)
                _settings.Login = new Login();
            
            _login = _settings.Login;
            
            if (_login != null)
            {
                if (!string.IsNullOrEmpty(_login.User))
                    txtUsername.Text = _login.User;

                if (!string.IsNullOrEmpty(_login.Server))
                    txtServer.Text = _login.Server;
                
                if (!string.IsNullOrEmpty(_login.Password))
                    txtPassword.Text    = _login.Password;
            }
        }

        /// <summary>
        /// Sets the license and activate the evaluation.
        /// </summary>
        private static void SetLicense()
        {
            // request demo license here:
            // http://www.ag-software.net/matrix-xmpp-sdk/request-demo-license/
            const string LIC = @"YOUR LICENSE";
            Matrix.License.LicenseManager.SetLicense(LIC);
            
            // when something is wrong with your license you can find the error here
            Console.WriteLine(Matrix.License.LicenseManager.LicenseError);
        }
       
        private void cmdConnect_Click(object sender, System.EventArgs e)
        {
            string username = txtUsername.Text;
            string server = "192.168.0.236";// txtServer.Text;
            string pass = txtPassword.Text;

            xmppClient.SetUsername(username);
            xmppClient.SetXmppDomain(server);
            xmppClient.Password = pass;
            
            // BOSH exmaple
            //xmppClient.Transport = Matrix.Net.Transport.BOSH;
            //xmppClient.Uri = new System.Uri("http://matrix.ag-software.de/http-bind/");
            
            xmppClient.Status = "ready for chat";
            xmppClient.Show = Matrix.Xmpp.Show.Chat;

            if (!String.IsNullOrEmpty(txtHost.Text))
            {
                // disable SRV lookups and specify the sever hostname manual
                xmppClient.ResolveSrvRecords = false;
                xmppClient.Hostname = txtHost.Text;
                //xmppClient.Hostname = "192.168.1.106";
            }
              

            // set settings
            _login.User = txtUsername.Text;
            _login.Server = txtServer.Text;
            _login.Password = txtPassword.Text;

            Matrix.License.LicenseManager.m_IsValid = true;
            xmppClient.Open();
            groupChatToolStripMenuItem.Enabled = true;
            settingToolStripMenuItem.Enabled = true;
        }

        private void xmppClient_OnError(object sender, ExceptionEventArgs e)
        {
            DisplayEvent("OnError");
        }

        private void xmppClient_OnLogin(object sender, Matrix.EventArgs e)
        {
            DisplayEvent("OnLogin");   
        }

        private void DisplayEvent(string ev)
        {
            listEvents.Items.Add(ev);
            listEvents.SelectedIndex = listEvents.Items.Count - 1;
        }

        private void xmppClient_OnBind(object sender, JidEventArgs e)
        {
            DisplayEvent("OnBind");
        }

        private void xmppClient_OnClose(object sender, Matrix.EventArgs e)
        {
            DisplayEvent("OnClose");
            listContacts.Items.Clear();
        }

        private void xmppClient_OnRosterStart(object sender, Matrix.EventArgs e)
        {

        }

        private void xmppClient_OnRosterEnd(object sender, Matrix.EventArgs e)
        {
            DisplayEvent("OnRosterEnd");
        }

        private void xmppClient_OnRosterItem(object sender, Matrix.Xmpp.Roster.RosterEventArgs e)
        {
            DisplayEvent(string.Format( "OnRosterItem\t{0}\t{1}", e.RosterItem.Jid, e.RosterItem.Name )); 

            if (e.RosterItem.Subscription != Subscription.Remove)
            {
                // set a default group name
                string groupname = "Contacts";

                // id the contact has groups get the 1st group. In this example we don't support multiple or nested groups
                // for contacts, but XMPP has support for this.
                if (e.RosterItem.HasGroups)
                    groupname = e.RosterItem.GetGroups()[0];

                if (!_dictContactGroups.ContainsKey(groupname))
                {
                    var newGroup = new ListViewGroup(groupname);
                    _dictContactGroups.Add(groupname, newGroup);
                    listContacts.Groups.Add(newGroup);
                }

                var listGroup = _dictContactGroups[groupname];

                // contact already exists, this is a contact update
                if (_dictContats.ContainsKey(e.RosterItem.Jid))
                {
                    listContacts.Items.RemoveByKey(e.RosterItem.Jid);
                }

                //var newItem = new ListViewItem(e.RosterItem.Jid, listGroup) {Name = e.RosterItem.Jid};
                var newItem = new RosterListViewItem(e.RosterItem.Name ?? e.RosterItem.Jid, 0, listGroup)
                                  {Name = e.RosterItem.Jid.Bare};
                newItem.SubItems.AddRange(new[] {"", ""});
                
              
                listContacts.Items.Add(newItem);
            }
        }

        private void xmppClient_OnPresence(object sender, PresenceEventArgs e)
        {
            DisplayEvent(string.Format("OnPresence\t{0}", e.Presence.From));

            if (e.Presence.Type == PresenceType.Subscribe)
            {
                
            }
            else if (e.Presence.Type == PresenceType.Subscribed)
            {

            }
            else if (e.Presence.Type == PresenceType.Unsubscribe)
            {

            }
            else if (e.Presence.Type == PresenceType.Unsubscribed)
            {

            }
            else
            {
                var item = listContacts.Items[e.Presence.From.Bare] as RosterListViewItem;
                if (item != null)
                {
                    item.ImageIndex = Util.GetRosterImageIndex(e.Presence);
                    string resource = e.Presence.From.Resource;
                    if (e.Presence.Type != PresenceType.Unavailable)
                    {
                        if (!item.Resources.Contains(resource))
                            item.Resources.Add(resource);
                    }
                    else
                    {
                        if (item.Resources.Contains(resource))
                            item.Resources.Remove(resource);
                    }
                }
            }
        }

        private void xmppClient_OnIq(object sender, IqEventArgs e)
        {
            DisplayEvent("OnIq");
        }

        private void xmppClient_OnMessage(object sender, MessageEventArgs e)
        {
            DisplayEvent("OnMessage");


            // we ignore GroupChat Messages here
            if (e.Message.Type == MessageType.GroupChat)
                return;

            if (e.Message.Type == MessageType.Error)
            {
                //Handle errors here
                // we dont handle them in this example
                return;
            }
            if (e.Message.Body != null)
            {
                if (!Util.ChatForms.ContainsKey(e.Message.From.Bare))
                {
                    //get nickname from the roster listview
                    string nick = e.Message.From.Bare;
                    var item = listContacts.Items[e.Message.From.Bare];
                    if (item != null)
                        nick = item.Text;
                    
                    var f = new FrmChat(e.Message.From, xmppClient, nick);
                    f.Show();
                    f.IncomingMessage(e.Message, e.Message.From.Resource, DateTime.Now);
                }
            }
        }

        private void xmppClient_OnValidateCertificate(object sender, CertificateEventArgs e)
        {
             //always accept cert
             e.AcceptCertificate = true;

            // or let the user validate the certificate
            //ValidateCertificate(e);
        }
        
        private void ValidateCertificate(CertificateEventArgs e)
        {
            //DisplayEvent("OnValidateCertificate");
           

            if (e.SslPolicyErrors == System.Net.Security.SslPolicyErrors.None)
            {
                e.AcceptCertificate = true;
            }
            else
            {
                X509Certificate2UI.DisplayCertificate(new X509Certificate2(e.Certificate));
                if (MessageBox.Show("Accept Certificate", "Certificate", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    e.AcceptCertificate = true;
                else
                    e.AcceptCertificate = false;                
            }
        }

        private void cmdDisconnect_Click(object sender, System.EventArgs e)
        {
            xmppClient.Close();
        }

        private void xmppClient_OnBeforeSasl(object sender, Matrix.Xmpp.Sasl.SaslEventArgs e)
        {
            e.Auto = false;
            e.SaslMechanism = Matrix.Xmpp.Sasl.SaslMechanism.Plain;
            
            /*
            with the following code you can disable the SASL automatic and manual specify a mechanism.
            
             * e.Auto = false;
            e.SaslMechanism = Matrix.Xmpp.Sasl.SaslMechanism.PLAIN;
            */

            
            // X_FACEBOOK_PLATFORM Facebook Auth example
            //e.Auto = false;
            //e.SaslMechanism = Matrix.Xmpp.Sasl.SaslMechanism.X_FACEBOOK_PLATFORM;

            //const string APPLICATION_KEY = "12345678901234567890";
            //const string SECRET_KEY = "98765432109876543210";
            //e.SaslProperties = new Matrix.Xmpp.Sasl.Processor.Facebook.FacebookProperties
            //                       {
            //                           ApiKey = APPLICATION_KEY,
            //                           ApiSecret = SECRET_KEY,
            //                           SessionKey = "session_key_from_facebook_api"
            //                       };
         }

        private void xmppClient_OnAuthError(object sender, Matrix.Xmpp.Sasl.SaslEventArgs e)
        {
            DisplayEvent("OnAuthError");
            xmppClient.Close();
        }

        private void xmppClient_OnReceiveXml(object sender, TextEventArgs e)
        {
            ////if (e.Message.Type == MessageType.GroupChat)
            ////{
            ////    string datetime = e.Message.Delay.GetAttribute("stamp");
            ////    DateTime dt = new DateTime();
            ////    DateTime.TryParse(datetime, out dt);
            ////    if (DateTime.Now.Date.CompareTo(dt.Date) == 0)
            ////    {
            ////        IncomingMessage(e.Message);
            ////    }
                
            ////}
            //var x = XDocument.Parse(e.Text);
            
            //rtfDebug.SelectionStart = rtfDebug.Text.Length;
            //rtfDebug.SelectionLength = 0;
            //rtfDebug.SelectionColor = Color.Red;
            //rtfDebug.AppendText("RECV: ");
            //rtfDebug.SelectionColor = Color.Black;
            //rtfDebug.AppendText(e.Text);
            //rtfDebug.AppendText("\r\n");
            //ScrollRtfToEnd(rtfDebug);
        }
        

        private void xmppClient_OnSendXml(object sender, TextEventArgs e)
        {
            //rtfDebug.SelectionStart = rtfDebug.Text.Length;
            //rtfDebug.SelectionLength = 0;
            //rtfDebug.SelectionColor = Color.Blue;
            //rtfDebug.AppendText("SEND: ");
            //rtfDebug.SelectionColor = Color.Black;
            //rtfDebug.AppendText(e.Text);
            //rtfDebug.AppendText("\r\n");
            //ScrollRtfToEnd(rtfDebug);
        }

        private void ScrollRtfToEnd(RichTextBox rtf)
        {
            SendMessage(rtf.Handle, WM_VSCROLL, SB_BOTTOM, 0);
        }
        
        /// <summary>
        /// Inits the contact list.
        /// </summary>
        private void InitContactList()
        {
            listContacts.Clear();

            listContacts.Columns.Add("Name", 100, HorizontalAlignment.Left);
            listContacts.Columns.Add("Status", 75, HorizontalAlignment.Left);
            listContacts.Columns.Add("Resource", 75, HorizontalAlignment.Left);

            listContacts.LargeImageList = ilstStatus;
        }

        private void xmppClient_OnStreamError(object sender, StreamErrorEventArgs e)
        {
            DisplayEvent("OnStreamError");
        }

        private void cmdPubSub_Click(object sender, System.EventArgs e)
        {
            var frm = new FrmPubSub(xmppClient);
            frm.Show();
        }

        #region << PubSub Event >>
        private void pubSubManager1_OnEvent(object sender, MessageEventArgs e)
        {
            DisplayEvent("OnPubsubEvent");
        }
        #endregion

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Util.SaveSettings(_settings);
        }

        private void chatToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (listContacts.SelectedItems.Count > 0)
            {
                var item = listContacts.SelectedItems[0];
                if (!Util.ChatForms.ContainsKey(item.Name))
                {
                    var roomJid = new Jid(item.Name);
                    var f = new FrmChat(roomJid, xmppClient, item.Text);
                    f.Show();
                }
            }
        }

        private void vCardToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (listContacts.SelectedItems.Count > 0)
            {
                new FrmVCard(xmppClient, listContacts.SelectedItems[0].Name, false).Show();
            }
        }

        

        private void listContacts_MouseUp(object sender, MouseEventArgs e)
        {
            //Check if right clicked on a ListView Item
            if ((listContacts.SelectedItems.Count != 0) && (e.Button == MouseButtons.Right))
            {
                // dynamically adjust context menu with resources.
                sendFileToolStripMenuItem.DropDownItems.Clear();
                var item = listContacts.SelectedItems[0] as RosterListViewItem;
                foreach (string res in item.Resources)
                {
                    Jid jid = item.Name + "/" + res;
                    var menu = new ToolStripMenuItem(res);
                    menu.Click += delegate
                                      {
                                          new FrmSendFile(fm, jid).Show();

                                      };
                    sendFileToolStripMenuItem.DropDownItems.Add(menu);
                }
                // show context menu
                ctxMenuRoster.Show(Cursor.Position);
            }
        }

        private void xmppClient_OnRegisterInformation(object sender, RegisterEventArgs e)
        {
            e.Register.RemoveAll<Data>();
            
            e.Register.Username = xmppClient.Username;
            e.Register.Password = xmppClient.Password;
        }

        private void xmppClient_OnRegister(object sender, EventArgs e)
        {

        }

        private void xmppClient_OnRegisterError(object sender, IqEventArgs e)
        {
            xmppClient.Close();
        }

        private void presenceManager_OnSubscribe(object sender, PresenceEventArgs e)
        {
            presenceManager.ApproveSubscriptionRequest(e.Presence.From);
            //presenceManager.DenySubscriptionRequest(e.Presence.From);
        }
        
        void fm_OnFile(object sender, FileTransferEventArgs e)
        {
            var recvFile = new FrmReceiveFile(fm, e);
            recvFile.Show();
            recvFile.StartAccept();
            //e.Accept = true;
            
        }

        private void xmppClient_OnBeforeSendPresence(object sender, PresenceEventArgs e)
        {
            // add custom information to outgoing Presences when desired
            //e.Presence.Add(new XElement("foo"));
        }

        private void cmdVcard_Click(object sender, System.EventArgs e)
        {
            new FrmVCard(xmppClient, null, true).Show();
        }
        
       
        private void tsmiEnterRoom_Click(object sender, System.EventArgs e)
        {
            var input = new FrmInputBox("Enter your Nickname for the chatroom", "Nickname", "Nickname");
            if (input.ShowDialog() == DialogResult.OK)
            {
                string nickname = input.Result;
                input = new FrmInputBox("Enter the Jid of the room to join (e.g. jdev@conference.jabber.org)", "Room");
                if (input.ShowDialog() == DialogResult.OK)
                {
                    var roomJid = new Jid(input.Result == string.Empty ? "kddi_airwater-gas-management@conference.vitenet1.net" : input.Result);//input.Result);
                    new FrmGroupChat(xmppClient, roomJid, nickname).Show();
                }
            }
        }

        private void tsmiEnterRoomTest_Click(object sender, System.EventArgs e)
        {
            var input = new FrmInputBox("Enter your Nickname for the chatroom", "Nickname", "Nickname");
            if (input.ShowDialog() == DialogResult.OK)
            {
                string nickname = input.Result;
                var roomJid = new Jid("test@conference.ag-software.net");
                new FrmGroupChat(xmppClient, roomJid, nickname).Show();
            }
        }

        #region << Change Presence >>
        private void presenceOnlineToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (xmppClient.StreamActive)
                xmppClient.SendPresence(Matrix.Xmpp.Show.None);
        }
        
        private void presenceChatToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (xmppClient.StreamActive)
                xmppClient.SendPresence(Matrix.Xmpp.Show.Chat);
        }

        private void presenceAwayToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (xmppClient.StreamActive)
                xmppClient.SendPresence(Matrix.Xmpp.Show.Away);
        }

        private void presenceExtendedAwayToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (xmppClient.StreamActive)
                xmppClient.SendPresence(Matrix.Xmpp.Show.ExtendedAway);
        }

        private void presenceDoNotDisturbToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (xmppClient.StreamActive)
                xmppClient.SendPresence(Matrix.Xmpp.Show.DoNotDisturb);
        }
        #endregion

        private void resetDatabaseToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            string query = "DELETE FROM HistoryTransaction";
            HistoryTransactionTableAdapter local_history = new HistoryTransactionTableAdapter();
            SqlCeConnection connection = new SqlCeConnection(local_history.Connection.ConnectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void addToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var input = new FrmAddUser();
            if (input.ShowDialog() == DialogResult.OK)
            {
                //var rm = new RosterManager(xmppClient);
                Jid jid = input.Address;
                //rm.Add(jid, input.Name);

                var pm = new PresenceManager(xmppClient);
                string reason = "It's " + input.Name;
                pm.Subscribe(jid, reason, input.Name);
            }

            
        }
    }
}