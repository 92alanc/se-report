namespace SE_Report.Forms
{
    partial class AddTests
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTests));
            this.PathBox = new System.Windows.Forms.TextBox();
            this.chronosPathLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sameBoardBtn = new System.Windows.Forms.RadioButton();
            this.newBoardBtn = new System.Windows.Forms.RadioButton();
            this.cupssBtn = new System.Windows.Forms.RadioButton();
            this.addTestsButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PathBox
            // 
            this.PathBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PathBox.Location = new System.Drawing.Point(191, 42);
            this.PathBox.Name = "PathBox";
            this.PathBox.Size = new System.Drawing.Size(534, 27);
            this.PathBox.TabIndex = 4;
            // 
            // chronosPathLabel
            // 
            this.chronosPathLabel.AutoSize = true;
            this.chronosPathLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chronosPathLabel.Location = new System.Drawing.Point(66, 42);
            this.chronosPathLabel.Name = "chronosPathLabel";
            this.chronosPathLabel.Size = new System.Drawing.Size(119, 21);
            this.chronosPathLabel.TabIndex = 3;
            this.chronosPathLabel.Text = "Chronos Path:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select the recycle type:";
            // 
            // sameBoardBtn
            // 
            this.sameBoardBtn.AutoSize = true;
            this.sameBoardBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sameBoardBtn.Location = new System.Drawing.Point(70, 185);
            this.sameBoardBtn.Name = "sameBoardBtn";
            this.sameBoardBtn.Size = new System.Drawing.Size(122, 25);
            this.sameBoardBtn.TabIndex = 6;
            this.sameBoardBtn.TabStop = true;
            this.sameBoardBtn.Text = "Same Board";
            this.sameBoardBtn.UseVisualStyleBackColor = true;
            // 
            // newBoardBtn
            // 
            this.newBoardBtn.AutoSize = true;
            this.newBoardBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newBoardBtn.Location = new System.Drawing.Point(70, 154);
            this.newBoardBtn.Name = "newBoardBtn";
            this.newBoardBtn.Size = new System.Drawing.Size(114, 25);
            this.newBoardBtn.TabIndex = 7;
            this.newBoardBtn.TabStop = true;
            this.newBoardBtn.Text = "New Board";
            this.newBoardBtn.UseVisualStyleBackColor = true;
            // 
            // cupssBtn
            // 
            this.cupssBtn.AutoSize = true;
            this.cupssBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cupssBtn.Location = new System.Drawing.Point(70, 219);
            this.cupssBtn.Name = "cupssBtn";
            this.cupssBtn.Size = new System.Drawing.Size(77, 25);
            this.cupssBtn.TabIndex = 8;
            this.cupssBtn.TabStop = true;
            this.cupssBtn.Text = "CUPSS";
            this.cupssBtn.UseVisualStyleBackColor = true;
            // 
            // addTestsButton
            // 
            this.addTestsButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTestsButton.Location = new System.Drawing.Point(312, 263);
            this.addTestsButton.Name = "addTestsButton";
            this.addTestsButton.Size = new System.Drawing.Size(161, 54);
            this.addTestsButton.TabIndex = 9;
            this.addTestsButton.Text = "Add Tests";
            this.addTestsButton.UseVisualStyleBackColor = true;
            this.addTestsButton.Click += new System.EventHandler(this.addTestsButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackButton.Image = ((System.Drawing.Image)(resources.GetObject("BackButton.Image")));
            this.BackButton.Location = new System.Drawing.Point(30, 265);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 54);
            this.BackButton.TabIndex = 47;
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // AddTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(794, 341);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.addTestsButton);
            this.Controls.Add(this.cupssBtn);
            this.Controls.Add(this.newBoardBtn);
            this.Controls.Add(this.sameBoardBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PathBox);
            this.Controls.Add(this.chronosPathLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddTests";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddTests";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddTests_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PathBox;
        private System.Windows.Forms.Label chronosPathLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton sameBoardBtn;
        private System.Windows.Forms.RadioButton newBoardBtn;
        private System.Windows.Forms.RadioButton cupssBtn;
        private System.Windows.Forms.Button addTestsButton;
        private System.Windows.Forms.Button BackButton;
    }
}