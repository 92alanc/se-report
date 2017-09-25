namespace SE_Report.Forms
{
    partial class QE0
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QE0));
            this.PathGroup = new System.Windows.Forms.GroupBox();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.GPRIButton = new System.Windows.Forms.Button();
            this.LinksButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.PassButton = new System.Windows.Forms.Button();
            this.FailButton = new System.Windows.Forms.Button();
            this.ResultsGroup = new System.Windows.Forms.GroupBox();
            this.PathGroup.SuspendLayout();
            this.ResultsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // PathGroup
            // 
            this.PathGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathGroup.Controls.Add(this.PathBox);
            this.PathGroup.Location = new System.Drawing.Point(12, 12);
            this.PathGroup.Name = "PathGroup";
            this.PathGroup.Size = new System.Drawing.Size(919, 72);
            this.PathGroup.TabIndex = 96;
            this.PathGroup.TabStop = false;
            this.PathGroup.Text = "Chronos path";
            // 
            // PathBox
            // 
            this.PathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathBox.BackColor = System.Drawing.Color.White;
            this.PathBox.Location = new System.Drawing.Point(10, 26);
            this.PathBox.Name = "PathBox";
            this.PathBox.Size = new System.Drawing.Size(893, 27);
            this.PathBox.TabIndex = 0;
            // 
            // GPRIButton
            // 
            this.GPRIButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.GPRIButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GPRIButton.Location = new System.Drawing.Point(166, 210);
            this.GPRIButton.Name = "GPRIButton";
            this.GPRIButton.Size = new System.Drawing.Size(98, 59);
            this.GPRIButton.TabIndex = 102;
            this.GPRIButton.Text = "GPRI";
            this.GPRIButton.UseVisualStyleBackColor = true;
            this.GPRIButton.Click += new System.EventHandler(this.GPRIButton_Click);
            // 
            // LinksButton
            // 
            this.LinksButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LinksButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LinksButton.Image = ((System.Drawing.Image)(resources.GetObject("LinksButton.Image")));
            this.LinksButton.Location = new System.Drawing.Point(855, 209);
            this.LinksButton.Name = "LinksButton";
            this.LinksButton.Size = new System.Drawing.Size(76, 61);
            this.LinksButton.TabIndex = 101;
            this.LinksButton.UseVisualStyleBackColor = true;
            this.LinksButton.Click += new System.EventHandler(this.LinksButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackButton.Image = ((System.Drawing.Image)(resources.GetObject("BackButton.Image")));
            this.BackButton.Location = new System.Drawing.Point(12, 210);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 59);
            this.BackButton.TabIndex = 100;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // PassButton
            // 
            this.PassButton.BackColor = System.Drawing.Color.Lime;
            this.PassButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PassButton.Location = new System.Drawing.Point(6, 41);
            this.PassButton.Name = "PassButton";
            this.PassButton.Size = new System.Drawing.Size(98, 65);
            this.PassButton.TabIndex = 103;
            this.PassButton.Text = "PASSED";
            this.PassButton.UseVisualStyleBackColor = false;
            this.PassButton.Click += new System.EventHandler(this.PassButton_Click);
            // 
            // FailButton
            // 
            this.FailButton.BackColor = System.Drawing.Color.Red;
            this.FailButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FailButton.ForeColor = System.Drawing.Color.White;
            this.FailButton.Location = new System.Drawing.Point(110, 41);
            this.FailButton.Name = "FailButton";
            this.FailButton.Size = new System.Drawing.Size(98, 65);
            this.FailButton.TabIndex = 104;
            this.FailButton.Text = "FAILED";
            this.FailButton.UseVisualStyleBackColor = false;
            this.FailButton.Click += new System.EventHandler(this.FailButton_Click);
            // 
            // ResultsGroup
            // 
            this.ResultsGroup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ResultsGroup.Controls.Add(this.PassButton);
            this.ResultsGroup.Controls.Add(this.FailButton);
            this.ResultsGroup.Location = new System.Drawing.Point(361, 107);
            this.ResultsGroup.Name = "ResultsGroup";
            this.ResultsGroup.Size = new System.Drawing.Size(217, 114);
            this.ResultsGroup.TabIndex = 105;
            this.ResultsGroup.TabStop = false;
            this.ResultsGroup.Text = "Test result";
            // 
            // QE0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 281);
            this.Controls.Add(this.ResultsGroup);
            this.Controls.Add(this.GPRIButton);
            this.Controls.Add(this.LinksButton);
            this.Controls.Add(this.PathGroup);
            this.Controls.Add(this.BackButton);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "QE0";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QE0 Gate";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.QE0_FormClosed);
            this.PathGroup.ResumeLayout(false);
            this.PathGroup.PerformLayout();
            this.ResultsGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox PathGroup;
        private System.Windows.Forms.TextBox PathBox;
        private System.Windows.Forms.Button GPRIButton;
        private System.Windows.Forms.Button LinksButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button PassButton;
        private System.Windows.Forms.Button FailButton;
        private System.Windows.Forms.GroupBox ResultsGroup;
    }
}