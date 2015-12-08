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

        public Dictionary<string, ListViewGroup>  _dictContactGroups = new Dictionary<string, ListViewGroup>();
        private readonly Dictionary<Jid, RosterItem>        _dictContats = new Dictionary<Jid, RosterItem>();

        FileTransferManager fm = new FileTransferManager();
        XmppClient xmppClient;

        public FrmMain()
        {
            InitializeComponent();

            RegisterCustomElements();
           
            InitContactList();

            xmppClient = FrmLogin.Instance.xmppClient;
            fm.XmppClient = FrmLogin.Instance.xmppClient;
            fm.OnFile += fm_OnFile;
            groupChatToolStripMenuItem.Enabled = false;
            settingToolStripMenuItem.Enabled = false;

            groupChatToolStripMenuItem.Enabled = true;
            settingToolStripMenuItem.Enabled = true;

            this.xmppClient.OnError+=new EventHandler<ExceptionEventArgs>(xmppClient_OnError);
            this.xmppClient.OnMessage+=new EventHandler<MessageEventArgs>(xmppClient_OnMessage);
            this.xmppClient.OnPrebind += new EventHandler<Matrix.Net.PrebindEventArgs>(xmppClient_OnPrebind);
            
            this.xmppClient.OnBind+=new EventHandler<JidEventArgs>(xmppClient_OnBind);
            this.xmppClient.OnClose+=new EventHandler<EventArgs>(xmppClient_OnClose);
            this.xmppClient.OnRosterEnd+=new EventHandler<EventArgs>(xmppClient_OnRosterEnd);
            this.xmppClient.OnRosterStart+=new EventHandler<EventArgs>(xmppClient_OnRosterStart);
            this.xmppClient.OnRosterItem+=new EventHandler<Matrix.Xmpp.Roster.RosterEventArgs>(xmppClient_OnRosterItem);
            this.xmppClient.OnPresence+=new EventHandler<PresenceEventArgs>(xmppClient_OnPresence);
            this.xmppClient.OnValidateCertificate+=new EventHandler<CertificateEventArgs>(xmppClient_OnValidateCertificate);
            this.xmppClient.OnIq+=new EventHandler<IqEventArgs>(xmppClient_OnIq);
            this.xmppClient.OnReceiveXml+=new EventHandler<TextEventArgs>(xmppClient_OnReceiveXml);
            this.xmppClient.OnStreamError+=new EventHandler<StreamErrorEventArgs>(xmppClient_OnStreamError);
            this.xmppClient.OnSendXml+=new EventHandler<TextEventArgs>(xmppClient_OnSendXml);
            this.xmppClient.OnRegister+=new EventHandler<EventArgs>(xmppClient_OnRegister);
            this.xmppClient.OnRegisterError+=new EventHandler<IqEventArgs>(xmppClient_OnRegisterError);
            this.xmppClient.OnRegisterInformation+=new EventHandler<RegisterEventArgs>(xmppClient_OnRegisterInformation);
            this.xmppClient.OnBeforeSendPresence+=new EventHandler<PresenceEventArgs>(xmppClient_OnBeforeSendPresence);
        }

        void xmppClient_OnPrebind(object sender, Matrix.Net.PrebindEventArgs e)
        {
            
        }
       
        private static void RegisterCustomElements()
        {
            Factory.RegisterElement<Settings.Settings>  ("ag-software:settings", "Settings");
            Factory.RegisterElement<Login>              ("ag-software:settings", "Login");
        }

        private void xmppClient_OnError(object sender, ExceptionEventArgs e)
        {
            DisplayEvent("OnError");
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

            if (e.RosterItem.Ask == Matrix.Xmpp.Roster.Ask.Unsubscribe)
            {
                
            }
            else if (e.RosterItem.Subscription != Subscription.Remove)
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

                var contract = listContacts.Items.Find(e.RosterItem.Jid, true);
                if (contract.Count() == 0)
                {
                    //var newItem = new ListViewItem(e.RosterItem.Jid, listGroup) {Name = e.RosterItem.Jid};
                    var newItem = new RosterListViewItem(e.RosterItem.Name ?? e.RosterItem.Jid, 0, listGroup) { Name = e.RosterItem.Jid.Bare };
                    newItem.SubItems.AddRange(new[] { "", "" });


                    listContacts.Items.Add(newItem);
                }

                if (contract.Count() > 0)
                {
                    listContacts.Items[listContacts.Items.IndexOf(contract[0])].Text = e.RosterItem.Name;
                    listContacts.Items[listContacts.Items.IndexOf(contract[0])].Group = listGroup;
                }
            }
            else if (e.RosterItem.Subscription == Subscription.Remove)
            {
                listContacts.Items.RemoveByKey(e.RosterItem.Jid);
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
        
        private void cmdDisconnect_Click(object sender, System.EventArgs e)
        {
            xmppClient.Close();

            this.Hide();
            for (int ix = Application.OpenForms.Count - 1; ix > 0; --ix)
            {
                var frm = Application.OpenForms[ix];
                if (frm.GetType() != typeof(FrmMain)) frm.Close();
            }

            FrmLogin.Instance.Show();
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
            xmppClient.Close();
            FrmLogin.Instance.Close();
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
            var input = new FrmAddUser(_dictContactGroups, true);
            if (input.ShowDialog() == DialogResult.OK)
            {
                _dictContactGroups = input.DictContactGroups;
                var rm = new RosterManager(xmppClient);
                Jid jid = input.Address;
                rm.Add(jid, input.Name, input.Group);

                var pm = new PresenceManager(xmppClient);
                string reason = input.Message;
                pm.Subscribe(jid, reason, input.Name);
            }

            
        }

        private void deleteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (listContacts.SelectedItems.Count > 0)
            {
                var item = listContacts.SelectedItems[0];
                var rm = new RosterManager(xmppClient);
                Jid jid = item.Name;
                rm.Remove(jid);
            }
            
        }

        private void editToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (listContacts.SelectedItems.Count > 0)
            {
                var item = listContacts.SelectedItems[0];
                var input = new FrmAddUser(_dictContactGroups, false);
                input.Name = item.Text;
                input.Address = item.Name;
                input.Group = item.Group.Header;
                if (input.ShowDialog() == DialogResult.OK)
                {
                    var rm = new RosterManager(xmppClient);
                    Jid jid = input.Address;
                    rm.Update(jid, input.Name, input.Group);
                }
            }
        }

    }
}