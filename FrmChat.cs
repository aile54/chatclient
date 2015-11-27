using System.Drawing;
using System.Windows.Forms;

using Matrix;
using Matrix.Xmpp;
using Matrix.Xmpp.Client;
using EventArgs = System.EventArgs;
using Message = Matrix.Xmpp.Client.Message;

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

		
		public FrmChat(Jid jid, XmppClient con, string nickname)
		{
			_jid		= jid;
			_xmppClient = con;
			_nickname	= nickname;

			InitializeComponent();
			
			Text = "Chat with " + nickname;
			
			Util.ChatForms.Add(_jid.Bare.ToLower(), this);

			// Setup new Message Callback
            con.MessageFilter.Add(jid, new BareJidComparer(), OnMessage);
		}
        
		private void OutgoingMessage(Message msg)
		{
			rtfChat.SelectionColor = Color.Blue;
			rtfChat.AppendText("Me said: ");
			rtfChat.SelectionColor = Color.Black;
			rtfChat.AppendText(msg.Body);
			rtfChat.AppendText("\r\n");
		}

		public void IncomingMessage(Message msg)
		{
			rtfChat.SelectionColor = Color.Red;
			rtfChat.AppendText(_nickname + " said: ");
			rtfChat.SelectionColor = Color.Black;
			rtfChat.AppendText(msg.Body);
			rtfChat.AppendText("\r\n");
		}

		private void cmdSend_Click(object sender, EventArgs e)
		{
			var msg = new Message {Type = MessageType.Chat, To = _jid, Body = rtfSend.Text};

		    _xmppClient.Send(msg);
			OutgoingMessage(msg);
			rtfSend.Text = "";
		}

		private void OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Body != null)
			    IncomingMessage(e.Message);
		}

        private void FrmChat_FormClosed(object sender, FormClosedEventArgs e)
        {
            Util.ChatForms.Remove(_jid.Bare.ToLower());
            _xmppClient.MessageFilter.Remove(_jid);
            _xmppClient = null;
        }
	}
}