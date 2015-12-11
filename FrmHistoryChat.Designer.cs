namespace MiniClient
{
    partial class FrmHistoryChat
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
            this.dgvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDateDetail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPIC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dgcHistoryChat = new DevExpress.XtraGrid.GridControl();
            this.dgvHistoryChat = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgcHistoryChat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryChat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDetail
            // 
            this.dgvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDateDetail,
            this.colPIC,
            this.colChat});
            this.dgvDetail.GridControl = this.dgcHistoryChat;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.OptionsCustomization.AllowColumnMoving = false;
            this.dgvDetail.OptionsView.AllowCellMerge = true;
            this.dgvDetail.OptionsView.ShowColumnHeaders = false;
            // 
            // colDateDetail
            // 
            this.colDateDetail.DisplayFormat.FormatString = "hh:mm:ss";
            this.colDateDetail.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDateDetail.FieldName = "DateDetail";
            this.colDateDetail.Name = "colDateDetail";
            this.colDateDetail.Visible = true;
            this.colDateDetail.VisibleIndex = 2;
            // 
            // colPIC
            // 
            this.colPIC.FieldName = "PIC";
            this.colPIC.Name = "colPIC";
            this.colPIC.Visible = true;
            this.colPIC.VisibleIndex = 0;
            // 
            // colChat
            // 
            this.colChat.FieldName = "Chat";
            this.colChat.Name = "colChat";
            this.colChat.Visible = true;
            this.colChat.VisibleIndex = 1;
            // 
            // dgcHistoryChat
            // 
            this.dgcHistoryChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcHistoryChat.Location = new System.Drawing.Point(0, 0);
            this.dgcHistoryChat.MainView = this.dgvHistoryChat;
            this.dgcHistoryChat.Name = "dgcHistoryChat";
            this.dgcHistoryChat.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.dgcHistoryChat.Size = new System.Drawing.Size(482, 261);
            this.dgcHistoryChat.TabIndex = 0;
            this.dgcHistoryChat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvHistoryChat,
            this.dgvDetail});
            // 
            // dgvHistoryChat
            // 
            this.dgvHistoryChat.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDate});
            this.dgvHistoryChat.GridControl = this.dgcHistoryChat;
            this.dgvHistoryChat.Name = "dgvHistoryChat";
            this.dgvHistoryChat.OptionsBehavior.AutoSelectAllInEditor = false;
            this.dgvHistoryChat.OptionsBehavior.Editable = false;
            this.dgvHistoryChat.OptionsCustomization.AllowColumnMoving = false;
            this.dgvHistoryChat.OptionsCustomization.AllowFilter = false;
            this.dgvHistoryChat.OptionsMenu.EnableColumnMenu = false;
            this.dgvHistoryChat.OptionsView.AllowCellMerge = true;
            // 
            // colDate
            // 
            this.colDate.Caption = "Date";
            this.colDate.DisplayFormat.FormatString = "D";
            this.colDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 0;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // FrmHistoryChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 261);
            this.Controls.Add(this.dgcHistoryChat);
            this.Name = "FrmHistoryChat";
            this.Text = "FrmHistoryChat";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgcHistoryChat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryChat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcHistoryChat;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvHistoryChat;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colDateDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colPIC;
        private DevExpress.XtraGrid.Columns.GridColumn colChat;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
    }
}