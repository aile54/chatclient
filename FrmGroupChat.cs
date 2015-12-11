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
using Encrypt_Decrypt_Tool;
using System.Collections.Generic;

namespace MiniClient
{
    public partial class FrmGroupChat : Form
    {
        private MucManager mm;
        DateTime LastDtDB = new DateTime();
        HistoryTransactionTableAdapter local_history;
        SqlCeConnection connection;
        FileTransferManager fm = new FileTransferManager();
        Dictionary<string, string> listAddress = new Dictionary<string, string>();
        private readonly ListView _listContract;
        private readonly Jid _roomJid;
        private readonly XmppClient _xmppClient;
        private readonly string _nickname;
        DataTable dtHistory = new DataTable();
        bool isHis = false;
        public static FrmGroupChat Instance;
        #region << Constructors >>
        public FrmGroupChat(XmppClient xmppClient, Jid roomJid, string nickname, ListView listContract)
        {
            InitializeComponent();
            local_history = new HistoryTransactionTableAdapter();
            connection = new SqlCeConnection(local_history.Connection.ConnectionString);
            _roomJid = roomJid;
            _xmppClient = xmppClient;
            _nickname = nickname;
            _listContract = listContract;
            fm.XmppClient = FrmLogin.Instance.xmppClient;
            fm.OnFile += fm_OnFile;
            Text = roomJid.User + " Group"; ;
            mm = new MucManager(xmppClient);

            // Setup new Message Callback using the MessageFilter
            _xmppClient.MessageFilter.Add(roomJid, new BareJidComparer(), MessageCallback);

            // Setup new Presence Callback using the PresenceFilter
            _xmppClient.PresenceFilter.Add(roomJid, new BareJidComparer(), PresenceCallback);

            GetLastRow(_xmppClient.Username, _xmppClient.XmppDomain, _roomJid.Bare, out LastDtDB);
            btnHistory.Enabled = false;
            Form.CheckForIllegalCrossThreadCalls = false;
            Instance = this;
        }
        #endregion

