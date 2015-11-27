namespace MiniClient
{
    partial class FrmPubSub
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmdInstantNode = new System.Windows.Forms.Button();
            this.cmdCreate = new System.Windows.Forms.Button();
            this.txtNode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboService = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.treeNodes = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNode = new System.Windows.Forms.Label();
            this.lblJid = new System.Windows.Forms.Label();
            this.contextMenuStripNodes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subscribeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.publishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStripNodes.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cmdInstantNode);
            this.splitContainer1.Panel1.Controls.Add(this.cmdCreate);
            this.splitContainer1.Panel1.Controls.Add(this.txtNode);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.cboService);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(717, 274);
            this.splitContainer1.SplitterDistance = 360;
            this.splitContainer1.TabIndex = 6;
            // 
            // cmdInstantNode
            // 
            this.cmdInstantNode.Location = new System.Drawing.Point(118, 95);
            this.cmdInstantNode.Name = "cmdInstantNode";
            this.cmdInstantNode.Size = new System.Drawing.Size(130, 24);
            this.cmdInstantNode.TabIndex = 10;
            this.cmdInstantNode.Text = "create instant node";
            this.cmdInstantNode.UseVisualStyleBackColor = true;
            this.cmdInstantNode.Click += new System.EventHandler(this.cmdInstantNode_Click);
            // 
            // cmdCreate
            // 
            this.cmdCreate.Location = new System.Drawing.Point(118, 65);
            this.cmdCreate.Name = "cmdCreate";
            this.cmdCreate.Size = new System.Drawing.Size(130, 24);
            this.cmdCreate.TabIndex = 9;
            this.cmdCreate.Text = "create node";
            this.cmdCreate.UseVisualStyleBackColor = true;
            this.cmdCreate.Click += new System.EventHandler(this.cmdCreate_Click);
            // 
            // txtNode
            // 
            this.txtNode.Location = new System.Drawing.Point(118, 39);
            this.txtNode.Name = "txtNode";
            this.txtNode.Size = new System.Drawing.Size(227, 20);
            this.txtNode.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Node:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "PubSub Services:\r\n";
            // 
            // cboService
            // 
            this.cboService.FormattingEnabled = true;
            this.cboService.Location = new System.Drawing.Point(118, 3);
            this.cboService.Name = "cboService";
            this.cboService.Size = new System.Drawing.Size(228, 21);
            this.cboService.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblName, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.treeNodes, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblNode, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblJid, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(353, 274);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Name:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(83, 254);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 13);
            this.lblName.TabIndex = 12;
            this.lblName.Text = "lblName";
            // 
            // treeNodes
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.treeNodes, 2);
            this.treeNodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeNodes.Location = new System.Drawing.Point(3, 3);
            this.treeNodes.Name = "treeNodes";
            this.treeNodes.Size = new System.Drawing.Size(347, 208);
            this.treeNodes.TabIndex = 7;
            this.treeNodes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeNodes_AfterSelect);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Node:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Jid:";
            // 
            // lblNode
            // 
            this.lblNode.AutoSize = true;
            this.lblNode.Location = new System.Drawing.Point(83, 214);
            this.lblNode.Name = "lblNode";
            this.lblNode.Size = new System.Drawing.Size(43, 13);
            this.lblNode.TabIndex = 10;
            this.lblNode.Text = "lblNode";
            // 
            // lblJid
            // 
            this.lblJid.AutoSize = true;
            this.lblJid.Location = new System.Drawing.Point(83, 234);
            this.lblJid.Name = "lblJid";
            this.lblJid.Size = new System.Drawing.Size(30, 13);
            this.lblJid.TabIndex = 11;
            this.lblJid.Text = "lblJid";
            // 
            // contextMenuStripNodes
            // 
            this.contextMenuStripNodes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.subscribeToolStripMenuItem,
            this.publishToolStripMenuItem});
            this.contextMenuStripNodes.Name = "contextMenuStripNodes";
            this.contextMenuStripNodes.Size = new System.Drawing.Size(153, 92);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // subscribeToolStripMenuItem
            // 
            this.subscribeToolStripMenuItem.Name = "subscribeToolStripMenuItem";
            this.subscribeToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.subscribeToolStripMenuItem.Text = "Subscribe";
            this.subscribeToolStripMenuItem.Click += new System.EventHandler(this.subscribeToolStripMenuItem_Click);
            // 
            // publishToolStripMenuItem
            // 
            this.publishToolStripMenuItem.Name = "publishToolStripMenuItem";
            this.publishToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.publishToolStripMenuItem.Text = "Publish";
            this.publishToolStripMenuItem.Click += new System.EventHandler(this.publishToolStripMenuItem_Click);
            // 
            // frmPubSub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 274);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmPubSub";
            this.Text = "create PubSub node";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.contextMenuStripNodes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button cmdCreate;
        private System.Windows.Forms.TextBox txtNode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboService;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView treeNodes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNode;
        private System.Windows.Forms.Label lblJid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNodes;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button cmdInstantNode;
        private System.Windows.Forms.ToolStripMenuItem subscribeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem publishToolStripMenuItem;

    }
}