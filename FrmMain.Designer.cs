﻿namespace MiniClient
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabContacts = new System.Windows.Forms.TabPage();
            this.listContacts = new System.Windows.Forms.ListView();
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
            this.vCardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdVcard = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.presenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presenceOnlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presenceChatToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.presenceAwayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presenceExtendedAwayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presenceDoNotDisturbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEnterRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEnterRoomTest = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mucManager = new Matrix.Xmpp.Client.MucManager();
            this.pubSubManager = new Matrix.Xmpp.Client.PubSubManager();
            this.presenceManager = new Matrix.Xmpp.Client.PresenceManager();
            this.tabControl1.SuspendLayout();
            this.tabContacts.SuspendLayout();
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
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabContacts);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(10, 56);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(505, 421);
            this.tabControl1.TabIndex = 4;
            // 
            // tabContacts
            // 
            this.tabContacts.Controls.Add(this.listContacts);
            this.tabContacts.Location = new System.Drawing.Point(4, 22);
            this.tabContacts.Name = "tabContacts";
            this.tabContacts.Padding = new System.Windows.Forms.Padding(3);
            this.tabContacts.Size = new System.Drawing.Size(497, 395);
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
            this.listContacts.Size = new System.Drawing.Size(491, 389);
            this.listContacts.TabIndex = 0;
            this.listContacts.UseCompatibleStateImageBehavior = false;
            this.listContacts.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listContacts_MouseUp);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listEvents);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(469, 371);
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
            this.listEvents.Size = new System.Drawing.Size(463, 365);
            this.listEvents.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rtfDebug);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(469, 371);
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
            this.rtfDebug.Size = new System.Drawing.Size(463, 365);
            this.rtfDebug.TabIndex = 0;
            this.rtfDebug.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 480);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(530, 22);
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
            this.vCardToolStripMenuItem});
            this.ctxMenuRoster.Name = "ctxMenuRoster";
            this.ctxMenuRoster.Size = new System.Drawing.Size(121, 70);
            // 
            // chatToolStripMenuItem
            // 
            this.chatToolStripMenuItem.Name = "chatToolStripMenuItem";
            this.chatToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.chatToolStripMenuItem.Text = "chat";
            this.chatToolStripMenuItem.Click += new System.EventHandler(this.chatToolStripMenuItem_Click);
            // 
            // sendFileToolStripMenuItem
            // 
            this.sendFileToolStripMenuItem.Name = "sendFileToolStripMenuItem";
            this.sendFileToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.sendFileToolStripMenuItem.Text = "send File";
            // 
            // vCardToolStripMenuItem
            // 
            this.vCardToolStripMenuItem.Name = "vCardToolStripMenuItem";
            this.vCardToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.vCardToolStripMenuItem.Text = "VCard";
            this.vCardToolStripMenuItem.Click += new System.EventHandler(this.vCardToolStripMenuItem_Click);
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
            this.groupChatToolStripMenuItem,
            this.settingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(530, 24);
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
            // groupChatToolStripMenuItem
            // 
            this.groupChatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEnterRoom,
            this.tsmiEnterRoomTest});
            this.groupChatToolStripMenuItem.Name = "groupChatToolStripMenuItem";
            this.groupChatToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.groupChatToolStripMenuItem.Text = "Group Chat";
            // 
            // tsmiEnterRoom
            // 
            this.tsmiEnterRoom.Name = "tsmiEnterRoom";
            this.tsmiEnterRoom.Size = new System.Drawing.Size(337, 22);
            this.tsmiEnterRoom.Text = "Enter or create chat room";
            this.tsmiEnterRoom.Click += new System.EventHandler(this.tsmiEnterRoom_Click);
            // 
            // tsmiEnterRoomTest
            // 
            this.tsmiEnterRoomTest.Name = "tsmiEnterRoomTest";
            this.tsmiEnterRoomTest.Size = new System.Drawing.Size(337, 22);
            this.tsmiEnterRoomTest.Text = "Enter chat room test@conference.ag-software.net";
            this.tsmiEnterRoomTest.Click += new System.EventHandler(this.tsmiEnterRoomTest_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetDatabaseToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.settingToolStripMenuItem.Text = "Setting";
            // 
            // resetDatabaseToolStripMenuItem
            // 
            this.resetDatabaseToolStripMenuItem.Name = "resetDatabaseToolStripMenuItem";
            this.resetDatabaseToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.resetDatabaseToolStripMenuItem.Text = "Reset Database";
            this.resetDatabaseToolStripMenuItem.Click += new System.EventHandler(this.resetDatabaseToolStripMenuItem_Click);
            // 
            // mucManager
            // 
            this.mucManager.XmppClient = null;
            // 
            // pubSubManager
            // 
            this.pubSubManager.XmppClient = null;
            this.pubSubManager.OnEvent += new System.EventHandler<Matrix.Xmpp.Client.MessageEventArgs>(this.pubSubManager1_OnEvent);
            // 
            // presenceManager
            // 
            this.presenceManager.XmppClient = null;
            this.presenceManager.OnSubscribe += new System.EventHandler<Matrix.Xmpp.Client.PresenceEventArgs>(this.presenceManager_OnSubscribe);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 502);
            this.Controls.Add(this.cmdVcard);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdPubSub);
            this.Controls.Add(this.btnSignOut);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xmpp Client Chat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabContacts.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl tabControl1;
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
        private System.Windows.Forms.ToolStripMenuItem vCardToolStripMenuItem;
        private System.Windows.Forms.Button cmdVcard;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem groupChatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiEnterRoom;
        private System.Windows.Forms.ToolStripMenuItem tsmiEnterRoomTest;
        private System.Windows.Forms.ToolStripMenuItem presenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presenceOnlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presenceChatToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem presenceAwayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presenceExtendedAwayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presenceDoNotDisturbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetDatabaseToolStripMenuItem;
    }
}

