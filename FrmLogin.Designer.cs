namespace MiniClient
{
    partial class FrmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSignIn = new DevExpress.XtraEditors.SimpleButton();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtXmppServer = new DevExpress.XtraEditors.TextEdit();
            this.xmppClient = new Matrix.Xmpp.Client.XmppClient();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXmppServer.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSignIn
            // 
            this.btnSignIn.Location = new System.Drawing.Point(177, 117);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(75, 23);
            this.btnSignIn.TabIndex = 0;
            this.btnSignIn.Text = "Sign in";
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.EditValue = "lmhieu@vitenet1.net";
            this.txtUsername.Location = new System.Drawing.Point(88, 33);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(164, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(19, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Username";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(19, 62);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Username";
            // 
            // txtPassword
            // 
            this.txtPassword.EditValue = "";
            this.txtPassword.Location = new System.Drawing.Point(88, 59);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(164, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(19, 88);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(61, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Xmpp Server";
            // 
            // txtXmppServer
            // 
            this.txtXmppServer.EditValue = "192.168.0.236";
            this.txtXmppServer.Location = new System.Drawing.Point(88, 85);
            this.txtXmppServer.Name = "txtXmppServer";
            this.txtXmppServer.Size = new System.Drawing.Size(83, 20);
            this.txtXmppServer.TabIndex = 5;
            // 
            // xmppClient
            // 
            this.xmppClient.Compression = false;
            this.xmppClient.Dispatcher = null;
            this.xmppClient.Hostname = null;
            this.xmppClient.ProxyHostname = null;
            this.xmppClient.ProxyPass = null;
            this.xmppClient.ProxyPort = 1080;
            this.xmppClient.ProxyType = Matrix.Net.Proxy.ProxyType.None;
            this.xmppClient.ProxyUser = null;
            this.xmppClient.ResolveSrvRecords = true;
            this.xmppClient.Status = "";
            this.xmppClient.StreamManagement = false;
            this.xmppClient.Transport = Matrix.Net.Transport.Socket;
            this.xmppClient.Uri = null;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 149);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtXmppServer);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnSignIn);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(279, 188);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(279, 188);
            this.Name = "FrmLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XMPP Chat Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLogin_FormClosed);
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXmppServer.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSignIn;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtXmppServer;
        public Matrix.Xmpp.Client.XmppClient xmppClient;
    }
}