        private void FrmGroupChat_Load(object sender, EventArgs e)
        {
            if (_roomJid != null)
            {
                mm.EnterRoom(_roomJid, _nickname);
            }

            dtHistory.Columns.Add("PIC", typeof(string));
            dtHistory.Columns.Add("Body", typeof(string));
            dtHistory.Columns.Add("DateTime", typeof(DateTime));
            timer1.Start();
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

                            timer1.Stop();
                            //Save history tb
                            ThreadStart starter = delegate { SaveHistory(); };
                            Thread thread = new Thread(starter);
                            thread.Start();
                            thread.Join();
                            if (!thread.IsAlive)
                            {
                                btnHistory.Enabled = true;
                            }
                        }
                        else
                        {
                            if (LastDtDB.CompareTo(dt) < 0)
                            {
                                isHis = true;
                                DataRow dr = dtHistory.NewRow();
                                dr["PIC"] = e.Message.From.Resource;
                                dr["Body"] = e.Message.Body;
                                dr["DateTime"] = dt;
                                dtHistory.Rows.Add(dr);
                                //SaveHistory(e.Message.From.Resource, e.Message.Body, dt, e.Message.From.Resource);
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

        private void SaveHistory()
        {
            StringBuilder q = new StringBuilder();
            connection.Open();
            var transaction = connection.BeginTransaction();
            SqlCeCommand sqlCeCommand = connection.CreateCommand();
            sqlCeCommand.CommandType = CommandType.TableDirect;
            sqlCeCommand.CommandText = "HistoryTransaction";
            sqlCeCommand.Transaction = transaction;
            SqlCeResultSet result = sqlCeCommand.ExecuteResultSet(ResultSetOptions.Updatable);
            SqlCeUpdatableRecord rec = result.CreateRecord();
            foreach (DataRow item in dtHistory.Rows)
            {
                string encrypt = Cryptography.RSA2.Encrypt(item["Body"].ToString());
                //                q.Append(@"INSERT INTO [HistoryTransaction] ([IsGroup], [AccountName], 
                //                        [ServerID], [GroupName], [Body], [DateTime], [PIC]) VALUES ");
                //                q.AppendFormat("({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", 
                //                            1, _xmppClient.Username, _xmppClient.XmppDomain,
                //                            _roomJid.Bare, encrypt, DateTime.Parse(item["Body"].ToString()), item["PIC"].ToString());

                rec.SetValue(1, 1);
                rec.SetValue(2, _xmppClient.Username);
                rec.SetValue(3, _xmppClient.XmppDomain);
                rec.SetValue(4, _roomJid.Bare);
                rec.SetValue(5, encrypt);
                rec.SetValue(6, DateTime.Parse(item["DateTime"].ToString()));
                rec.SetValue(7, item["PIC"].ToString());
                result.Insert(rec);
            }

            result.Close();
            result.Dispose();
            transaction.Commit();
            connection.Close();
        }

        private void PresenceCallback(object sender, PresenceEventArgs e)
        {

            var mucX = e.Presence.MucUser;
            if (mucX == null)
            {
                if (e.Presence.Error.Type == Matrix.Xmpp.Base.ErrorType.Auth)
                {
                    if (e.Presence.Error.FirstAttribute.Value == "407")
                    {
                        MessageBox.Show("Unauthorized!");
                        this.Close();
                        return;
                    }
                }
            }
            // check for status code 201, this means the room is not ready to use yet
            // we request an instant room and accept the and accept the default configuration by the server
            if (mucX.HasStatus(201)) // 201 =  room is awaiting configuration.d
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
                    //lvi.SubItems[1].Text = (e.Presence.Status ?? "");

                    var u = e.Presence.MucUser;
                    if (u != null)
                    {
                        lvi.SubItems[1].Text = u.Item.Affiliation.ToString();
                        lvi.SubItems[2].Text = u.Item.Role.ToString();
                        //string bare = e.Presence.From.Resource + "@" + FrmLogin.Instance.HostName;
                        //listAddress[lvi.SubItems[3].Text] = bare;
                        //lvi.SubItems[3].Text = bare;
                    }
                }
            }
            else
            {
                int imageIdx = Util.GetRosterImageIndex(e.Presence);

                var lv = new ListViewItem(e.Presence.From.Resource) { Tag = e.Presence.From.ToString() };

                //lv.SubItems.Add(e.Presence.Status ?? "");

                var u = e.Presence.MucUser;
                if (u != null)
                {
                    lv.SubItems.Add(u.Item.Affiliation.ToString());
                    lv.SubItems.Add(u.Item.Role.ToString());
                    //string bare = e.Presence.From.Resource + "@" + FrmLogin.Instance.HostName;
                    //lv.SubItems.Add(bare);
                    //if (!listAddress.ContainsKey(bare))
                    //{
                    //    listAddress.Add(bare, bare);
                    //}
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
            try
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
            catch (Exception)
            {

                throw;
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
            btnHistory.Enabled = false;
            
            ThreadStart starter = delegate { new FrmHistoryChat(_xmppClient, _roomJid, _nickname, true).ShowDialog(); };
            Thread thread = new Thread(starter);
            thread.Start();
            if (!thread.IsAlive)
            {
                btnHistory.Enabled = true;
            }
        }

        private void rtfChat_TextChanged(object sender, EventArgs e)
        {
            rtfChat.SelectionStart = rtfChat.Text.Length; //Set the current caret position at the end
            rtfChat.ScrollToCaret(); //Now scroll it automatically
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            //Jid[] jid = new Jid[listAddress.Count - 1];
            //int j = 0;
            //for (int i = 0; i < lvwRoster.Items.Count; i++)
            //{
            //    string bare = lvwRoster.Items[i].SubItems[3].Text;
            //    if (bare != FrmLogin.Instance.UserName)
            //    {
            //        var item = _listContract.Items.Find(bare, true);
            //        if (item != null)
            //        {
            //            jid[j] = lvwRoster.Items[i].SubItems[3].Text;
            //            j++;
            //        }
            //    }
            //}
            //new FrmSendFile(fm, jid).Show();
        }

        void fm_OnFile(object sender, FileTransferEventArgs e)
        {
            var recvFile = new FrmReceiveFile(fm, e);
            recvFile.Show();
            recvFile.StartAccept();
            //e.Accept = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isHis)
            {
                //Save history tb
                ThreadStart starter = delegate { SaveHistory(); };
                Thread thread = new Thread(starter);
                thread.Start();
                thread.Join();
                if (!thread.IsAlive)
                {
                    btnHistory.Enabled = true;
                    isHis = false;
                    timer1.Stop();
                }
            }
        }
    }
}