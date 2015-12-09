namespace MiniClient
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btnSignOut = new System.Windows.Forms.Button();
            this.tabGroup = new System.Windows.Forms.TabControl();
            this.tabContacts = new System.Windows.Forms.TabPage();
            this.listContacts = new System.Windows.Forms.ListView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listGroup = new System.Windows.Forms.ListView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.listBookmarkedRooms = new System.Windows.Forms.ListView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listEvents = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rtfDebug = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ilstStatus = new System.Windows.Forms.ImageList(this.components);
            this.cmdPubSub = new System.Windows.Forms.Button();
            this.ctxMenuRoster = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdVcard = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.presenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presenceOnlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presenceChatToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.presenceAwayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presenceExtendedAwayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presenceDoNotDisturbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contractsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEnterRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xmppClient = new Matrix.Xmpp.Client.XmppClient();
            this.mucManager = new Matrix.Xmpp.Client.MucManager();
            this.pubSubManager = new Matrix.Xmpp.Client.PubSubManager();
            this.presenceManager = new Matrix.Xmpp.Client.PresenceManager();
            this.tabGroup.SuspendLayout();
            this.tabContacts.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.ctxMenuRoster.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSignOut
            // 
            this.btnSignOut.Location = new System.Drawing.Point(10, 27);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(75, 23);
            this.btnSignOut.TabIndex = 1;
            this.btnSignOut.Text = "Sign out";
            this.btnSignOut.UseVisualStyleBackColor = true;
            this.btnSignOut.Click += new System.EventHandler(this.cmdDisconnect_Click);
            // 
            // tabGroup
            // 
            this.tabGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabGroup.Controls.Add(this.tabContacts);
            this.tabGroup.Controls.Add(this.tabPage3);
            this.tabGroup.Controls.Add(this.tabPage4);
            this.tabGroup.Controls.Add(this.tabPage1);
            this.tabGroup.Controls.Add(this.tabPage2);
            this.tabGroup.Location = new System.Drawing.Point(10, 56);
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.SelectedIndex = 0;
            this.tabGroup.Size = new System.Drawing.Size(663, 421);
            this.tabGroup.TabIndex = 4;
            // 
            // tabContacts
            // 
            this.tabContacts.Controls.Add(this.listContacts);
            this.tabContacts.Location = new System.Drawing.Point(4, 22);
            this.tabContacts.Name = "tabContacts";
            this.tabContacts.Padding = new System.Windows.Forms.Padding(3);
            this.tabContacts.Size = new System.Drawing.Size(655, 395);
            this.tabContacts.TabIndex = 2;
            this.tabContacts.Text = "Contacts";
            this.tabContacts.UseVisualStyleBackColor = true;
            // 
            // listContacts
            // 
            this.listContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listContacts.Location = new System.Drawing.Point(3, 3);
            this.listContacts.Name = "listContacts";
            this.listContacts.ShowItemToolTips = true;
            this.listContacts.Size = new System.Drawing.Size(649, 389);
            this.listContacts.TabIndex = 0;
            this.listContacts.UseCompatibleStateImageBehavior = false;
            this.listContacts.DoubleClick += new System.EventHandler(this.listContacts_DoubleClick);
            this.listContacts.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listContacts_MouseUp);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listGroup);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(655, 395);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Group";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listGroup
            // 
            this.listGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listGroup.FullRowSelect = true;
            this.listGroup.GridLines = true;
            this.listGroup.Location = new System.Drawing.Point(3, 3);
            this.listGroup.Name = "listGroup";
            this.listGroup.Size = new System.Drawing.Size(649, 389);
            this.listGroup.TabIndex = 0;
            this.listGroup.UseCompatibleStateImageBehavior = false;
            this.listGroup.View = System.Windows.Forms.View.List;
            this.listGroup.DoubleClick += new System.EventHandler(this.listGroup_DoubleClick);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.listBookmarkedRooms);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(655, 395);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "Bookmarked rooms";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // listBookmarkedRooms
            // 
            this.listBookmarkedRooms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBookmarkedRooms.FullRowSelect = true;
            this.listBookmarkedRooms.GridLines = true;
            this.listBookmarkedRooms.Location = new System.Drawing.Point(3, 3);
            this.listBookmarkedRooms.Name = "listBookmarkedRooms";
            this.listBookmarkedRooms.Size = new System.Drawing.Size(649, 389);
            this.listBookmarkedRooms.TabIndex = 0;
            this.listBookmarkedRooms.UseCompatibleStateImageBehavior = false;
            this.listBookmarkedRooms.View = System.Windows.Forms.View.List;
            this.listBookmarkedRooms.DoubleClick += new System.EventHandler(this.listGroup_DoubleClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listEvents);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(655, 395);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Events";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listEvents
            // 
            this.listEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listEvents.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listEvents.FormattingEnabled = true;
            this.listEvents.ItemHeight = 15;
            this.listEvents.Location = new System.Drawing.Point(3, 3);
            this.listEvents.Name = "listEvents";
            this.listEvents.Size = new System.Drawing.Size(649, 389);
            this.listEvents.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rtfDebug);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(655, 395);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Debug XML";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rtfDebug
            // 
            this.rtfDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfDebug.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtfDebug.Location = new System.Drawing.Point(3, 3);
            this.rtfDebug.Name = "rtfDebug";
            this.rtfDebug.Size = new System.Drawing.Size(649, 389);
            this.rtfDebug.TabIndex = 0;
            this.rtfDebug.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 480);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(688, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ilstStatus
            // 
            this.ilstStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilstStatus.ImageStream")));
            this.ilstStatus.TransparentColor = System.Drawing.Color.Transparent;
            this.ilstStatus.Images.SetKeyName(0, "status_grey.png");
            this.ilstStatus.Images.SetKeyName(1, "status_green.png");
            this.ilstStatus.Images.SetKeyName(2, "status_yellow.png");
            this.ilstStatus.Images.SetKeyName(3, "status_red.png");
            // 
            // cmdPubSub
            // 
            this.cmdPubSub.Location = new System.Drawing.Point(91, 27);
            this.cmdPubSub.Name = "cmdPubSub";
            this.cmdPubSub.Size = new System.Drawing.Size(75, 23);
            this.cmdPubSub.TabIndex = 10;
            this.cmdPubSub.Text = "PubSub";
            this.cmdPubSub.UseVisualStyleBackColor = true;
            this.cmdPubSub.Visible = false;
            this.cmdPubSub.Click += new System.EventHandler(this.cmdPubSub_Click);
            // 
            // ctxMenuRoster
            // 
            this.ctxMenuRoster.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chatToolStripMenuItem,
            this.sendFileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.ctxMenuRoster.Name = "ctxMenuRoster";
            this.ctxMenuRoster.Size = new System.Drawing.Size(122, 70);
            // 
            // chatToolStripMenuItem
            // 
            this.chatToolStripMenuItem.Name = "chatToolStripMenuItem";
            this.chatToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.chatToolStripMenuItem.Text = "Chat";
            this.chatToolStripMenuItem.Click += new System.EventHandler(this.chatToolStripMenuItem_Click);
            // 
            // sendFileToolStripMenuItem
            // 
            this.sendFileToolStripMenuItem.Name = "sendFileToolStripMenuItem";
            this.sendFileToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.sendFileToolStripMenuItem.Text = "Send File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.deleteToolStripMenuItem1});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.updateToolStripMenuItem.Text = "Rename";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // cmdVcard
            // 
            this.cmdVcard.Location = new System.Drawing.Point(172, 27);
            this.cmdVcard.Name = "cmdVcard";
            this.cmdVcard.Size = new System.Drawing.Size(75, 23);
            this.cmdVcard.TabIndex = 11;
            this.cmdVcard.Text = "Vcard";
            this.cmdVcard.UseVisualStyleBackColor = true;
            this.cmdVcard.Click += new System.EventHandler(this.cmdVcard_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.presenseToolStripMenuItem,
            this.contractsToolStripMenuItem,
            this.groupChatToolStripMenuItem,
            this.settingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(688, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // presenseToolStripMenuItem
            // 
            this.presenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.presenceOnlineToolStripMenuItem,
            this.presenceChatToolStripMenuItem1,
            this.presenceAwayToolStripMenuItem,
            this.presenceExtendedAwayToolStripMenuItem,
            this.presenceDoNotDisturbToolStripMenuItem});
            this.presenseToolStripMenuItem.Name = "presenseToolStripMenuItem";
            this.presenseToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.presenseToolStripMenuItem.Text = "Presense";
            // 
            // presenceOnlineToolStripMenuItem
            // 
            this.presenceOnlineToolStripMenuItem.Name = "presenceOnlineToolStripMenuItem";
            this.presenceOnlineToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.presenceOnlineToolStripMenuItem.Text = "online";
            this.presenceOnlineToolStripMenuItem.Click += new System.EventHandler(this.presenceOnlineToolStripMenuItem_Click);
            // 
            // presenceChatToolStripMenuItem1
            // 
            this.presenceChatToolStripMenuItem1.Name = "presenceChatToolStripMenuItem1";
            this.presenceChatToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.presenceChatToolStripMenuItem1.Text = "chat";
            this.presenceChatToolStripMenuItem1.Click += new System.EventHandler(this.presenceChatToolStripMenuItem_Click);
            // 
            // presenceAwayToolStripMenuItem
            // 
            this.presenceAwayToolStripMenuItem.Name = "presenceAwayToolStripMenuItem";
            this.presenceAwayToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.presenceAwayToolStripMenuItem.Text = "away";
            this.presenceAwayToolStripMenuItem.Click += new System.EventHandler(this.presenceAwayToolStripMenuItem_Click);
            // 
            // presenceExtendedAwayToolStripMenuItem
            // 
            this.presenceExtendedAwayToolStripMenuItem.Name = "presenceExtendedAwayToolStripMenuItem";
            this.presenceExtendedAwayToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.presenceExtendedAwayToolStripMenuItem.Text = "extended away";
            this.presenceExtendedAwayToolStripMenuItem.Click += new System.EventHandler(this.presenceExtendedAwayToolStripMenuItem_Click);
            // 
            // presenceDoNotDisturbToolStripMenuItem
            // 
            this.presenceDoNotDisturbToolStripMenuItem.Name = "presenceDoNotDisturbToolStripMenuItem";
            this.presenceDoNotDisturbToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.presenceDoNotDisturbToolStripMenuItem.Text = "do not disturb";
            this.presenceDoNotDisturbToolStripMenuItem.Click += new System.EventHandler(this.presenceDoNotDisturbToolStripMenuItem_Click);
            // 
            // contractsToolStripMenuItem
            // 
            this.contractsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.contractsToolStripMenuItem.Name = "contractsToolStripMenuItem";
            this.contractsToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.contractsToolStripMenuItem.Text = "Contracts";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // groupChatToolStripMenuItem
            // 
            this.groupChatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEnterRoom});
            this.groupChatToolStripMenuItem.Name = "groupChatToolStripMenuItem";
            this.groupChatToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.groupChatToolStripMenuItem.Text = "Group Chat";
            // 
            // tsmiEnterRoom
            // 
            this.tsmiEnterRoom.Name = "tsmiEnterRoom";
            this.tsmiEnterRoom.Size = new System.Drawing.Size(208, 22);
            this.tsmiEnterRoom.Text = "Enter or create chat room";
            this.tsmiEnterRoom.Click += new System.EventHandler(this.tsmiEnterRoom_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetDatabaseToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingToolStripMenuItem.Text = "Options";
            // 
            // resetDatabaseToolStripMenuItem
            // 
            this.resetDatabaseToolStripMenuItem.Name = "resetDatabaseToolStripMenuItem";
            this.resetDatabaseToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.resetDatabaseToolStripMenuItem.Text = "Reset Database";
            this.resetDatabaseToolStripMenuItem.Click += new System.EventHandler(this.resetDatabaseToolStripMenuItem_Click);
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
            this.xmppClient.OnRosterStart += new System.EventHandler<Matrix.EventArgs>(this.xmppClient_OnRosterStart);
            this.xmppClient.OnRosterEnd += new System.EventHandler<Matrix.EventArgs>(this.xmppClient_OnRosterEnd);
            this.xmppClient.OnRosterItem += new System.EventHandler<Matrix.Xmpp.Roster.RosterEventArgs>(this.xmppClient_OnRosterItem);
            this.xmppClient.OnPresence += new System.EventHandler<Matrix.Xmpp.Client.PresenceEventArgs>(this.xmppClient_OnPresence);
            this.xmppClient.OnMessage += new System.EventHandler<Matrix.Xmpp.Client.MessageEventArgs>(this.xmppClient_OnMessage);
            this.xmppClient.OnIq += new System.EventHandler<Matrix.Xmpp.Client.IqEventArgs>(this.xmppClient_OnIq);
            this.xmppClient.OnRegisterInformation += new System.EventHandler<Matrix.Xmpp.Register.RegisterEventArgs>(this.xmppClient_OnRegisterInformation);
            this.xmppClient.OnRegister += new System.EventHandler<Matrix.EventArgs>(this.xmppClient_OnRegister);
            this.xmppClient.OnRegisterError += new System.EventHandler<Matrix.Xmpp.Client.IqEventArgs>(this.xmppClient_OnRegisterError);
            this.xmppClient.OnBind += new System.EventHandler<Matrix.JidEventArgs>(this.xmppClient_OnBind);
            this.xmppClient.OnBeforeSendPresence += new System.EventHandler<Matrix.Xmpp.Client.PresenceEventArgs>(this.xmppClient_OnBeforeSendPresence);
            this.xmppClient.OnReceiveXml += new System.EventHandler<Matrix.TextEventArgs>(this.xmppClient_OnReceiveXml);
            this.xmppClient.OnSendXml += new System.EventHandler<Matrix.TextEventArgs>(this.xmppClient_OnSendXml);
            this.xmppClient.OnStreamError += new System.EventHandler<Matrix.StreamErrorEventArgs>(this.xmppClient_OnStreamError);
            this.xmppClient.OnError += new System.EventHandler<Matrix.ExceptionEventArgs>(this.xmppClient_OnError);
            this.xmppClient.OnValidateCertificate += new System.EventHandler<Matrix.CertificateEventArgs>(this.xmppClient_OnValidateCertificate);
            this.xmppClient.OnClose += new System.EventHandler<Matrix.EventArgs>(this.xmppClient_OnClose);
            // 
            // mucManager
            // 
            this.mucManager.XmppClient = this.xmppClient;
            // 
            // pubSubManager
            // 
            this.pubSubManager.XmppClient = this.xmppClient;
            this.pubSubManager.OnEvent += new System.EventHandler<Matrix.Xmpp.Client.MessageEventArgs>(this.pubSubManager1_OnEvent);
            // 
            // presenceManager
            // 
            this.presenceManager.XmppClient = this.xmppClient;
            this.presenceManager.OnSubscribe += new System.EventHandler<Matrix.Xmpp.Client.PresenceEventArgs>(this.presenceManager_OnSubscribe);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 502);
            this.Controls.Add(this.cmdVcard);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabGroup);
            this.Controls.Add(this.cmdPubSub);
            this.Controls.Add(this.btnSignOut);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.tabGroup.ResumeLayout(false);
            this.tabContacts.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ctxMenuRoster.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.TabControl tabGroup;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox listEvents;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox rtfDebug;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private Matrix.Xmpp.Client.MucManager mucManager;
        private System.Windows.Forms.TabPage tabContacts;
        private System.Windows.Forms.ListView listContacts;
        private System.Windows.Forms.ImageList ilstStatus;
        private System.Windows.Forms.Button cmdPubSub;
        private Matrix.Xmpp.Client.PubSubManager pubSubManager;
        private System.Windows.Forms.ContextMenuStrip ctxMenuRoster;
        private System.Windows.Forms.ToolStripMenuItem chatToolStripMenuItem;
        private Matrix.Xmpp.Client.PresenceManager presenceManager;
        private System.Windows.Forms.ToolStripMenuItem sendFileToolStripMenuItem;
        private System.Windows.Forms.Button cmdVcard;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem groupChatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiEnterRoom;
        private System.Windows.Forms.ToolStripMenuItem presenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presenceOnlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presenceChatToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem presenceAwayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presenceExtendedAwayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presenceDoNotDisturbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contractsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView listGroup;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListView listBookmarkedRooms;
    }
}

