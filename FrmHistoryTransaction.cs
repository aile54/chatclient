using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Matrix.Xmpp.Client;
using Matrix;
using MiniClient.ClientDatabaseTableAdapters;
using System.Data.SqlServerCe;

namespace MiniClient
{
    public partial class FrmHistoryTransaction : Form
    {
        private readonly Jid _roomJid;
        private readonly XmppClient _xmppClient;
        private readonly string _nickname;
        private readonly bool _isGroup;

        public FrmHistoryTransaction(XmppClient xmppClient, Jid roomJid, string nickname, bool isGroup)
        {
            InitializeComponent();
            _roomJid = roomJid;
            _xmppClient = xmppClient;
            _nickname = nickname;
            _isGroup = isGroup;
        }

        private void FrmHistoryTransaction_Load(object sender, System.EventArgs e)
        {
            DataTable dt = new DataTable();
            HistoryTransactionTableAdapter local_history = new HistoryTransactionTableAdapter();
            SqlCeConnection connection = new SqlCeConnection(local_history.Connection.ConnectionString);
            connection.Open();
            SqlCeDataAdapter adapter = new SqlCeDataAdapter(string.Format(@"Select  Body, DateTime from HistoryTransaction 
                                            where AccountName = '{0}' and ServerID = '{1}' and GroupName = '{2}' and IsGroup = '{3}' ORDER BY DateTime ASC",
                                            _xmppClient.Username, _xmppClient.XmppDomain, _roomJid.Bare, (_isGroup ? "1" : "0")), connection);
            adapter.Fill(dt);
            connection.Close();
            DateTime dtTemp = new DateTime();
            foreach (DataRow item in dt.Rows)
            {
                DateTime dTime = DateTime.Parse(item["DateTime"].ToString());
                if (dt.Rows.IndexOf(item) == 0)
                {
                    dtTemp = dTime;
                    txtBox.SelectionColor = Color.Black;
                    txtBox.SelectionAlignment = HorizontalAlignment.Center;
                    txtBox.SelectionFont = new System.Drawing.Font(txtBox.Font, FontStyle.Bold);
                    txtBox.AppendText(dtTemp.ToLongDateString().ToString());
                    txtBox.AppendText("\r\n");
                }
                else if (dtTemp.Date.CompareTo(dTime.Date) != 0)
                {
                    dtTemp = dTime;
                    txtBox.SelectionColor = Color.Black;
                    txtBox.SelectionAlignment = HorizontalAlignment.Center;
                    txtBox.SelectionFont = new System.Drawing.Font(txtBox.Font, FontStyle.Bold);
                    txtBox.AppendText(dtTemp.ToLongDateString().ToString());
                    txtBox.AppendText("\r\n");
                }

                txtBox.SelectionAlignment = HorizontalAlignment.Left;
                txtBox.SelectionFont = new System.Drawing.Font(txtBox.Font, FontStyle.Regular);
                txtBox.AppendText("(" + DateTime.Parse(item["DateTime"].ToString()).TimeOfDay.ToString() + ") " + item["Body"]);
                txtBox.AppendText("\r\n");
            }
        }
    }
}
