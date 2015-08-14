namespace SE_Report.Forms
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.SanityButton = new System.Windows.Forms.RadioButton();
            this.UnitButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.QE0Button = new System.Windows.Forms.RadioButton();
            this.IssuesDBButton = new System.Windows.Forms.RadioButton();
            this.LaunchButton = new System.Windows.Forms.Button();
            this.DevButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.StatsButton = new System.Windows.Forms.RadioButton();
            this.PendingButton = new System.Windows.Forms.RadioButton();
            this.OverviewButton = new System.Windows.Forms.RadioButton();
            this.ExitButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SanityButton
            // 
            this.SanityButton.AutoSize = true;
            this.SanityButton.Location = new System.Drawing.Point(6, 26);
            this.SanityButton.Name = "SanityButton";
            this.SanityButton.Size = new System.Drawing.Size(75, 25);
            this.SanityButton.TabIndex = 1;
            this.SanityButton.Text = "Sanity";
            this.SanityButton.UseVisualStyleBackColor = true;
            // 
            // UnitButton
            // 
            this.UnitButton.AutoSize = true;
            this.UnitButton.Location = new System.Drawing.Point(6, 57);
            this.UnitButton.Name = "UnitButton";
            this.UnitButton.Size = new System.Drawing.Size(59, 25);
            this.UnitButton.TabIndex = 2;
            this.UnitButton.Text = "Unit";
            this.UnitButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.QE0Button);
            this.groupBox1.Controls.Add(this.IssuesDBButton);
            this.groupBox1.Controls.Add(this.SanityButton);
            this.groupBox1.Controls.Add(this.UnitButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 157);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select a test";
            // 
            // QE0Button
            // 
            this.QE0Button.AutoSize = true;
            this.QE0Button.Location = new System.Drawing.Point(6, 119);
            this.QE0Button.Name = "QE0Button";
            this.QE0Button.Size = new System.Drawing.Size(106, 25);
            this.QE0Button.TabIndex = 4;
            this.QE0Button.Text = "QE0 Gate";
            this.QE0Button.UseVisualStyleBackColor = true;
            // 
            // IssuesDBButton
            // 
            this.IssuesDBButton.AutoSize = true;
            this.IssuesDBButton.Location = new System.Drawing.Point(6, 88);
            this.IssuesDBButton.Name = "IssuesDBButton";
            this.IssuesDBButton.Size = new System.Drawing.Size(96, 25);
            this.IssuesDBButton.TabIndex = 3;
            this.IssuesDBButton.Text = "Issues DB";
            this.IssuesDBButton.UseVisualStyleBackColor = true;
            // 
            // LaunchButton
            // 
            this.LaunchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LaunchButton.Image = ((System.Drawing.Image)(resources.GetObject("LaunchButton.Image")));
            this.LaunchButton.Location = new System.Drawing.Point(148, 248);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(75, 78);
            this.LaunchButton.TabIndex = 6;
            this.LaunchButton.UseVisualStyleBackColor = true;
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // DevButton
            // 
            this.DevButton.BackColor = System.Drawing.Color.GhostWhite;
            this.DevButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DevButton.Image = ((System.Drawing.Image)(resources.GetObject("DevButton.Image")));
            this.DevButton.Location = new System.Drawing.Point(286, 248);
            this.DevButton.Name = "DevButton";
            this.DevButton.Size = new System.Drawing.Size(80, 78);
            this.DevButton.TabIndex = 8;
            this.DevButton.UseVisualStyleBackColor = false;
            this.DevButton.Click += new System.EventHandler(this.DevButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(354, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.StatsButton);
            this.groupBox2.Controls.Add(this.PendingButton);
            this.groupBox2.Controls.Add(this.OverviewButton);
            this.groupBox2.Location = new System.Drawing.Point(174, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 157);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Extra features";
            // 
            // StatsButton
            // 
            this.StatsButton.AutoSize = true;
            this.StatsButton.Location = new System.Drawing.Point(17, 88);
            this.StatsButton.Name = "StatsButton";
            this.StatsButton.Size = new System.Drawing.Size(96, 25);
            this.StatsButton.TabIndex = 2;
            this.StatsButton.TabStop = true;
            this.StatsButton.Text = "Statistics";
            this.StatsButton.UseVisualStyleBackColor = true;
            // 
            // PendingButton
            // 
            this.PendingButton.AutoSize = true;
            this.PendingButton.Location = new System.Drawing.Point(17, 26);
            this.PendingButton.Name = "PendingButton";
            this.PendingButton.Size = new System.Drawing.Size(158, 25);
            this.PendingButton.TabIndex = 1;
            this.PendingButton.TabStop = true;
            this.PendingButton.Text = "Pending projects";
            this.PendingButton.UseVisualStyleBackColor = true;
            // 
            // OverviewButton
            // 
            this.OverviewButton.AutoSize = true;
            this.OverviewButton.Location = new System.Drawing.Point(17, 57);
            this.OverviewButton.Name = "OverviewButton";
            this.OverviewButton.Size = new System.Drawing.Size(164, 25);
            this.OverviewButton.TabIndex = 0;
            this.OverviewButton.TabStop = true;
            this.OverviewButton.Text = "Projects overview";
            this.OverviewButton.UseVisualStyleBackColor = true;
            // 
            // ExitButton
            // 
            this.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.Image")));
            this.ExitButton.Location = new System.Drawing.Point(12, 248);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 78);
            this.ExitButton.TabIndex = 7;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(380, 338);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.DevButton);
            this.Controls.Add(this.LaunchButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(396, 377);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button LaunchButton;
        private System.Windows.Forms.Button DevButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.RadioButton SanityButton;
        public System.Windows.Forms.RadioButton UnitButton;
        public System.Windows.Forms.RadioButton IssuesDBButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton OverviewButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.RadioButton PendingButton;
        private System.Windows.Forms.RadioButton StatsButton;
        public System.Windows.Forms.RadioButton QE0Button;
    }
}