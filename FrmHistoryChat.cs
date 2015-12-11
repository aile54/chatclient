using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiniClient.ClientDatabaseTableAdapters;
using System.Data.SqlServerCe;
using Matrix.Xmpp.Client;
using Matrix;
using Encrypt_Decrypt_Tool;

namespace MiniClient
{
    public partial class FrmHistoryChat : Form
    {
        private readonly Jid _roomJid;
        private readonly XmppClient _xmppClient;
        private readonly string _nickname;
        private readonly bool _isGroup;
        public static FrmGroupChat Instance;
        public FrmHistoryChat(XmppClient xmppClient, Jid roomJid, string nickname, bool isGroup)
        {
            InitializeComponent();
            _roomJid = roomJid;
            _xmppClient = xmppClient;
            _nickname = nickname;
            _isGroup = isGroup;
            this.Load += new EventHandler(FrmHistoryChat_Load);
            this.FormClosed += new FormClosedEventHandler(FrmHistoryChat_FormClosed);
            this.dgvHistoryChat.MasterRowExpanded += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(dgvHistoryChat_MasterRowExpanded);
        }

        void FrmHistoryChat_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isGroup)
            {
                FrmGroupChat.Instance.btnHistory.Enabled = true;
            }
            else
            {
                FrmChat.Instance.btnHistory.Enabled = true;
            }
            
        }

        void dgvHistoryChat_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView dgvMain = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DevExpress.XtraGrid.Views.Grid.GridView detailView = dgvMain.GetDetailView(e.RowHandle, e.RelationIndex) as DevExpress.XtraGrid.Views.Grid.GridView;
            detailView.OptionsView.ShowColumnHeaders = false;
            detailView.OptionsView.RowAutoHeight = true;
            detailView.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            detailView.Columns["Body"].ColumnEdit = this.repositoryItemMemoEdit1;

            detailView.Columns["Date"].Visible = false;
            detailView.Columns["DateTime"].Visible = false;

            detailView.Columns["PIC"].Width = 100;
            detailView.Columns["Time"].Width = 100;
        }

        void FrmHistoryChat_Load(object sender, System.EventArgs e)
        {
            FrmParent.Instance.ShowLoading();
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            HistoryTransactionTableAdapter local_history = new HistoryTransactionTableAdapter();
            SqlCeConnection connection = new SqlCeConnection(local_history.Connection.ConnectionString);
            connection.Open();
            SqlCeDataAdapter adapter = new SqlCeDataAdapter(string.Format(@"Select DateTime, convert(nvarchar(12), DateTime, 101) as Date,  
                                            convert(nvarchar(12), DateTime, 108) as Time, PIC,  Body from HistoryTransaction 
                                            where AccountName = '{0}' and ServerID = '{1}' and GroupName = '{2}' and IsGroup = '{3}' ORDER BY DateTime ASC",
                                            _xmppClient.Username, _xmppClient.XmppDomain, _roomJid.Bare, (_isGroup ? "1" : "0")), connection);
            adapter.Fill(dt);

            adapter = new SqlCeDataAdapter(string.Format(@"Select Distinct convert(nvarchar(12), DateTime, 101) as Date from HistoryTransaction 
                                            where AccountName = '{0}' and ServerID = '{1}' and GroupName = '{2}' and IsGroup = '{3}'",
                                            _xmppClient.Username, _xmppClient.XmppDomain, _roomJid.Bare, (_isGroup ? "1" : "0")), connection);
            adapter.Fill(dt1);
            connection.Close();

            foreach (DataRow item in dt.Rows)
            {
                item["Body"] = Cryptography.RSA2.Decrypt(item["Body"].ToString());
            }

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dt1);
            dataSet.Tables.Add(dt);
            dataSet.Relations.Add("Content", dataSet.Tables[0].Columns["Date"],
                                       dataSet.Tables[1].Columns["Date"]);
            this.dgcHistoryChat.DataSource = dt1;
            FrmParent.Instance.HideLoading();
        }
    }
}
