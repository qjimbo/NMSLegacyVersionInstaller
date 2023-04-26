namespace NMSLegacyVersionInstaller.Steps
{
    partial class FinalSteps
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
            this.pnlConsole = new System.Windows.Forms.Panel();
            this.lblExplain = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblStepTitle
            // 
            this.lblStepTitle.AutoSize = true;
            this.lblStepTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStepTitle.Location = new System.Drawing.Point(5, 5);
            this.lblStepTitle.Name = "lblStepTitle";
            this.lblStepTitle.Size = new System.Drawing.Size(59, 13);
            this.lblStepTitle.TabIndex = 0;
            this.lblStepTitle.Text = "Final Steps";
            // 
            // pnlConsole
            // 
            this.pnlConsole.Location = new System.Drawing.Point(12, 45);
            this.pnlConsole.Name = "pnlConsole";
            this.pnlConsole.Size = new System.Drawing.Size(598, 412);
            this.pnlConsole.TabIndex = 6;
            // 
            // lblExplain
            // 
            this.lblExplain.AutoSize = true;
            this.lblExplain.Location = new System.Drawing.Point(5, 26);
            this.lblExplain.Name = "lblExplain";
            this.lblExplain.Size = new System.Drawing.Size(174, 13);
            this.lblExplain.TabIndex = 5;
            this.lblExplain.Text = "Performing Final Installation Steps...";
            // 
            // FinalSteps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlConsole);
            this.Controls.Add(this.lblExplain);
            this.Controls.Add(this.lblStepTitle);
            this.Name = "FinalSteps";
            this.Size = new System.Drawing.Size(624, 470);
            this.Load += new System.EventHandler(this.FinalSteps_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStepTitle;
        private System.Windows.Forms.Panel pnlConsole;
        private System.Windows.Forms.Label lblExplain;
    }
}
