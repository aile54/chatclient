using System;
using System.Windows.Forms;

namespace MiniClient
{
    public partial class FrmInputBox : Form
    {
        public FrmInputBox()
        {
            InitializeComponent();
        }

        public FrmInputBox(string prompt, string title)
            : this(prompt, title, "")
        {
        }

        public FrmInputBox(string prompt, string title, string @default) : this()
        {
            lblMessage.Text = prompt;
            Text = title;
            txtInput.Text = @default;
        }
    
        private void cmdOK_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {            
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public string Result
        {
            get { return txtInput.Text; }
        }
       
    }
}