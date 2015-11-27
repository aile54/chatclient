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
        }
    }
}
