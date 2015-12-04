using System.Drawing;
using System.Windows.Forms;

using Matrix;
using Matrix.Xmpp;
using Matrix.Xmpp.Client;
using EventArgs = System.EventArgs;
using Message = Matrix.Xmpp.Client.Message;
using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Text;
using MiniClient.ClientDatabaseTableAdapters;
using Encrypt_Decrypt_Tool;

namespace MiniClient
{
	/// <summary>
	/// 
	/// </summary>
	public partial class FrmChat : Form
	{
		private XmppClient	    _xmppClient;
		private Jid			    _jid;
		private readonly string	_nickname;
        DateTime LastDtDB = new DateTime();
        HistoryTransactionTableAdapter local_history;
        DateTime dtTemp = new DateTime();
        private MucManager mm;
		public FrmChat(Jid jid, XmppClient con, string nickname)
		{
			_jid		= jid;
			_xmppClient = con;
			_nickname	= nickname;
            local_history = new HistoryTransactionTableAdapter();
			InitializeComponent();
			
			Text = "Chat with " + nickname;
			
			Util.ChatForms.Add(_jid.Bare.ToLower(), this);
			// Setup new Message Callback
            con.MessageFilter.Add(jid, new BareJidComparer(), OnMessage);

            GetLastRow(_xmppClient.Username, _xmppClient.XmppDomain, _jid.Bare, out LastDtDB);

            this.Load += new EventHandler(FrmChat_Load);
		}

        void FrmChat_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlCeConnection connection = new SqlCeConnection(local_history.Connection.ConnectionString);
            connection.Open();
            SqlCeDataAdapter adapter = new SqlCeDataAdapter(string.Format(@"Select  DateTime, Body from HistoryTransaction 
                                            where AccountName = '{0}' and ServerID = '{1}' and GroupName = '{2}' and IsGroup = 0 ORDER BY Datetime ASC",
                                            _xmppClient.Username, _xmppClient.XmppDomain, _jid.Bare), connection);
            adapter.Fill(dt);
            connection.Close();

            foreach (DataRow item in dt.Rows)
            {
                if (item["DateTime"].ToString() != string.Empty)
                {
                    DateTime dTime = DateTime.Parse(item["DateTime"].ToString());
                    string decrypt = Cryptography.RSA2.Decrypt(item["Body"].ToString());
                    if (DateTime.Now.Date.AddDays(-1).CompareTo(dTime.Date) <= 0)
                    {
                        if (dt.Rows.IndexOf(item) == 0)
                        {
                            dtTemp = dTime;
                            rtfChat.SelectionColor = Color.Black;
                            rtfChat.SelectionAlignment = HorizontalAlignment.Center;
                            rtfChat.SelectionFont = new System.Drawing.Font(rtfChat.Font, FontStyle.Bold);
                            rtfChat.AppendText(dtTemp.ToLongDateString().ToString());
                            rtfChat.AppendText("\r\n");
                        }
                        else if (dtTemp.Date.CompareTo(dTime.Date) != 0)
                        {
                            dtTemp = dTime;
                            rtfChat.SelectionColor = Color.Black;
                            rtfChat.SelectionAlignment = HorizontalAlignment.Center;
                            rtfChat.SelectionFont = new System.Drawing.Font(rtfChat.Font, FontStyle.Bold);
                            rtfChat.AppendText(dtTemp.ToLongDateString().ToString());
                            rtfChat.AppendText("\r\n");
                        }

                        rtfChat.SelectionAlignment = HorizontalAlignment.Left;
                        rtfChat.SelectionFont = new System.Drawing.Font(rtfChat.Font, FontStyle.Regular);
                        rtfChat.AppendText("(" + DateTime.Parse(item["DateTime"].ToString()).TimeOfDay.ToString() + ") " + decrypt);
                        rtfChat.AppendText("\r\n");
                    }
                }
            }
        }

