namespace MiniClient
{
    partial class UcChatTab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.txtChatContents = new DevExpress.XtraEditors.MemoEdit();
            this.listBoxMembers = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtChatContents.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxMembers)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.txtChatContents);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.listBoxMembers);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(699, 354);
            this.splitContainerControl1.SplitterPosition = 544;
            this.splitContainerControl1.TabIndex = 3;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // txtChatContents
            // 
            this.txtChatContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChatContents.Location = new System.Drawing.Point(0, 0);
            this.txtChatContents.Name = "txtChatContents";
            this.txtChatContents.Size = new System.Drawing.Size(544, 354);
            this.txtChatContents.TabIndex = 0;
            // 
            // listBoxMembers
            // 
            this.listBoxMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMembers.Location = new System.Drawing.Point(0, 0);
            this.listBoxMembers.Name = "listBoxMembers";
            this.listBoxMembers.Size = new System.Drawing.Size(150, 354);
            this.listBoxMembers.TabIndex = 1;
            // 
            // UcChatTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "UcChatTab";
            this.Size = new System.Drawing.Size(699, 354);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtChatContents.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxMembers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.MemoEdit txtChatContents;
        private DevExpress.XtraEditors.ListBoxControl listBoxMembers;
    }
}
