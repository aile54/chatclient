using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MiniClient.Settings;

namespace MiniClient
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        public static FrmLogin Instance;
        public static FrmMain FrmMain;

        private Settings.Settings _settings;
        private Login _login;

        public string UserName { get { return txtUsername.Text; } }
        public string Password { get { return txtPassword.Text; } }
        public string XmppServer { get { return txtXmppServer.Text; } }
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public FrmLogin()
        {
            InitializeComponent();
            InitSettings();

            FrmLogin.Instance = this;
            FrmLogin.FrmMain = new FrmMain();
            FrmLogin.FrmMain.MdiParent = FrmParent.Instance;

            this.xmppClient.OnBeforeSasl += new EventHandler<Matrix.Xmpp.Sasl.SaslEventArgs>(xmppClient_OnBeforeSasl);
            this.xmppClient.OnAuthError += new EventHandler<Matrix.Xmpp.Sasl.SaslEventArgs>(xmppClient_OnAuthError);
            this.xmppClient.OnLogin +=new EventHandler<Matrix.EventArgs>(xmppClient_OnLogin);
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {    
            // set settings
            _login.User = txtUsername.Text;
            _login.Server = txtXmppServer.Text;
            _login.Password = txtPassword.Text;

            xmppClient.SetUsername(FrmLogin.Instance.UserName);
            xmppClient.SetXmppDomain(FrmLogin.Instance.XmppServer);
            xmppClient.Password = FrmLogin.Instance.Password;

            xmppClient.Status = "ready for chat";
            xmppClient.Show = Matrix.Xmpp.Show.Chat;


            Matrix.License.LicenseManager.m_IsValid = true;
            xmppClient.Open();

         
        }

        private void InitSettings()
        {
            _settings = Util.LoadSettings();
            if (_settings.Login == null)
                _settings.Login = new Login();

            _login = _settings.Login;

            if (_login != null)
            {
                if (!string.IsNullOrEmpty(_login.User))
                    txtUsername.Text = _login.User;

                if (!string.IsNullOrEmpty(_login.Server))
                    txtXmppServer.Text = _login.Server;

                if (!string.IsNullOrEmpty(_login.Password))
                    txtPassword.Text = _login.Password;
            }
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Util.SaveSettings(_settings);
            FrmParent.Instance.Dispose();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void xmppClient_OnBeforeSasl(object sender, Matrix.Xmpp.Sasl.SaslEventArgs e)
        {
            e.Auto = false;
            e.SaslMechanism = Matrix.Xmpp.Sasl.SaslMechanism.Plain;

            /*
            with the following code you can disable the SASL automatic and manual specify a mechanism.
            
             * e.Auto = false;
            e.SaslMechanism = Matrix.Xmpp.Sasl.SaslMechanism.PLAIN;
            */


            // X_FACEBOOK_PLATFORM Facebook Auth example
            //e.Auto = false;
            //e.SaslMechanism = Matrix.Xmpp.Sasl.SaslMechanism.X_FACEBOOK_PLATFORM;

            //const string APPLICATION_KEY = "12345678901234567890";
            //const string SECRET_KEY = "98765432109876543210";
            //e.SaslProperties = new Matrix.Xmpp.Sasl.Processor.Facebook.FacebookProperties
            //                       {
            //                           ApiKey = APPLICATION_KEY,
            //                           ApiSecret = SECRET_KEY,
            //                           SessionKey = "session_key_from_facebook_api"
            //                       };
        }

        private void xmppClient_OnAuthError(object sender, Matrix.Xmpp.Sasl.SaslEventArgs e)
        {
            xmppClient.Close();

            MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!");
        }

        private void xmppClient_OnLogin(object sender, Matrix.EventArgs e)
        {
            FrmLogin.FrmMain.Show();
            this.Hide();
        }
    }
}