using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MiniClient
{
    public partial class FrmAddUser : Form
    {
        public Dictionary<string, ListViewGroup> DictContactGroups
        {
            get;
            set;
        }
        public FrmAddUser(Dictionary<string, ListViewGroup> _dictContactGroups, bool isAdd)
        {
            InitializeComponent();
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
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
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

        private void btnAddGroup_Click(object sender, EventArgs e)
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
    }
}
