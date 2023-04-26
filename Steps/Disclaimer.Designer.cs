namespace NMSLegacyVersionInstaller.Steps
{
    partial class Disclaimer
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
            this.txtDisclaimer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblStepTitle
            // 
            this.lblStepTitle.AutoSize = true;
            this.lblStepTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStepTitle.Location = new System.Drawing.Point(5, 5);
            this.lblStepTitle.Name = "lblStepTitle";
            this.lblStepTitle.Size = new System.Drawing.Size(55, 13);
            this.lblStepTitle.TabIndex = 0;
            this.lblStepTitle.Text = "Disclaimer";
            // 
            // txtDisclaimer
            // 
            this.txtDisclaimer.Location = new System.Drawing.Point(8, 25);
            this.txtDisclaimer.Multiline = true;
            this.txtDisclaimer.Name = "txtDisclaimer";
            this.txtDisclaimer.ReadOnly = true;
            this.txtDisclaimer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDisclaimer.Size = new System.Drawing.Size(609, 442);
            this.txtDisclaimer.TabIndex = 1;
            // 
            // Disclaimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtDisclaimer);
            this.Controls.Add(this.lblStepTitle);
            this.Name = "Disclaimer";
            this.Size = new System.Drawing.Size(624, 470);
            this.Load += new System.EventHandler(this.Disclaimer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStepTitle;
        private System.Windows.Forms.TextBox txtDisclaimer;
    }
}
