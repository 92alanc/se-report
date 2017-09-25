namespace SE_Report.Forms
{
    partial class Checklists
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Checklists));
            this.label1 = new System.Windows.Forms.Label();
            this.afwButton = new System.Windows.Forms.RadioButton();
            this.efuseButton = new System.Windows.Forms.RadioButton();
            this.qfuseButton = new System.Windows.Forms.RadioButton();
            this.CodenameButton = new System.Windows.Forms.RadioButton();
            this.RNDButton = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose the checklist";
            // 
            // afwButton
            // 
            this.afwButton.AutoSize = true;
            this.afwButton.Location = new System.Drawing.Point(38, 111);
            this.afwButton.Name = "afwButton";
            this.afwButton.Size = new System.Drawing.Size(138, 25);
            this.afwButton.TabIndex = 1;
            this.afwButton.Text = "AFW Checklist";
            this.afwButton.UseVisualStyleBackColor = true;
            // 
            // efuseButton
            // 
            this.efuseButton.AutoSize = true;
            this.efuseButton.Location = new System.Drawing.Point(38, 173);
            this.efuseButton.Name = "efuseButton";
            this.efuseButton.Size = new System.Drawing.Size(142, 25);
            this.efuseButton.TabIndex = 2;
            this.efuseButton.Text = "Efuse Checklist";
            this.efuseButton.UseVisualStyleBackColor = true;
            // 
            // qfuseButton
            // 
            this.qfuseButton.AutoSize = true;
            this.qfuseButton.Location = new System.Drawing.Point(38, 142);
            this.qfuseButton.Name = "qfuseButton";
            this.qfuseButton.Size = new System.Drawing.Size(147, 25);
            this.qfuseButton.TabIndex = 3;
            this.qfuseButton.Text = "Qfuse Checklist";
            this.qfuseButton.UseVisualStyleBackColor = true;
            // 
            // CodenameButton
            // 
            this.CodenameButton.AutoSize = true;
            this.CodenameButton.Location = new System.Drawing.Point(38, 235);
            this.CodenameButton.Name = "CodenameButton";
            this.CodenameButton.Size = new System.Drawing.Size(192, 25);
            this.CodenameButton.TabIndex = 4;
            this.CodenameButton.Text = "Codename Checklist";
            this.CodenameButton.UseVisualStyleBackColor = true;
            // 
            // RNDButton
            // 
            this.RNDButton.AutoSize = true;
            this.RNDButton.Location = new System.Drawing.Point(38, 204);
            this.RNDButton.Name = "RNDButton";
            this.RNDButton.Size = new System.Drawing.Size(163, 25);
            this.RNDButton.TabIndex = 5;
            this.RNDButton.Text = "Rnd Self Checklist";
            this.RNDButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(240, 339);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 51);
            this.button1.TabIndex = 6;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BackButton
            // 
            this.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackButton.Image = ((System.Drawing.Image)(resources.GetObject("BackButton.Image")));
            this.BackButton.Location = new System.Drawing.Point(38, 339);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(59, 51);
            this.BackButton.TabIndex = 47;
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // Checklists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(597, 427);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RNDButton);
            this.Controls.Add(this.CodenameButton);
            this.Controls.Add(this.qfuseButton);
            this.Controls.Add(this.efuseButton);
            this.Controls.Add(this.afwButton);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "Checklists";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Checklists";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Checklists_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton afwButton;
        private System.Windows.Forms.RadioButton efuseButton;
        private System.Windows.Forms.RadioButton qfuseButton;
        private System.Windows.Forms.RadioButton CodenameButton;
        private System.Windows.Forms.RadioButton RNDButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BackButton;
    }
}