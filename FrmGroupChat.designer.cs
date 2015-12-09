namespace MiniClient
{
    partial class FrmGroupChat
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGroupChat));
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvwRoster = new System.Windows.Forms.ListView();
            this.headerNickname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerRole = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerAffiliation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ilsRoster = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rtfChat = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdChangeSubject = new System.Windows.Forms.Button();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rtfSend = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.cmdSend = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 417);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(781, 24);
            this.statusBar1.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvwRoster);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(781, 417);
            this.splitContainer1.SplitterDistance = 294;
            this.splitContainer1.TabIndex = 7;
            // 
            // lvwRoster
            // 
            this.lvwRoster.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.headerNickname,
            this.headerRole,
            this.headerAffiliation,
            this.columnHeader1});
            this.lvwRoster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwRoster.Location = new System.Drawing.Point(0, 0);
            this.lvwRoster.Name = "lvwRoster";
            this.lvwRoster.Size = new System.Drawing.Size(294, 417);
            this.lvwRoster.SmallImageList = this.ilsRoster;
            this.lvwRoster.TabIndex = 0;
            this.lvwRoster.UseCompatibleStateImageBehavior = false;
            this.lvwRoster.View = System.Windows.Forms.View.Details;
            // 
            // headerNickname
            // 
            this.headerNickname.Text = "Nickname";
            this.headerNickname.Width = 82;
            // 
            // headerRole
            // 
            this.headerRole.Text = "Role";
            this.headerRole.Width = 75;
            // 
            // headerAffiliation
            // 
            this.headerAffiliation.Text = "Affiliation";
            this.headerAffiliation.Width = 83;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 0;
            // 
            // ilsRoster
            // 
            this.ilsRoster.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilsRoster.ImageStream")));
            this.ilsRoster.TransparentColor = System.Drawing.Color.Transparent;
            this.ilsRoster.Images.SetKeyName(0, "");
            this.ilsRoster.Images.SetKeyName(1, "");
            this.ilsRoster.Images.SetKeyName(2, "");
            this.ilsRoster.Images.SetKeyName(3, "");
            this.ilsRoster.Images.SetKeyName(4, "");
            this.ilsRoster.Images.SetKeyName(5, "");
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(483, 417);
            this.splitContainer2.SplitterDistance = 339;
            this.splitContainer2.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.Controls.Add(this.rtfChat, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmdChangeSubject, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtSubject, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(483, 339);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // rtfChat
            // 
            this.rtfChat.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel2.SetColumnSpan(this.rtfChat, 3);
            this.rtfChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfChat.Location = new System.Drawing.Point(3, 33);
            this.rtfChat.Name = "rtfChat";
            this.rtfChat.ReadOnly = true;
            this.rtfChat.Size = new System.Drawing.Size(477, 303);
            this.rtfChat.TabIndex = 3;
            this.rtfChat.Text = "";
            this.rtfChat.TextChanged += new System.EventHandler(this.rtfChat_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "Subject:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdChangeSubject
            // 
            this.cmdChangeSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdChangeSubject.Location = new System.Drawing.Point(406, 3);
            this.cmdChangeSubject.Name = "cmdChangeSubject";
            this.cmdChangeSubject.Size = new System.Drawing.Size(74, 24);
            this.cmdChangeSubject.TabIndex = 6;
            this.cmdChangeSubject.Text = "change";
            this.cmdChangeSubject.UseVisualStyleBackColor = true;
            this.cmdChangeSubject.Click += new System.EventHandler(this.cmdChangeSubject_Click);
            // 
            // txtSubject
            // 
            this.txtSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSubject.Location = new System.Drawing.Point(73, 3);
            this.txtSubject.Multiline = true;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(327, 24);
            this.txtSubject.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.rtfSend, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(483, 74);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rtfSend
            // 
            this.rtfSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfSend.Location = new System.Drawing.Point(3, 3);
            this.rtfSend.Name = "rtfSend";
            this.rtfSend.Size = new System.Drawing.Size(477, 38);
            this.rtfSend.TabIndex = 0;
            this.rtfSend.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSendFile);
            this.panel1.Controls.Add(this.btnHistory);
            this.panel1.Controls.Add(this.cmdSend);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 24);
            this.panel1.TabIndex = 1;
            // 
            // btnSendFile
            // 
            this.btnSendFile.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSendFile.Location = new System.Drawing.Point(3, 0);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(80, 24);
            this.btnSendFile.TabIndex = 8;
            this.btnSendFile.Text = "&Send File";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Visible = false;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnHistory.Location = new System.Drawing.Point(287, 0);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(80, 24);
            this.btnHistory.TabIndex = 8;
            this.btnHistory.Text = "&History";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // cmdSend
            // 
            this.cmdSend.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdSend.Location = new System.Drawing.Point(396, 0);
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.Size = new System.Drawing.Size(80, 24);
            this.cmdSend.TabIndex = 1;
            this.cmdSend.Text = "&Send";
            this.cmdSend.UseVisualStyleBackColor = true;
            this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
            // 
            // FrmGroupChat
            // 
            this.AcceptButton = this.cmdSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 441);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmGroupChat";
            this.Text = "Group Chat";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmGroupChat_FormClosed);
            this.Load += new System.EventHandler(this.FrmGroupChat_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox rtfSend;
        private System.Windows.Forms.ListView lvwRoster;
        private System.Windows.Forms.ColumnHeader headerNickname;
        private System.Windows.Forms.Button cmdSend;
        private System.Windows.Forms.ImageList ilsRoster;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.RichTextBox rtfChat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdChangeSubject;
        private System.Windows.Forms.ColumnHeader headerRole;
        private System.Windows.Forms.ColumnHeader headerAffiliation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.ColumnHeader columnHeader1;

    }
}