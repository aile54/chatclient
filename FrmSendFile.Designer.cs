namespace MiniClient
{
    partial class FrmSendFile
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
            this.cmdSend = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.cmdChooseFile = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cmdAbort = new System.Windows.Forms.Button();
            this.lblDescriptionSize = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // cmdSend
            // 
            this.cmdSend.Enabled = false;
            this.cmdSend.Location = new System.Drawing.Point(320, 145);
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.Size = new System.Drawing.Size(75, 23);
            this.cmdSend.TabIndex = 1;
            this.cmdSend.Text = "Send";
            this.cmdSend.UseVisualStyleBackColor = true;
            this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.Location = new System.Drawing.Point(9, 20);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(311, 13);
            this.lblFileName.TabIndex = 2;
            this.lblFileName.Text = "press the \"choose File\" button to select a file to send";
            // 
            // cmdChooseFile
            // 
            this.cmdChooseFile.Location = new System.Drawing.Point(13, 145);
            this.cmdChooseFile.Name = "cmdChooseFile";
            this.cmdChooseFile.Size = new System.Drawing.Size(75, 23);
            this.cmdChooseFile.TabIndex = 3;
            this.cmdChooseFile.Text = "choose file";
            this.cmdChooseFile.UseVisualStyleBackColor = true;
            this.cmdChooseFile.Click += new System.EventHandler(this.cmdChooseFile_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(91, 72);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(304, 20);
            this.txtDescription.TabIndex = 4;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(10, 75);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(75, 13);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Description:";
            // 
            // cmdAbort
            // 
            this.cmdAbort.Enabled = false;
            this.cmdAbort.Location = new System.Drawing.Point(239, 145);
            this.cmdAbort.Name = "cmdAbort";
            this.cmdAbort.Size = new System.Drawing.Size(75, 23);
            this.cmdAbort.TabIndex = 6;
            this.cmdAbort.Text = "Abort";
            this.cmdAbort.UseVisualStyleBackColor = true;
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
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 107);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(383, 23);
            this.progressBar.TabIndex = 9;
            // 
            // FrmSendFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 188);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblDescriptionSize);
            this.Controls.Add(this.cmdAbort);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.cmdChooseFile);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.cmdSend);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSendFile";
            this.Text = "FrmSendFile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private System.Windows.Forms.Button cmdSend;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button cmdChooseFile;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button cmdAbort;
        private System.Windows.Forms.Label lblDescriptionSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}