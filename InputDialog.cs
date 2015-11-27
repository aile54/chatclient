using System;
using System.Windows.Forms;

namespace MiniClient
{
    /// <summary>
    /// Summary description for InputBox.
    ///</summary>
    public partial class InputDialog : Form
    {

        #region Windows Contols and Constructor

       
        public InputDialog()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        #endregion

      
        #region Private Variables
        string formCaption = string.Empty;
        string formPrompt = string.Empty;
        string inputResponse = string.Empty;
        string defaultValue = string.Empty;
        #endregion

        #region Public Properties
        public string FormCaption
        {
            get { return formCaption; }
            set { formCaption = value; }
        }

        public string FormPrompt
        {
            get { return formPrompt; }
            set { formPrompt = value; }
        }

        public string InputResponse
        {
            get { return inputResponse; }
            set { inputResponse = value; }
        }

        public string DefaultValue
        {
            get { return defaultValue; }
            set { defaultValue = value; }
        }

        #endregion

  
        private void InputBox_Load(object sender, EventArgs e)
        {
            txtInput.Text = defaultValue;
            lblPrompt.Text = formPrompt;
            Text = formCaption;
            txtInput.SelectionStart = 0;
            txtInput.SelectionLength = txtInput.Text.Length;
            txtInput.Focus();
        }

        void BtnOKClick(object sender, EventArgs e)
        {
            InputResponse = txtInput.Text;
            Close();
        }

        void BtnCancelClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}