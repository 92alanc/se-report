namespace SE_Report.Forms
{
    partial class Links
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Links));
            this.ModelsLink = new System.Windows.Forms.LinkLabel();
            this.CalendarLink = new System.Windows.Forms.LinkLabel();
            this.TestSetsLink = new System.Windows.Forms.LinkLabel();
            this.MCCMNCLink = new System.Windows.Forms.LinkLabel();
            this.NTCodeLink = new System.Windows.Forms.LinkLabel();
            this.TDLink = new System.Windows.Forms.LinkLabel();
            this.MLMLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // ModelsLink
            // 
            this.ModelsLink.AutoSize = true;
            this.ModelsLink.Location = new System.Drawing.Point(12, 9);
            this.ModelsLink.Name = "ModelsLink";
            this.ModelsLink.Size = new System.Drawing.Size(503, 21);
            this.ModelsLink.TabIndex = 1;
            this.ModelsLink.TabStop = true;
            this.ModelsLink.Text = "Models (for UAP/UAS, embedded games and frequency bands)";
            this.ModelsLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ModelsLink_LinkClicked);
            // 
            // CalendarLink
            // 
            this.CalendarLink.AutoSize = true;
            this.CalendarLink.Location = new System.Drawing.Point(12, 43);
            this.CalendarLink.Name = "CalendarLink";
            this.CalendarLink.Size = new System.Drawing.Size(127, 21);
            this.CalendarLink.TabIndex = 2;
            this.CalendarLink.TabStop = true;
            this.CalendarLink.Text = "RBS (Calendar)";
            this.CalendarLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CalendarLink_LinkClicked);
            // 
            // TestSetsLink
            // 
            this.TestSetsLink.AutoSize = true;
            this.TestSetsLink.Location = new System.Drawing.Point(12, 78);
            this.TestSetsLink.Name = "TestSetsLink";
            this.TestSetsLink.Size = new System.Drawing.Size(119, 21);
            this.TestSetsLink.TabIndex = 3;
            this.TestSetsLink.TabStop = true;
            this.TestSetsLink.Text = "RBS (Test Sets)";
            this.TestSetsLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.TestSetsLink_LinkClicked);
            // 
            // MCCMNCLink
            // 
            this.MCCMNCLink.AutoSize = true;
            this.MCCMNCLink.Location = new System.Drawing.Point(12, 150);
            this.MCCMNCLink.Name = "MCCMNCLink";
            this.MCCMNCLink.Size = new System.Drawing.Size(121, 21);
            this.MCCMNCLink.TabIndex = 5;
            this.MCCMNCLink.TabStop = true;
            this.MCCMNCLink.Text = "MCC/MNC list";
            this.MCCMNCLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.MCCMNCLink_LinkClicked);
            // 
            // NTCodeLink
            // 
            this.NTCodeLink.AutoSize = true;
            this.NTCodeLink.Location = new System.Drawing.Point(12, 114);
            this.NTCodeLink.Name = "NTCodeLink";
            this.NTCodeLink.Size = new System.Drawing.Size(98, 21);
            this.NTCodeLink.TabIndex = 6;
            this.NTCodeLink.TabStop = true;
            this.NTCodeLink.Text = "NT code list";
            this.NTCodeLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.NTCodeLink_LinkClicked);
            // 
            // TDLink
            // 
            this.TDLink.AutoSize = true;
            this.TDLink.Location = new System.Drawing.Point(12, 183);
            this.TDLink.Name = "TDLink";
            this.TDLink.Size = new System.Drawing.Size(30, 21);
            this.TDLink.TabIndex = 16;
            this.TDLink.TabStop = true;
            this.TDLink.Text = "TD";
            this.TDLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.TDLink_LinkClicked);
            // 
            // MLMLink
            // 
            this.MLMLink.AutoSize = true;
            this.MLMLink.Location = new System.Drawing.Point(12, 217);
            this.MLMLink.Name = "MLMLink";
            this.MLMLink.Size = new System.Drawing.Size(47, 21);
            this.MLMLink.TabIndex = 19;
            this.MLMLink.TabStop = true;
            this.MLMLink.Text = "MLM";
            this.MLMLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.MLMLink_LinkClicked);
            // 
            // Links
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 254);
            this.Controls.Add(this.MLMLink);
            this.Controls.Add(this.TDLink);
            this.Controls.Add(this.NTCodeLink);
            this.Controls.Add(this.MCCMNCLink);
            this.Controls.Add(this.TestSetsLink);
            this.Controls.Add(this.CalendarLink);
            this.Controls.Add(this.ModelsLink);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "Links";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Useful links";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel ModelsLink;
        private System.Windows.Forms.LinkLabel CalendarLink;
        private System.Windows.Forms.LinkLabel TestSetsLink;
        private System.Windows.Forms.LinkLabel MCCMNCLink;
        private System.Windows.Forms.LinkLabel NTCodeLink;
        private System.Windows.Forms.LinkLabel TDLink;
        private System.Windows.Forms.LinkLabel MLMLink;
    }
}