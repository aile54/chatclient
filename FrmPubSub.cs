using System;
using System.Windows.Forms;
using Matrix;
using Matrix.Xml;
using Matrix.Xmpp.Client;
using Matrix.Xmpp.Disco;
using Matrix.Xmpp.PubSub;
using EventArgs=System.EventArgs;

namespace MiniClient
{
    public partial class FrmPubSub : Form
    {
        private DiscoManager _dm;
        private readonly PubSubManager _pm;

        public FrmPubSub(XmppClient client)
        {
            InitializeComponent();

            XmppClient = client;
            _pm = new PubSubManager(client);

            DiscoServer();
        }

        XmppClient XmppClient { get; set; }

        void DiscoServer()
        {
            _dm = new DiscoManager(XmppClient);
            _dm.DiscoverItems(XmppClient.XmppDomain, new EventHandler<IqEventArgs>(DiscoItemsResult));
        }

        void DiscoItemsResult(object sender, IqEventArgs e)
        {
            //<iq from="vm-debian" to="alex@vm-debian/MatriX" id="MX_4" type="result" xmlns="jabber:client">
            //  <query xmlns="http://jabber.org/protocol/disco#items">
            //      <item jid="conference.vm-debian" />
            //      <item jid="irc.vm-debian" />
            //      <item jid="pubsub.vm-debian" />
            //      <item jid="vjud.vm-debian" />
            //  </query>
            //</iq>

            var query = e.Iq.Element<Matrix.Xmpp.Disco.Items>();
            if (query != null)
            {
                foreach (var itm in query.GetItems())
                {
                    // some servers have problems ifwe flood them weith too many packets here
                    // the sleep is a hack to avpid this problems.
                    //System.Threading.Thread.Sleep(200);
                    //_dm.DiscoverInformation(itm.Jid, itm.Node);
                    _dm.DiscoverInformation(itm.Jid, itm.Node, new EventHandler<IqEventArgs>(DiscoInfoResult));
                }
            }
        }



        void DiscoInfoResult(object sender, IqEventArgs e)
        {
            var query = e.Iq.Element<Info>();
            if (query != null)
            {
                foreach (var id in query.GetIdentities())
                {
                    if (id.Category == "pubsub")
                    {
                        cboService.Items.Add(e.Iq.From);
                        var newnode = new DiscoNode(e.Iq.From, null, e.Iq.From);
                        treeNodes.Nodes.Add(newnode);
                        DiscoPubSubNodes(e.Iq.From, null, newnode);
                    }
                }
            }
        }

        void DiscoPubSubNodes(Jid jid, string node, TreeNode treenode)
        {
            _dm.DiscoverItems(jid, node, new EventHandler<IqEventArgs>(DiscoPubSubNodesResult), treenode);
        }

        void DiscoPubSubNodesResult(object sender, IqEventArgs e)
        {
            /*
            <iq from="pubsub.vm-debian" type="result" to="alex@vm-debian/Alex-TP" id="aadda" >
                <query xmlns="http://jabber.org/protocol/disco#items" node="/home" >
                    <item node="/home/vm-debian" name="vm-debian" jid="pubsub.vm-debian" />
                </query>
            </iq>
            */
            var query = e.Iq.Element<Matrix.Xmpp.Disco.Items>();
            if (query != null)
            {
                foreach (var item in query.GetItems())
                {
                    var newnode = new DiscoNode(item.Name, item.Node, item.Jid)
                                      {ContextMenuStrip = contextMenuStripNodes};
                    ((TreeNode) e.State).Nodes.Add(newnode);
                    DiscoPubSubNodes(item.Jid, item.Node, newnode);
                }
            }
        }

        private void cmdCreate_Click(object sender, EventArgs e)
        {
            _pm.CreateNode(cboService.Text, txtNode.Text, new EventHandler<IqEventArgs>(CreateNodeResult));
        }

