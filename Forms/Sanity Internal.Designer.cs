namespace SE_Report.Forms
{
    partial class InternalTests
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InternalTests));
            this.GPRIButton = new System.Windows.Forms.Button();
            this.LinksButton = new System.Windows.Forms.Button();
            this.PathGroup = new System.Windows.Forms.GroupBox();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.NotTestedDisplay = new System.Windows.Forms.Label();
            this.LeftDisplay = new System.Windows.Forms.Label();
            this.FailedDisplay = new System.Windows.Forms.Label();
            this.NADisplay = new System.Windows.Forms.Label();
            this.PassedDisplay = new System.Windows.Forms.Label();
            this.StatsLabel = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.SWGroup = new System.Windows.Forms.GroupBox();
            this.CreationDateBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.VersionBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.NTCodeBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.AdditGroup = new System.Windows.Forms.GroupBox();
            this.CycleBox = new System.Windows.Forms.TextBox();
            this.PackageBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ModelGroup = new System.Windows.Forms.GroupBox();
            this.ModelBox = new System.Windows.Forms.TextBox();
            this.BuyerGroup = new System.Windows.Forms.GroupBox();
            this.BuyerBox = new System.Windows.Forms.TextBox();
            this.Seconds = new System.Windows.Forms.Label();
            this.Colon = new System.Windows.Forms.Label();
            this.Table = new System.Windows.Forms.DataGridView();
            this.Minutes = new System.Windows.Forms.Label();
            this.TimeElapsedLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.FinishButton = new System.Windows.Forms.Button();
            this.Stopwatch = new System.Windows.Forms.Timer(this.components);
            this.Stopwatch2 = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PathGroup.SuspendLayout();
            this.SWGroup.SuspendLayout();
            this.AdditGroup.SuspendLayout();
            this.ModelGroup.SuspendLayout();
            this.BuyerGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            this.SuspendLayout();
            // 
            // GPRIButton
            // 
            this.GPRIButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.GPRIButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GPRIButton.Location = new System.Drawing.Point(142, 715);
            this.GPRIButton.Name = "GPRIButton";
            this.GPRIButton.Size = new System.Drawing.Size(98, 61);
            this.GPRIButton.TabIndex = 117;
            this.GPRIButton.Text = "GPRI";
            this.GPRIButton.UseVisualStyleBackColor = true;
            this.GPRIButton.Click += new System.EventHandler(this.GPRIButton_Click);
            // 
            // LinksButton
            // 
            this.LinksButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LinksButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LinksButton.Image = ((System.Drawing.Image)(resources.GetObject("LinksButton.Image")));
            this.LinksButton.Location = new System.Drawing.Point(712, 715);
            this.LinksButton.Name = "LinksButton";
            this.LinksButton.Size = new System.Drawing.Size(76, 61);
            this.LinksButton.TabIndex = 116;
            this.LinksButton.UseVisualStyleBackColor = true;
            this.LinksButton.Click += new System.EventHandler(this.LinksButton_Click);
            // 
            // PathGroup
            // 
            this.PathGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathGroup.Controls.Add(this.PathBox);
            this.PathGroup.Location = new System.Drawing.Point(12, 8);
            this.PathGroup.Name = "PathGroup";
            this.PathGroup.Size = new System.Drawing.Size(1033, 72);
            this.PathGroup.TabIndex = 115;
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
            this.PathBox.Size = new System.Drawing.Size(1007, 27);
            this.PathBox.TabIndex = 0;
            // 
            // NotTestedDisplay
            // 
            this.NotTestedDisplay.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.NotTestedDisplay.AutoSize = true;
            this.NotTestedDisplay.Location = new System.Drawing.Point(592, 685);
            this.NotTestedDisplay.Name = "NotTestedDisplay";
            this.NotTestedDisplay.Size = new System.Drawing.Size(19, 21);
            this.NotTestedDisplay.TabIndex = 114;
            this.NotTestedDisplay.Text = "0";
            this.NotTestedDisplay.Visible = false;
            // 
            // LeftDisplay
            // 
            this.LeftDisplay.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LeftDisplay.AutoSize = true;
            this.LeftDisplay.Location = new System.Drawing.Point(674, 685);
            this.LeftDisplay.Name = "LeftDisplay";
            this.LeftDisplay.Size = new System.Drawing.Size(19, 21);
            this.LeftDisplay.TabIndex = 113;
            this.LeftDisplay.Text = "0";
            this.LeftDisplay.Visible = false;
            // 
            // FailedDisplay
            // 
            this.FailedDisplay.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.FailedDisplay.AutoSize = true;
            this.FailedDisplay.Location = new System.Drawing.Point(495, 685);
            this.FailedDisplay.Name = "FailedDisplay";
            this.FailedDisplay.Size = new System.Drawing.Size(19, 21);
            this.FailedDisplay.TabIndex = 112;
            this.FailedDisplay.Text = "0";
            this.FailedDisplay.Visible = false;
            // 
            // NADisplay
            // 
            this.NADisplay.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.NADisplay.AutoSize = true;
            this.NADisplay.Location = new System.Drawing.Point(434, 685);
            this.NADisplay.Name = "NADisplay";
            this.NADisplay.Size = new System.Drawing.Size(19, 21);
            this.NADisplay.TabIndex = 111;
            this.NADisplay.Text = "0";
            this.NADisplay.Visible = false;
            // 
            // PassedDisplay
            // 
            this.PassedDisplay.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PassedDisplay.AutoSize = true;
            this.PassedDisplay.Location = new System.Drawing.Point(352, 685);
            this.PassedDisplay.Name = "PassedDisplay";
            this.PassedDisplay.Size = new System.Drawing.Size(19, 21);
            this.PassedDisplay.TabIndex = 110;
            this.PassedDisplay.Text = "0";
            this.PassedDisplay.Visible = false;
            // 
            // StatsLabel
            // 
            this.StatsLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.StatsLabel.AutoSize = true;
            this.StatsLabel.Location = new System.Drawing.Point(336, 664);
            this.StatsLabel.Name = "StatsLabel";
            this.StatsLabel.Size = new System.Drawing.Size(370, 21);
            this.StatsLabel.TabIndex = 109;
            this.StatsLabel.Text = "Passed        N/A        Failed        Not tested     Left";
            this.StatsLabel.Visible = false;
            // 
            // BackButton
            // 
            this.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackButton.Image = ((System.Drawing.Image)(resources.GetObject("BackButton.Image")));
            this.BackButton.Location = new System.Drawing.Point(12, 715);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 61);
            this.BackButton.TabIndex = 108;
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // SWGroup
            // 
            this.SWGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SWGroup.Controls.Add(this.CreationDateBox);
            this.SWGroup.Controls.Add(this.label7);
            this.SWGroup.Controls.Add(this.VersionBox);
            this.SWGroup.Controls.Add(this.label5);
            this.SWGroup.Controls.Add(this.NTCodeBox);
            this.SWGroup.Controls.Add(this.label6);
            this.SWGroup.Location = new System.Drawing.Point(12, 216);
            this.SWGroup.Name = "SWGroup";
            this.SWGroup.Size = new System.Drawing.Size(1033, 100);
            this.SWGroup.TabIndex = 107;
            this.SWGroup.TabStop = false;
            this.SWGroup.Text = "Software info";
            // 
            // CreationDateBox
            // 
            this.CreationDateBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreationDateBox.BackColor = System.Drawing.Color.White;
            this.CreationDateBox.Location = new System.Drawing.Point(867, 48);
            this.CreationDateBox.Name = "CreationDateBox";
            this.CreationDateBox.Size = new System.Drawing.Size(160, 27);
            this.CreationDateBox.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 21);
            this.label7.TabIndex = 19;
            this.label7.Text = "Version:";
            // 
            // VersionBox
            // 
            this.VersionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VersionBox.BackColor = System.Drawing.Color.White;
            this.VersionBox.Location = new System.Drawing.Point(94, 32);
            this.VersionBox.Name = "VersionBox";
            this.VersionBox.Size = new System.Drawing.Size(635, 27);
            this.VersionBox.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "NT Code:";
            // 
            // NTCodeBox
            // 
            this.NTCodeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NTCodeBox.BackColor = System.Drawing.Color.White;
            this.NTCodeBox.Location = new System.Drawing.Point(94, 64);
            this.NTCodeBox.Multiline = true;
            this.NTCodeBox.Name = "NTCodeBox";
            this.NTCodeBox.Size = new System.Drawing.Size(635, 27);
            this.NTCodeBox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(735, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 21);
            this.label6.TabIndex = 10;
            this.label6.Text = "Creation date:";
            // 
            // AdditGroup
            // 
            this.AdditGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AdditGroup.Controls.Add(this.CycleBox);
            this.AdditGroup.Controls.Add(this.PackageBox);
            this.AdditGroup.Controls.Add(this.label4);
            this.AdditGroup.Controls.Add(this.label3);
            this.AdditGroup.Location = new System.Drawing.Point(829, 86);
            this.AdditGroup.Name = "AdditGroup";
            this.AdditGroup.Size = new System.Drawing.Size(216, 124);
            this.AdditGroup.TabIndex = 106;
            this.AdditGroup.TabStop = false;
            this.AdditGroup.Text = "Additional info";
            // 
            // CycleBox
            // 
            this.CycleBox.BackColor = System.Drawing.Color.White;
            this.CycleBox.Location = new System.Drawing.Point(71, 40);
            this.CycleBox.Name = "CycleBox";
            this.CycleBox.Size = new System.Drawing.Size(139, 27);
            this.CycleBox.TabIndex = 9;
            // 
            // PackageBox
            // 
            this.PackageBox.BackColor = System.Drawing.Color.White;
            this.PackageBox.Location = new System.Drawing.Point(102, 82);
            this.PackageBox.Name = "PackageBox";
            this.PackageBox.Size = new System.Drawing.Size(108, 27);
            this.PackageBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Package:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cycle:";
            // 
            // ModelGroup
            // 
            this.ModelGroup.Controls.Add(this.ModelBox);
            this.ModelGroup.Location = new System.Drawing.Point(12, 86);
            this.ModelGroup.Name = "ModelGroup";
            this.ModelGroup.Size = new System.Drawing.Size(144, 124);
            this.ModelGroup.TabIndex = 105;
            this.ModelGroup.TabStop = false;
            this.ModelGroup.Text = "Model";
            // 
            // ModelBox
            // 
            this.ModelBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ModelBox.BackColor = System.Drawing.Color.White;
            this.ModelBox.Location = new System.Drawing.Point(10, 56);
            this.ModelBox.Name = "ModelBox";
            this.ModelBox.ReadOnly = true;
            this.ModelBox.Size = new System.Drawing.Size(128, 27);
            this.ModelBox.TabIndex = 0;
            // 
            // BuyerGroup
            // 
            this.BuyerGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuyerGroup.Controls.Add(this.BuyerBox);
            this.BuyerGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BuyerGroup.Location = new System.Drawing.Point(162, 86);
            this.BuyerGroup.Name = "BuyerGroup";
            this.BuyerGroup.Size = new System.Drawing.Size(661, 124);
            this.BuyerGroup.TabIndex = 104;
            this.BuyerGroup.TabStop = false;
            this.BuyerGroup.Text = "Buyer";
            // 
            // BuyerBox
            // 
            this.BuyerBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuyerBox.BackColor = System.Drawing.Color.White;
            this.BuyerBox.Location = new System.Drawing.Point(6, 56);
            this.BuyerBox.Name = "BuyerBox";
            this.BuyerBox.ReadOnly = true;
            this.BuyerBox.Size = new System.Drawing.Size(649, 27);
            this.BuyerBox.TabIndex = 0;
            // 
            // Seconds
            // 
            this.Seconds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Seconds.AutoSize = true;
            this.Seconds.Location = new System.Drawing.Point(975, 748);
            this.Seconds.Name = "Seconds";
            this.Seconds.Size = new System.Drawing.Size(28, 21);
            this.Seconds.TabIndex = 103;
            this.Seconds.Text = "00";
            this.Seconds.Visible = false;
            // 
            // Colon
            // 
            this.Colon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Colon.AutoSize = true;
            this.Colon.Location = new System.Drawing.Point(953, 748);
            this.Colon.Name = "Colon";
            this.Colon.Size = new System.Drawing.Size(14, 21);
            this.Colon.TabIndex = 102;
            this.Colon.Text = ":";
            this.Colon.Visible = false;
            // 
            // Table
            // 
            this.Table.AllowUserToAddRows = false;
            this.Table.AllowUserToDeleteRows = false;
            this.Table.AllowUserToResizeRows = false;
            this.Table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Table.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Table.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.Table.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.Table.ColumnHeadersHeight = 25;
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Table.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.Table.GridColor = System.Drawing.Color.Black;
            this.Table.Location = new System.Drawing.Point(12, 329);
            this.Table.Name = "Table";
            this.Table.RowHeadersVisible = false;
            this.Table.Size = new System.Drawing.Size(1034, 332);
            this.Table.TabIndex = 101;
            this.Table.Visible = false;
            // 
            // Minutes
            // 
            this.Minutes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Minutes.AutoSize = true;
            this.Minutes.Location = new System.Drawing.Point(919, 748);
            this.Minutes.Name = "Minutes";
            this.Minutes.Size = new System.Drawing.Size(28, 21);
            this.Minutes.TabIndex = 100;
            this.Minutes.Text = "00";
            this.Minutes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Minutes.Visible = false;
            // 
            // TimeElapsedLabel
            // 
            this.TimeElapsedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TimeElapsedLabel.AutoSize = true;
            this.TimeElapsedLabel.Location = new System.Drawing.Point(919, 725);
            this.TimeElapsedLabel.Name = "TimeElapsedLabel";
            this.TimeElapsedLabel.Size = new System.Drawing.Size(110, 21);
            this.TimeElapsedLabel.TabIndex = 99;
            this.TimeElapsedLabel.Text = "Elapsed time";
            this.TimeElapsedLabel.Visible = false;
            // 
            // StartButton
            // 
            this.StartButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.StartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartButton.Location = new System.Drawing.Point(298, 715);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(151, 61);
            this.StartButton.TabIndex = 98;
            this.StartButton.Text = "START TEST";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // FinishButton
            // 
            this.FinishButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.FinishButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FinishButton.Location = new System.Drawing.Point(506, 715);
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.Size = new System.Drawing.Size(171, 61);
            this.FinishButton.TabIndex = 97;
            this.FinishButton.Text = "FINISH && REPORT";
            this.FinishButton.UseVisualStyleBackColor = true;
            this.FinishButton.Visible = false;
            this.FinishButton.Click += new System.EventHandler(this.FinishButton_Click);
            // 
            // Stopwatch
            // 
            this.Stopwatch.Interval = 60000;
            this.Stopwatch.Tick += new System.EventHandler(this.Stopwatch_Tick);
            // 
            // Stopwatch2
            // 
            this.Stopwatch2.Interval = 1000;
            this.Stopwatch2.Tick += new System.EventHandler(this.Stopwatch2_Tick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // InternalTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(1058, 785);
            this.Controls.Add(this.GPRIButton);
            this.Controls.Add(this.LinksButton);
            this.Controls.Add(this.PathGroup);
            this.Controls.Add(this.NotTestedDisplay);
            this.Controls.Add(this.LeftDisplay);
            this.Controls.Add(this.FailedDisplay);
            this.Controls.Add(this.NADisplay);
            this.Controls.Add(this.PassedDisplay);
            this.Controls.Add(this.StatsLabel);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.SWGroup);
            this.Controls.Add(this.AdditGroup);
            this.Controls.Add(this.ModelGroup);
            this.Controls.Add(this.BuyerGroup);
            this.Controls.Add(this.Seconds);
            this.Controls.Add(this.Colon);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.Minutes);
            this.Controls.Add(this.TimeElapsedLabel);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.FinishButton);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(1024, 726);
            this.Name = "InternalTests";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sanity Internal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InternalTests_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InternalTests_FormClosed);
            this.PathGroup.ResumeLayout(false);
            this.PathGroup.PerformLayout();
            this.SWGroup.ResumeLayout(false);
            this.SWGroup.PerformLayout();
            this.AdditGroup.ResumeLayout(false);
            this.AdditGroup.PerformLayout();
            this.ModelGroup.ResumeLayout(false);
            this.ModelGroup.PerformLayout();
            this.BuyerGroup.ResumeLayout(false);
            this.BuyerGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GPRIButton;
        private System.Windows.Forms.Button LinksButton;
        private System.Windows.Forms.GroupBox PathGroup;
        private System.Windows.Forms.TextBox PathBox;
        private System.Windows.Forms.Label NotTestedDisplay;
        private System.Windows.Forms.Label LeftDisplay;
        private System.Windows.Forms.Label FailedDisplay;
        private System.Windows.Forms.Label NADisplay;
        private System.Windows.Forms.Label PassedDisplay;
        private System.Windows.Forms.Label StatsLabel;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.GroupBox SWGroup;
        private System.Windows.Forms.TextBox CreationDateBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox VersionBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox NTCodeBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox AdditGroup;
        private System.Windows.Forms.TextBox CycleBox;
        private System.Windows.Forms.TextBox PackageBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox ModelGroup;
        private System.Windows.Forms.TextBox ModelBox;
        private System.Windows.Forms.GroupBox BuyerGroup;
        private System.Windows.Forms.TextBox BuyerBox;
        private System.Windows.Forms.Label Seconds;
        private System.Windows.Forms.Label Colon;
        private System.Windows.Forms.DataGridView Table;
        private System.Windows.Forms.Label Minutes;
        private System.Windows.Forms.Label TimeElapsedLabel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button FinishButton;
        private System.Windows.Forms.Timer Stopwatch;
        private System.Windows.Forms.Timer Stopwatch2;
        private System.Windows.Forms.Timer timer1;
    }
}