using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using Matrix;
using Matrix.Xmpp;
using Matrix.Xmpp.Client;
using Matrix.Xmpp.Muc.User;
using EventArgs = System.EventArgs;
using System;
using MiniClient.ClientDatabaseTableAdapters;
using System.Data.SqlServerCe;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading;

namespace MiniClient
{
    public partial class FrmGroupChat : Form
    {
        private MucManager mm;
        DateTime LastDtDB = new DateTime();
        HistoryTransactionTableAdapter local_history;
        #region << Constructors >>        
        public FrmGroupChat(XmppClient xmppClient, Jid roomJid, string nickname)
        {
            InitializeComponent();
            local_history = new HistoryTransactionTableAdapter();
            _roomJid = roomJid;
            _xmppClient = xmppClient;
            _nickname = nickname;

            mm = new MucManager(xmppClient);

            // Setup new Message Callback using the MessageFilter
            _xmppClient.MessageFilter.Add(roomJid, new BareJidComparer(), MessageCallback);
            
            // Setup new Presence Callback using the PresenceFilter
            _xmppClient.PresenceFilter.Add(roomJid, new BareJidComparer(), PresenceCallback);

            GetLastRow(_xmppClient.Username, _xmppClient.XmppDomain, _roomJid.Bare, out LastDtDB);
        }
        #endregion

        private readonly Jid                     _roomJid;
        private readonly XmppClient              _xmppClient;
        private readonly string                  _nickname;

        private void FrmGroupChat_Load(object sender, EventArgs e)
        {
            if (_roomJid != null)
            {
                mm.EnterRoom(_roomJid, _nickname);
            }
        }

