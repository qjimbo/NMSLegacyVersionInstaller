namespace NMSLegacyVersionInstaller.Steps
{
    partial class Complete
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
            this.lblStepTitle = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.lblExplain = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblStepTitle
            // 
            this.lblStepTitle.AutoSize = true;
            this.lblStepTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStepTitle.Location = new System.Drawing.Point(5, 5);
            this.lblStepTitle.Name = "lblStepTitle";
            this.lblStepTitle.Size = new System.Drawing.Size(51, 13);
            this.lblStepTitle.TabIndex = 0;
            this.lblStepTitle.Text = "Complete";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(214, 191);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(201, 51);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open Installation Folder";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // lblExplain
            // 
            this.lblExplain.AutoSize = true;
            this.lblExplain.Location = new System.Drawing.Point(5, 24);
            this.lblExplain.Name = "lblExplain";
            this.lblExplain.Size = new System.Drawing.Size(116, 13);
            this.lblExplain.TabIndex = 6;
            this.lblExplain.Text = "Installation is complete.";
            // 
            // Complete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblExplain);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.lblStepTitle);
            this.Name = "Complete";
            this.Size = new System.Drawing.Size(624, 470);
            this.Load += new System.EventHandler(this.Complete_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStepTitle;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblExplain;
    }
}
