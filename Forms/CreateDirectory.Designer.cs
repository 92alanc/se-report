namespace SE_Report.Forms
{
    partial class CreateDirectory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateDirectory));
            this.createDirectoryButton = new System.Windows.Forms.Button();
            this.chronosPathLabel = new System.Windows.Forms.Label();
            this.chronosPathBox = new System.Windows.Forms.TextBox();
            this.BackButton = new System.Windows.Forms.Button();
            this.sanityDirectory = new System.Windows.Forms.RadioButton();
            this.vp0Directory = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // createDirectoryButton
            // 
            this.createDirectoryButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createDirectoryButton.Location = new System.Drawing.Point(281, 231);
            this.createDirectoryButton.Name = "createDirectoryButton";
            this.createDirectoryButton.Size = new System.Drawing.Size(161, 54);
            this.createDirectoryButton.TabIndex = 0;
            this.createDirectoryButton.Text = "Create Directory";
            this.createDirectoryButton.UseVisualStyleBackColor = true;
            this.createDirectoryButton.Click += new System.EventHandler(this.createDirectoryButton_Click);
            // 
            // chronosPathLabel
            // 
            this.chronosPathLabel.AutoSize = true;
            this.chronosPathLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chronosPathLabel.Location = new System.Drawing.Point(30, 145);
            this.chronosPathLabel.Name = "chronosPathLabel";
            this.chronosPathLabel.Size = new System.Drawing.Size(119, 21);
            this.chronosPathLabel.TabIndex = 1;
            this.chronosPathLabel.Text = "Chronos Path:";
            // 
            // chronosPathBox
            // 
            this.chronosPathBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chronosPathBox.Location = new System.Drawing.Point(155, 145);
            this.chronosPathBox.Name = "chronosPathBox";
            this.chronosPathBox.Size = new System.Drawing.Size(534, 27);
            this.chronosPathBox.TabIndex = 2;
            // 
            // BackButton
            // 
            this.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackButton.Image = ((System.Drawing.Image)(resources.GetObject("BackButton.Image")));
            this.BackButton.Location = new System.Drawing.Point(34, 233);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 54);
            this.BackButton.TabIndex = 46;
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // sanityDirectory
            // 
            this.sanityDirectory.AutoSize = true;
            this.sanityDirectory.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sanityDirectory.Location = new System.Drawing.Point(213, 40);
            this.sanityDirectory.Name = "sanityDirectory";
            this.sanityDirectory.Size = new System.Drawing.Size(75, 25);
            this.sanityDirectory.TabIndex = 47;
            this.sanityDirectory.TabStop = true;
            this.sanityDirectory.Text = "Sanity";
            this.sanityDirectory.UseVisualStyleBackColor = true;
            // 
            // vp0Directory
            // 
            this.vp0Directory.AutoSize = true;
            this.vp0Directory.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vp0Directory.Location = new System.Drawing.Point(357, 40);
            this.vp0Directory.Name = "vp0Directory";
            this.vp0Directory.Size = new System.Drawing.Size(103, 25);
            this.vp0Directory.TabIndex = 48;
            this.vp0Directory.TabStop = true;
            this.vp0Directory.Text = "VP0 Gate";
            this.vp0Directory.UseVisualStyleBackColor = true;
            // 
            // CreateDirectory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(701, 310);
            this.Controls.Add(this.vp0Directory);
            this.Controls.Add(this.sanityDirectory);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.chronosPathBox);
            this.Controls.Add(this.chronosPathLabel);
            this.Controls.Add(this.createDirectoryButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CreateDirectory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Directory";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CreateDirectory_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createDirectoryButton;
        private System.Windows.Forms.Label chronosPathLabel;
        private System.Windows.Forms.TextBox chronosPathBox;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.RadioButton sanityDirectory;
        private System.Windows.Forms.RadioButton vp0Directory;
    }
}