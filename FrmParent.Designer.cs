namespace MiniClient
{
    partial class FrmParent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmParent));
            this.tabForms = new System.Windows.Forms.TabControl();
            this.loading = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.loading)).BeginInit();
            this.SuspendLayout();
            // 
            // tabForms
            // 
            this.tabForms.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabForms.Location = new System.Drawing.Point(0, 0);
            this.tabForms.Name = "tabForms";
            this.tabForms.SelectedIndex = 0;
            this.tabForms.Size = new System.Drawing.Size(284, 24);
            this.tabForms.TabIndex = 1;
            this.tabForms.Visible = false;
            this.tabForms.SelectedIndexChanged += new System.EventHandler(this.tabForms_SelectedIndexChanged);
            // 
            // loading
            // 
            this.loading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loading.BackColor = System.Drawing.Color.Transparent;
            this.loading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.loading.Image = global::MiniClient.Properties.Resources.bar1;
            this.loading.Location = new System.Drawing.Point(19, 117);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(253, 18);
            this.loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loading.TabIndex = 3;
            this.loading.TabStop = false;
            // 
            // FrmParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.loading);
            this.Controls.Add(this.tabForms);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FrmParent";
            this.Text = "IChat";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MdiChildActivate += new System.EventHandler(this.FrmParent_MdiChildActivate);
            ((System.ComponentModel.ISupportInitialize)(this.loading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabForms;
        public System.Windows.Forms.PictureBox loading;

    }
}