        private void GetLastRow(string user, string domain, string group, out DateTime lastDt)
        {
            lastDt = new DateTime();
            DataTable dt = new DataTable();
            SqlCeConnection connection = new SqlCeConnection(local_history.Connection.ConnectionString);
            connection.Open();
            SqlCeDataAdapter adapter = new SqlCeDataAdapter(string.Format(@"Select  MAX(DateTime) AS DateTime from HistoryTransaction 
                                            where AccountName = '{0}' and ServerID = '{1}' and GroupName = '{2}' and IsGroup = 0",
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
            string encrypt = Cryptography.RSA2.Encrypt(body);
            StringBuilder q = new StringBuilder();
            q.Append("INSERT INTO [HistoryTransaction] ([IsGroup], [AccountName], [ServerID], [GroupName], [Body], [DateTime]) VALUES ");
            q.AppendFormat("({0}, '{1}', '{2}', '{3}', '{4}', '{5}')", 0, _xmppClient.Username, _xmppClient.XmppDomain,
                _jid.Bare, encrypt, dt);
            SqlCeConnection connection = new SqlCeConnection(local_history.Connection.ConnectionString);
            connection.Open();
            SqlCeCommand sqlCeCommand = new SqlCeCommand();
            sqlCeCommand = connection.CreateCommand();
            sqlCeCommand.CommandText = q.ToString();
            sqlCeCommand.ExecuteNonQuery();

            //local_history.InsertQuery(true, _xmppClient.Username, _xmppClient.XmppDomain,
            //    _roomJid.Bare, person + ": " + body, dt);

        }

        private void OutgoingMessage(Message msg, string person, DateTime date)
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

            rtfChat.SelectionAlignment = HorizontalAlignment.Left;
            rtfChat.SelectionFont = new System.Drawing.Font(rtfChat.Font, FontStyle.Regular);
			rtfChat.SelectionColor = Color.Red;
			rtfChat.SelectionColor = Color.Blue;
			rtfChat.AppendText("Me said: ");
			rtfChat.SelectionColor = Color.Black;
			rtfChat.AppendText(msg.Body);
			rtfChat.AppendText("\r\n");

            SaveHistory(person, _xmppClient.Username + " said: " + msg.Body, date);
		}

		public void IncomingMessage(Message msg, string person, DateTime date)
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

            rtfChat.SelectionAlignment = HorizontalAlignment.Left;
            rtfChat.SelectionFont = new System.Drawing.Font(rtfChat.Font, FontStyle.Regular);
			rtfChat.SelectionColor = Color.Red;
			rtfChat.AppendText(_nickname + " said: ");
			rtfChat.SelectionColor = Color.Black;
			rtfChat.AppendText(msg.Body);
			rtfChat.AppendText("\r\n");

            SaveHistory(person, _nickname + " said: " + msg.Body, date);
		}

		private void cmdSend_Click(object sender, EventArgs e)
		{
			var msg = new Message {Type = MessageType.Chat, To = _jid, Body = rtfSend.Text};

		    _xmppClient.Send(msg);
			OutgoingMessage(msg, _jid.Bare, DateTime.Now);
			rtfSend.Text = "";
		}

		private void OnMessage(object sender, MessageEventArgs e)
        {
            try
            {
                if (e.Message.Delay != null)
                {
                    string datetime = e.Message.Delay.GetAttribute("stamp");
                    DateTime dt = new DateTime();
                    DateTime.TryParse(datetime, out dt);
                    if (DateTime.Now.Date.AddDays(-1).CompareTo(dt.Date) <= 0
                        && e.Message.Body != null)
                    {
                        IncomingMessage(e.Message, e.Message.From.Resource, dt);
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
                    if (e.Message.Body != null)
                        IncomingMessage(e.Message, e.Message.From.Bare, DateTime.Now);
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
		}

        private void FrmChat_FormClosed(object sender, FormClosedEventArgs e)
        {
            Util.ChatForms.Remove(_jid.Bare.ToLower());
            _xmppClient.MessageFilter.Remove(_jid);
            _xmppClient = null;
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            new FrmHistoryTransaction(_xmppClient, _jid, _nickname,false).ShowDialog();
        }
	}
}