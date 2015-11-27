using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniClient
{
    partial class FrmChat
    {
        private System.ComponentModel.Container components = null;

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

       


        #region Form-Designer Code

        private void InitializeComponent()
        {
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmdSend = new System.Windows.Forms.Button();
            this.rtfSend = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.rtfChat = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 236);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(471, 24);
            this.statusBar1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 200);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(471, 36);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // cmdSend
            // 
            this.cmdSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSend.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdSend.Location = new System.Drawing.Point(391, 206);
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.Size = new System.Drawing.Size(72, 24);
            this.cmdSend.TabIndex = 7;
            this.cmdSend.Text = "&Send";
            this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
            // 
            // rtfSend
            // 
            this.rtfSend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtfSend.Location = new System.Drawing.Point(0, 152);
            this.rtfSend.Name = "rtfSend";
            this.rtfSend.Size = new System.Drawing.Size(471, 48);
            this.rtfSend.TabIndex = 8;
            this.rtfSend.Text = "";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 144);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(471, 8);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            // 
            // rtfChat
            // 
            this.rtfChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfChat.Location = new System.Drawing.Point(0, 0);
            this.rtfChat.Name = "rtfChat";
            this.rtfChat.Size = new System.Drawing.Size(471, 144);
            this.rtfChat.TabIndex = 10;
            this.rtfChat.Text = "";
            // 
            // frmChat
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(471, 260);
            this.Controls.Add(this.rtfChat);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.rtfSend);
            this.Controls.Add(this.cmdSend);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusBar1);
            this.Name = "frmChat";
            this.Text = "frmChat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmChat_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button cmdSend;
        private System.Windows.Forms.RichTextBox rtfSend;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.RichTextBox rtfChat;
    }
}