        private void FrmGroupChat_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_roomJid != null)
            {
                mm.ExitRoom(_roomJid, _nickname);
                
                // Remove the Message Callback in the MessageFilter
                _xmppClient.MessageFilter.Remove(_roomJid);

                // Remove the Presence Callback in the MessageFilter
                _xmppClient.PresenceFilter.Remove(_roomJid);
            }

        }

        bool isEnd = false;
        private void MessageCallback(object sender, MessageEventArgs e)
        {
            try
            {
                if (e.Message.Type == MessageType.GroupChat)
                {
                    if (e.Message.Delay != null)
                    {
                        string datetime = e.Message.Delay.GetAttribute("stamp");
                        DateTime dt = new DateTime();
                        DateTime.TryParse(datetime, out dt);
                        if (DateTime.Now.Date.AddDays(-1).CompareTo(dt.Date) <= 0)
                        {
                            IncomingMessage(e.Message);
                        }
                        else
                        {
                            if (LastDtDB.CompareTo(dt) < 0)
                            {
                                SaveHistory(e.Message.From.Resource, e.Message.Body, dt);
                            }
                        }
                    }
                    else
                    {
                        IncomingMessage(e.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                throw;
            }
            
        }

        private void GetLastRow(string user, string domain, string group, out DateTime lastDt)
        {
            lastDt = new DateTime();
            DataTable dt = new DataTable();
            SqlCeConnection connection = new SqlCeConnection(local_history.Connection.ConnectionString);
            connection.Open();
            SqlCeDataAdapter adapter = new SqlCeDataAdapter(string.Format(@"Select  MAX(DateTime) AS DateTime from HistoryTransaction 
                                            where AccountName = '{0}' and ServerID = '{1}' and GroupName = '{2}'",
                                            user, domain, group), connection);
            adapter.Fill(dt);
            connection.Close();
            if (dt != null && dt.Rows.Count != 0 && dt.Rows[0]["DateTime"].ToString() != string.Empty)
            {
                lastDt = DateTime.Parse(dt.Rows[0]["DateTime"].ToString());
            }
        }

        private void SaveHistory(string person, string body, DateTime dt)
        {
            StringBuilder q = new StringBuilder();
            q.Append("INSERT INTO [HistoryTransaction] ([IsGroup], [AccountName], [ServerID], [GroupName], [Body], [DateTime]) VALUES ");
            q.AppendFormat("({0}, '{1}', '{2}', '{3}', '{4}', '{5}')", 1, _xmppClient.Username, _xmppClient.XmppDomain,
                _roomJid.Bare, body.Replace("'","''"), dt);
            SqlCeConnection connection = new SqlCeConnection(local_history.Connection.ConnectionString);
            connection.Open();
            SqlCeCommand sqlCeCommand = new SqlCeCommand();
            sqlCeCommand = connection.CreateCommand();
            sqlCeCommand.CommandText = q.ToString();
            sqlCeCommand.ExecuteNonQuery();

            //local_history.InsertQuery(true, _xmppClient.Username, _xmppClient.XmppDomain,
            //    _roomJid.Bare, person + ": " + body, dt);
          
        }
      
        private void PresenceCallback(object sender, PresenceEventArgs e)
        {

            var mucX = e.Presence.MucUser;
            
            // check for status code 201, this means the room is not ready to use yet
            // we request an instant room and accept the and accept the default configuration by the server
            if (mucX.HasStatus(201)) // 201 =  room is awaiting configuration.
                mm.RequestInstantRoom(_roomJid);
           

            var lvi = FindListViewItem(e.Presence.From);
            if (lvi != null)
            {
                if (e.Presence.Type == PresenceType.Unavailable)
                {
                    lvi.Remove();
                }
                else
                {
                    int imageIdx = Util.GetRosterImageIndex(e.Presence);
                    lvi.ImageIndex = imageIdx;
                    lvi.SubItems[1].Text = (e.Presence.Status ?? "");
                    
                    var u = e.Presence.MucUser;
                    if (u != null)
                    {
                        lvi.SubItems[2].Text = u.Item.Affiliation.ToString();
                        lvi.SubItems[3].Text = u.Item.Role.ToString();
                    }
                }
            }
            else
            {
                int imageIdx = Util.GetRosterImageIndex(e.Presence);
                
                var lv = new ListViewItem(e.Presence.From.Resource) {Tag = e.Presence.From.ToString()};

                lv.SubItems.Add(e.Presence.Status ?? "");
                
                var u = e.Presence.MucUser;
                if (u != null)
                {
                    lv.SubItems.Add(u.Item.Affiliation.ToString());
                    lv.SubItems.Add(u.Item.Role.ToString());
                }
                lv.ImageIndex = imageIdx;
                lvwRoster.Items.Add(lv);
            }
        }

        private ListViewItem FindListViewItem(Jid jid)
        {
            foreach (ListViewItem lvi in lvwRoster.Items)
            {
                if (jid.ToString().ToLower() == lvi.Tag.ToString().ToLower())
                    return lvi;
            }
            return null;
        }

        DateTime dtTemp = new DateTime();
        private void IncomingMessage(Matrix.Xmpp.Client.Message msg)
        {
            if (msg.Type == MessageType.Error)
            {
                //Handle errors here
                // we dont handle them in this example
                return;
            }

            if (msg.Subject != null)
            {
                txtSubject.Text = msg.Subject;

                rtfChat.SelectionColor = Color.DarkGreen;
                // The Nickname of the sender is in GroupChat in the Resource of the Jid
                rtfChat.AppendText(msg.From.Resource + " changed subject: ");
                rtfChat.SelectionColor = Color.Black;                
                rtfChat.AppendText(msg.Subject);
                rtfChat.AppendText("\r\n");
            }
            else
            {
                if (msg.Delay != null)
                {
                    string datetime = msg.Delay.GetAttribute("stamp");
                    DateTime dt = new DateTime();
                    DateTime.TryParse(datetime, out dt);
                    if (dtTemp == null || dtTemp.CompareTo(DateTime.MinValue) == 0)
                    {
                        dtTemp = dt;
                        rtfChat.SelectionColor = Color.Black;
                        rtfChat.SelectionAlignment = HorizontalAlignment.Center;
                        rtfChat.SelectionFont = new System.Drawing.Font(rtfChat.Font, FontStyle.Bold);
                        rtfChat.AppendText(dt.ToLongDateString().ToString());
                        rtfChat.AppendText("\r\n");
                    }
                    else
                    {
                        if (dtTemp.Date.CompareTo(dt.Date) != 0)
                        {
                            dtTemp = dt;
                            rtfChat.SelectionColor = Color.Black;
                            rtfChat.SelectionAlignment = HorizontalAlignment.Center;
                            rtfChat.SelectionFont = new System.Drawing.Font(rtfChat.Font, FontStyle.Bold);
                            rtfChat.AppendText(dt.ToLongDateString().ToString());
                            rtfChat.AppendText("\r\n");
                        }
                    }
                }
                else if (dtTemp == null || dtTemp.CompareTo(DateTime.MinValue) == 0)
                {
                    dtTemp = DateTime.Now;
                    rtfChat.SelectionColor = Color.Black;
                    rtfChat.SelectionAlignment = HorizontalAlignment.Center;
                    rtfChat.SelectionFont = new System.Drawing.Font(rtfChat.Font, FontStyle.Bold);
                    rtfChat.AppendText(dtTemp.ToLongDateString().ToString());
                    rtfChat.AppendText("\r\n");
                }
                

                if (msg.Body == null)
                    return;

                rtfChat.SelectionAlignment = HorizontalAlignment.Left;
                rtfChat.SelectionFont = new System.Drawing.Font(rtfChat.Font, FontStyle.Regular);
                rtfChat.SelectionColor = Color.Red;
                // The Nickname of the sender is in GroupChat in the Resource of the Jid
                rtfChat.AppendText(msg.From.Resource + " said: ");
                rtfChat.SelectionColor = Color.Black;
                rtfChat.AppendText(msg.Body);
                rtfChat.AppendText("\r\n");
            }
        }

        private void cmdSend_Click(object sender, EventArgs e)
        {
            // Make sure that the users send no empty messages
            if (rtfSend.Text.Length > 0)
            {
                var msg = new Matrix.Xmpp.Client.Message
                              {
                                  Type = MessageType.GroupChat,
                                  To = _roomJid,
                                  Body = rtfSend.Text
                              };

                _xmppClient.Send(msg);

                rtfSend.Clear();
            }
        }

        /// <summary>
        /// Changing the subject in a chatroom in MUC rooms this could return an error when you are a normal user and not allowed
        /// to change the subject.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdChangeSubject_Click(object sender, EventArgs e)
        {
            var msg = new Matrix.Xmpp.Client.Message
                          {
                              Type = MessageType.GroupChat,
                              To = _roomJid,
                              Subject = txtSubject.Text
                          };

            _xmppClient.Send(msg);
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            new FrmHistoryTransaction(_xmppClient, _roomJid, _nickname).ShowDialog();
        }
    }
}