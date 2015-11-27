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
using Matrix.Xmpp.Vcard;

namespace MiniClient
{
    public partial class FrmVCard : Form
    {
        private readonly XmppClient xmppClient;
      

        public FrmVCard(XmppClient xc, Jid jid, bool own)
        {
            InitializeComponent();

            xmppClient = xc;

            if (own)
            {
                Text = "My VCard";
                cmdPublish.Enabled = true;
                GetMyVcard();
            }
            else
            {
                Text = "VCard: " + jid;
                GetVcard(jid);
            }
                
        }

        private void GetVcard(Jid jid)
        {
            var viq = new VcardIq {To = jid, Type = Matrix.Xmpp.IqType.Get};
            xmppClient.IqFilter.SendIq(viq, VcardResponse);
        }

        private void GetMyVcard()
        {
            var viq = new VcardIq {Type = Matrix.Xmpp.IqType.Get };
            xmppClient.IqFilter.SendIq(viq, VcardResponse);
        }

        private void VcardResponse(object sender, IqEventArgs e)
        {
            if (e.Iq.Type == Matrix.Xmpp.IqType.Result)
            {
                var vc = e.Iq.Query as Vcard;
                txtName.Text = vc.Fullname;
                txtNickname.Text = vc.Nickname;

                var  email = vc.GetEmails().FirstOrDefault(m => m.IsInternet);
                if (email != null)
                    txtEmail.Text = email.Address;
            }
        }


        private void SetMyVcard()
        {
            var viq = new VcardIq { Type = Matrix.Xmpp.IqType.Set };
            
            if (!string.IsNullOrEmpty(txtName.Text))
                viq.Vcard.Fullname = txtName.Text;

            if (!string.IsNullOrEmpty(txtNickname.Text))
            viq.Vcard.Nickname = txtNickname.Text;

            if (!string.IsNullOrEmpty(txtEmail.Text))
                viq.Vcard.AddEmail(new Email {IsInternet = true, Address = txtEmail.Text});
            
            xmppClient.IqFilter.SendIq(viq, VcardUpdateResponse);
        }

        private void VcardUpdateResponse(object sender, IqEventArgs e)
        {
            if (e.Iq.Type == Matrix.Xmpp.IqType.Result)
            {
                MessageBox.Show("The VCard was updated successful!!");
            }
        }

        private void cmdPublish_Click(object sender, System.EventArgs e)
        {
            SetMyVcard();
        }
    }
}