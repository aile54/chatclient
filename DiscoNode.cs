using System.Windows.Forms;
using Matrix;

namespace MiniClient
{
    class DiscoNode : TreeNode
    {
        public new string Name { get; set; }
        public string Node { get; set; }
        public Jid Jid { get; set; }

        public DiscoNode(string name, string node, Jid jid)
        {
            Name = name;
            Node = node;
            Jid = jid;

            Text = Name + " / " + Node + " / " + Jid;
        }
    }
}
