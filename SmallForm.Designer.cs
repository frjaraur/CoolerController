namespace CoolerController
{
    partial class SmallForm
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
            this.buttonMainForm = new System.Windows.Forms.Button();
            this.labelSmallUITime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonMainForm
            // 
            this.buttonMainForm.BackColor = System.Drawing.SystemColors.Desktop;
            this.buttonMainForm.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonMainForm.Location = new System.Drawing.Point(169, 133);
            this.buttonMainForm.Name = "buttonMainForm";
            this.buttonMainForm.Size = new System.Drawing.Size(75, 23);
            this.buttonMainForm.TabIndex = 0;
            this.buttonMainForm.Text = "MainForm";
            this.buttonMainForm.UseVisualStyleBackColor = false;
            this.buttonMainForm.Click += new System.EventHandler(this.buttonMainForm_Click);
            // 
            // labelSmallUITime
            // 
            this.labelSmallUITime.AutoSize = true;
            this.labelSmallUITime.Location = new System.Drawing.Point(12, 9);
            this.labelSmallUITime.Name = "labelSmallUITime";
            this.labelSmallUITime.Size = new System.Drawing.Size(13, 13);
            this.labelSmallUITime.TabIndex = 1;
            this.labelSmallUITime.Text = "--";
            // 
            // SmallForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 159);
            this.Controls.Add(this.labelSmallUITime);
            this.Controls.Add(this.buttonMainForm);
            this.Name = "SmallForm";
            this.Text = "SmallForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMainForm;
        private System.Windows.Forms.Label labelSmallUITime;
    }
}