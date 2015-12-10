using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Matrix;
using Matrix.Xmpp.Client;
using Matrix.Xmpp;

namespace MiniClient
{
    public partial class FrmAddUser : Form
    {
        public Dictionary<string, ListViewGroup> DictContactGroups
        {
            get;
            set;
        }

        XmppClient _xmppClient;
        public FrmAddUser(Dictionary<string, ListViewGroup> _dictContactGroups, bool isAdd, XmppClient xmppClient)
        {
            InitializeComponent();
            _xmppClient = xmppClient;
            DictContactGroups = _dictContactGroups;
            foreach (var item in DictContactGroups)
            {
                cboGroup.Items.Add(item.Value);
            }

            if (!isAdd)
            {
                txtAddress.Enabled = false;
                rtMessage.Enabled = false;
                btnAdd.Text = "Update";
            }
            _xmppClient.OnIq += new EventHandler<IqEventArgs>(_xmppClient_OnIq);
            txtName.Text = string.Empty;
        }

        void _xmppClient_OnIq(object sender, IqEventArgs e)
        {
            if (e.Iq.From != null && e.Iq.From.Bare == "search." + FrmLogin.Instance.HostName)
            {
                var query = e.Iq.Element<Matrix.Xmpp.Search.Search>();
                foreach (var itm in query.GetItems())
                {
                    var newItem = new RosterListViewItem(itm.Nick ?? itm.Jid.Bare, 0, null) { Name = itm.Jid.Bare };
                    listSearchContracts.Items.Add(newItem);
                }
            }
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public string Name
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }

        public string Address
        {
            get { return txtAddress.Text; }
            set { txtAddress.Text = value; }
        }

        public string Group
        {
            get { return cboGroup.Text; }
            set { cboGroup.Text = value; }
        }

        public string Message
        {
            get { return rtMessage.Text; }
            set { rtMessage.Text = value; }
        }

        private void btnAddGroup_Click(object sender, System.EventArgs e)
        {
            var input = new FrmInputBox("Enter new group", "Add group", "Group Name");
            if (input.ShowDialog() == DialogResult.OK)
            {
                string nickname = input.Result;
                var newGroup = new ListViewGroup(nickname);
                DictContactGroups.Add(nickname, newGroup);
                cboGroup.Items.Add(nickname);
            }
        }

        private void listSearchContracts_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (listSearchContracts.SelectedItems.Count > 0)
            {
                var item = listSearchContracts.SelectedItems[0];
                txtName.Text = item.Text;
                txtAddress.Text = item.Name;
            }
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            listSearchContracts.Clear();
            txtAddress.Text = string.Empty;
            QueryUser();
        }

        private void QueryUser()
        {
            SearchIq sIq = new SearchIq();
            sIq.To = new Jid("search.vitenet1.net");
            sIq.Type = IqType.Set;
            sIq.Search.Nick = txtName.Text;
            _xmppClient.Send(sIq);
        }
    }
}
