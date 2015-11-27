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

        public FrmHistoryTransaction(XmppClient xmppClient, Jid roomJid, string nickname)
        {
            InitializeComponent();
            _roomJid = roomJid;
            _xmppClient = xmppClient;
            _nickname = nickname;
        }

        private void FrmHistoryTransaction_Load(object sender, System.EventArgs e)
        {
            DataTable dt = new DataTable();
            HistoryTransactionTableAdapter local_history = new HistoryTransactionTableAdapter(); 
            SqlCeConnection connection = new SqlCeConnection(local_history.Connection.ConnectionString);
            connection.Open();
            SqlCeDataAdapter adapter = new SqlCeDataAdapter(string.Format(@"Select  Body, DateTime from HistoryTransaction 
                                            where AccountName = '{0}' and ServerID = '{1}' and GroupName = '{2}' and IsGroup = '1'",
                                            _xmppClient.Username, _xmppClient.XmppDomain, _roomJid.Bare), connection);
            adapter.Fill(dt);
            connection.Close();
            foreach (DataRow item in dt.Rows)
            {
                txtBox.AppendText("("+item["DateTime"]+") " + item["Body"]);
                txtBox.AppendText("\r\n");
            }
        }
    }
}
