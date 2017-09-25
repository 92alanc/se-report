namespace SE_Report.Forms
{
    partial class AFW_Checklist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AFW_Checklist));
            this.label1 = new System.Windows.Forms.Label();
            this.chronosPathBox = new System.Windows.Forms.TextBox();
            this.Start = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(328, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 21);
            this.label1.TabIndex = 19;
            this.label1.Text = "Chronos Path";
            // 
            // chronosPathBox
            // 
            this.chronosPathBox.Location = new System.Drawing.Point(33, 86);
            this.chronosPathBox.Name = "chronosPathBox";
            this.chronosPathBox.Size = new System.Drawing.Size(702, 27);
            this.chronosPathBox.TabIndex = 18;
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(325, 160);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(118, 50);
            this.Start.TabIndex = 16;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click_1);
            // 
            // Back
            // 
            this.Back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Back.BackColor = System.Drawing.Color.Transparent;
            this.Back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Back.Image = ((System.Drawing.Image)(resources.GetObject("Back.Image")));
            this.Back.Location = new System.Drawing.Point(33, 162);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(63, 46);
            this.Back.TabIndex = 17;
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click_1);
            // 
            // AFW_Checklist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(770, 237);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chronosPathBox);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Start);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "AFW_Checklist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AFW Checklist";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AFW_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox chronosPathBox;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button Start;
    }
}