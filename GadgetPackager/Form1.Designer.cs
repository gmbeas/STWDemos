namespace GadgetPackager
{
    partial class Form1
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
            this.TextBoxLog = new System.Windows.Forms.TextBox();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.ButtonReRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBoxLog
            // 
            this.TextBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxLog.BackColor = System.Drawing.Color.White;
            this.TextBoxLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxLog.Location = new System.Drawing.Point(12, 12);
            this.TextBoxLog.MaxLength = 0;
            this.TextBoxLog.Multiline = true;
            this.TextBoxLog.Name = "TextBoxLog";
            this.TextBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBoxLog.Size = new System.Drawing.Size(564, 216);
            this.TextBoxLog.TabIndex = 1;
            this.TextBoxLog.WordWrap = false;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.Location = new System.Drawing.Point(12, 234);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(483, 23);
            this.ProgressBar.TabIndex = 2;
            // 
            // ButtonReRun
            // 
            this.ButtonReRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonReRun.Enabled = false;
            this.ButtonReRun.Location = new System.Drawing.Point(501, 234);
            this.ButtonReRun.Name = "ButtonReRun";
            this.ButtonReRun.Size = new System.Drawing.Size(75, 23);
            this.ButtonReRun.TabIndex = 3;
            this.ButtonReRun.Text = "ReRun";
            this.ButtonReRun.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 269);
            this.Controls.Add(this.ButtonReRun);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.TextBoxLog);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox TextBoxLog;
        internal System.Windows.Forms.ProgressBar ProgressBar;
        internal System.Windows.Forms.Button ButtonReRun;
    }
}

