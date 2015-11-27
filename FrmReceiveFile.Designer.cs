namespace MiniClient
{
    partial class FrmReceiveFile
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblFileName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdAbort = new System.Windows.Forms.Button();
            this.lblDescriptionSize = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.cmdRefuse = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cmdSaveAs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(13, 103);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(383, 23);
            this.progressBar.TabIndex = 0;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.Location = new System.Drawing.Point(9, 20);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(57, 13);
            this.lblFileName.TabIndex = 2;
            this.lblFileName.Text = "Filename";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Description:";
            // 
            // cmdAbort
            // 
            this.cmdAbort.Enabled = false;
            this.cmdAbort.Location = new System.Drawing.Point(321, 153);
            this.cmdAbort.Name = "cmdAbort";
            this.cmdAbort.Size = new System.Drawing.Size(75, 23);
            this.cmdAbort.TabIndex = 6;
            this.cmdAbort.Text = "Abort";
            this.cmdAbort.UseVisualStyleBackColor = true;
            this.cmdAbort.Click += new System.EventHandler(this.cmdAbort_Click);
            // 
            // lblDescriptionSize
            // 
            this.lblDescriptionSize.AutoSize = true;
            this.lblDescriptionSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptionSize.Location = new System.Drawing.Point(10, 48);
            this.lblDescriptionSize.Name = "lblDescriptionSize";
            this.lblDescriptionSize.Size = new System.Drawing.Size(35, 13);
            this.lblDescriptionSize.TabIndex = 7;
            this.lblDescriptionSize.Text = "Size:";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.Location = new System.Drawing.Point(91, 48);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(41, 13);
            this.lblSize.TabIndex = 8;
            this.lblSize.Text = "0 bytes";
            // 
            // cmdAccept
            // 
            this.cmdAccept.Location = new System.Drawing.Point(159, 153);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(75, 23);
            this.cmdAccept.TabIndex = 9;
            this.cmdAccept.Text = "Accept";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // cmdRefuse
            // 
            this.cmdRefuse.Location = new System.Drawing.Point(240, 153);
            this.cmdRefuse.Name = "cmdRefuse";
            this.cmdRefuse.Size = new System.Drawing.Size(75, 23);
            this.cmdRefuse.TabIndex = 10;
            this.cmdRefuse.Text = "Refuse";
            this.cmdRefuse.UseVisualStyleBackColor = true;
            this.cmdRefuse.Click += new System.EventHandler(this.cmdRefuse_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(91, 75);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(41, 13);
            this.lblDescription.TabIndex = 11;
            this.lblDescription.Text = "0 bytes";
            // 
            // cmdSaveAs
            // 
            this.cmdSaveAs.Location = new System.Drawing.Point(321, 20);
            this.cmdSaveAs.Name = "cmdSaveAs";
            this.cmdSaveAs.Size = new System.Drawing.Size(75, 23);
            this.cmdSaveAs.TabIndex = 12;
            this.cmdSaveAs.Text = "save as ...";
            this.cmdSaveAs.UseVisualStyleBackColor = true;
            this.cmdSaveAs.Click += new System.EventHandler(this.cmdSaveAs_Click);
            // 
            // FrmReceiveFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 188);
            this.Controls.Add(this.cmdSaveAs);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.cmdRefuse);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblDescriptionSize);
            this.Controls.Add(this.cmdAbort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.progressBar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReceiveFile";
            this.Text = "FrmReceiveFile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdAbort;
        private System.Windows.Forms.Label lblDescriptionSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Button cmdAccept;
        private System.Windows.Forms.Button cmdRefuse;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button cmdSaveAs;
    }
}