        private void CreateNodeResult(object sender, IqEventArgs e)
        {
            /*
            <iq from="pubsub.vm-debian" to="alex@vm-debian/MatriX" id="MX_9" type="result" xmlns="jabber:client">
                <pubsub xmlns="http://jabber.org/protocol/pubsub">
                    <create node="/home/vm-debian/alex" />
                </pubsub>
            </iq>
            */
            if (e.Iq.Type == Matrix.Xmpp.IqType.Result)
            {
                var pubsub = e.Iq.Element<PubSub>();
                if (pubsub != null)
                {
                    if (pubsub.Create != null)
                        MessageBox.Show(String.Format("node {0} was created!", pubsub.Create.Node));
                }
            }
            else if (e.Iq.Type == Matrix.Xmpp.IqType.Error)
            {
                string node = "";

                var error = e.Iq.Element<Error>();
                var pubsub = e.Iq.Element<PubSub>();
                if (pubsub != null)
                {
                    if (pubsub.Create != null)
                        node = pubsub.Create.Node;
                }

                if (error != null)
                {

                    string msg = String.Format("creation of node {0} failed!\r\nError Condition: {1}\r\nError Type: {2}",
                                               node,
                                               error.Condition,
                                               error.Type);
                    MessageBox.Show(msg);
                }
            }
        }

        private void treeNodes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node is DiscoNode)
            {
                var dn = e.Node as DiscoNode;

                lblNode.Text = dn.Node;
                lblJid.Text  = dn.Jid;
                lblName.Text = dn.Name;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pNode = treeNodes.SelectedNode as DiscoNode;
            if (pNode != null)
            {
                _pm.DeleteNode(cboService.Text, 
                    pNode.Node,
                    DeleteNodeResult,
                    pNode);
            }
        }

        private void DeleteNodeResult(object sender, IqEventArgs e)
        {
             if (e.Iq.Type == Matrix.Xmpp.IqType.Result)
             {
                 var pNode = e.State as DiscoNode;
                 if (pNode != null)
                 {
                     MessageBox.Show(String.Format("node {0} was deleted!", pNode.Node));
                     pNode.Remove();
                 }
             }
             else if (e.Iq.Type == Matrix.Xmpp.IqType.Error)
             {
                 // handle error here.
             }
        }

        private void cmdInstantNode_Click(object sender, EventArgs e)
        {
            _pm.CreateInstantNode(cboService.Text, CreateInstantNodeResult);
        }
        
        private void CreateInstantNodeResult(object sender, IqEventArgs e)
        {
            if (e.Iq.Type == Matrix.Xmpp.IqType.Result)
            {

                var pubsub = e.Iq.Element<PubSub>();
                if (pubsub != null)
                {
                    if (pubsub.Create != null)
                        MessageBox.Show(String.Format("node {0} was created!", pubsub.Create.Node));
                }
            }
            else if (e.Iq.Type == Matrix.Xmpp.IqType.Error)
            {
                // handle error here.
            }
        }

        private void subscribeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // subscibe to a node
            var pNode = treeNodes.SelectedNode as DiscoNode;
            if (pNode != null)
            {
                var myBareJid = new Jid {User = XmppClient.Username, Server = XmppClient.XmppDomain};
                _pm.Subscribe(cboService.Text,
                             pNode.Node, 
                             myBareJid, 
                             SubscribeResult, pNode.Node);
            }
        }

        private void SubscribeResult(object sender, IqEventArgs e)
        {
            if (e.Iq.Type == Matrix.Xmpp.IqType.Result)
            {
                MessageBox.Show(String.Format("You are now subscribed to the node: {0}", e.State as string));
            }
            else if (e.Iq.Type == Matrix.Xmpp.IqType.Error)
            {
                // handle error here.
            }
        }

        private void publishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var payload = InputBox("Enter the payload to publish!", "Payload", "");
            
            if (payload == string.Empty)
                return;

            var item = new Matrix.Xmpp.PubSub.Item {Value = payload};
            
            //var item = new Matrix.Xmpp.PubSub.Item();
            //item.Add(new XmppXElement("mypaload", "mynamespace"));

            var pNode = treeNodes.SelectedNode as DiscoNode;
            if (pNode != null)
            {
                _pm.PublishItem(cboService.Text,
                                pNode.Node, 
                                item,
                                PublishResult);
            }
        }

        private void PublishResult(object sender, IqEventArgs e)
        {
            if (e.Iq.Type == Matrix.Xmpp.IqType.Result)
            {
                
            }
            else if (e.Iq.Type == Matrix.Xmpp.IqType.Error)
            {
                // handle error here.
            }
        }

        public static string InputBox(string prompt, string title, string defaultValue)
        {
            var inputDialog = new InputDialog {FormPrompt = prompt, FormCaption = title, DefaultValue = defaultValue};
            inputDialog.ShowDialog();
            
            string s = inputDialog.InputResponse;
            inputDialog.Close();
            
            return s;
        }

    }
}