namespace SE_Report.Forms
{
    partial class Unit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Unit));
            this.label1 = new System.Windows.Forms.Label();
            this.VersionBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NTCodeBox = new System.Windows.Forms.TextBox();
            this.Table = new System.Windows.Forms.DataGridView();
            this.TD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.FinishButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.Minutes = new System.Windows.Forms.Label();
            this.TimeElapsedLabel = new System.Windows.Forms.Label();
            this.Stopwatch = new System.Windows.Forms.Timer(this.components);
            this.Refresher = new System.Windows.Forms.Timer(this.components);
            this.Stopwatch2 = new System.Windows.Forms.Timer(this.components);
            this.Colon = new System.Windows.Forms.Label();
            this.Seconds = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NotTestedDisplay = new System.Windows.Forms.Label();
            this.LeftDisplay = new System.Windows.Forms.Label();
            this.NotFixedDisplay = new System.Windows.Forms.Label();
            this.NADisplay = new System.Windows.Forms.Label();
            this.FixedDisplay = new System.Windows.Forms.Label();
            this.StatsLabel = new System.Windows.Forms.Label();
            this.PathGroup = new System.Windows.Forms.GroupBox();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.LinksButton = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.GPRIButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.PathGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Version:";
            // 
            // VersionBox
            // 
            this.VersionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VersionBox.BackColor = System.Drawing.Color.White;
            this.VersionBox.Location = new System.Drawing.Point(91, 32);
            this.VersionBox.Name = "VersionBox";
            this.VersionBox.ReadOnly = true;
            this.VersionBox.Size = new System.Drawing.Size(690, 27);
            this.VersionBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "NT code:";
            // 
            // NTCodeBox
            // 
            this.NTCodeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NTCodeBox.BackColor = System.Drawing.Color.White;
            this.NTCodeBox.Location = new System.Drawing.Point(91, 76);
            this.NTCodeBox.Name = "NTCodeBox";
            this.NTCodeBox.ReadOnly = true;
            this.NTCodeBox.Size = new System.Drawing.Size(690, 27);
            this.NTCodeBox.TabIndex = 3;
            // 
            // Table
            // 
            this.Table.AllowUserToAddRows = false;
            this.Table.AllowUserToDeleteRows = false;
            this.Table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Table.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.Table.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.Table.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.Table.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Table.ColumnHeadersHeight = 30;
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TD,
            this.Status,
            this.Comments});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Table.DefaultCellStyle = dataGridViewCellStyle5;
            this.Table.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.Table.GridColor = System.Drawing.Color.Black;
            this.Table.Location = new System.Drawing.Point(17, 220);
            this.Table.Name = "Table";
            this.Table.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.Table.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.Table.RowHeadersVisible = false;
            this.Table.RowHeadersWidth = 40;
            this.Table.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Table.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.Table.RowTemplate.Height = 30;
            this.Table.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Table.ShowCellErrors = false;
            this.Table.ShowRowErrors = false;
            this.Table.Size = new System.Drawing.Size(752, 329);
            this.Table.StandardTab = true;
            this.Table.TabIndex = 6;
            this.Table.Visible = false;
            // 
            // TD
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.Format = "N0";
            this.TD.DefaultCellStyle = dataGridViewCellStyle2;
            this.TD.Frozen = true;
            this.TD.HeaderText = "TD #";
            this.TD.Name = "TD";
            this.TD.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TD.ToolTipText = "Type here the issue\'s TD number";
            // 
            // Status
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Status.DefaultCellStyle = dataGridViewCellStyle3;
            this.Status.Frozen = true;
            this.Status.HeaderText = "Status";
            this.Status.Items.AddRange(new object[] {
            "FIXED",
            "N/A",
            "NOT FIXED",
            "NOT TESTED"});
            this.Status.Name = "Status";
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Status.Sorted = true;
            this.Status.ToolTipText = "Specify whether the issue has been fixed or not";
            this.Status.Width = 150;
            // 
            // Comments
            // 
            this.Comments.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Comments.DefaultCellStyle = dataGridViewCellStyle4;
            this.Comments.HeaderText = "Comments";
            this.Comments.Name = "Comments";
            this.Comments.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Comments.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Comments.ToolTipText = "Leave a comment about this issue (if necessary)";
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.ForeColor = System.Drawing.Color.Red;
            this.AddButton.Location = new System.Drawing.Point(775, 356);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(32, 29);
            this.AddButton.TabIndex = 7;
            this.AddButton.Text = "+";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Visible = false;
            this.AddButton.Click += new System.EventHandler(this.Add_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RemoveButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.RemoveButton.Location = new System.Drawing.Point(775, 391);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(31, 29);
            this.RemoveButton.TabIndex = 8;
            this.RemoveButton.Text = "-";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Visible = false;
            this.RemoveButton.Click += new System.EventHandler(this.Remove_Click);
            // 
            // FinishButton
            // 
            this.FinishButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.FinishButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FinishButton.Location = new System.Drawing.Point(416, 624);
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.Size = new System.Drawing.Size(155, 61);
            this.FinishButton.TabIndex = 10;
            this.FinishButton.Text = "FINISH && REPORT";
            this.FinishButton.UseVisualStyleBackColor = true;
            this.FinishButton.Visible = false;
            this.FinishButton.Click += new System.EventHandler(this.FinishButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.StartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartButton.Location = new System.Drawing.Point(218, 624);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(155, 61);
            this.StartButton.TabIndex = 17;
            this.StartButton.Text = "START TEST";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // Minutes
            // 
            this.Minutes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Minutes.AutoSize = true;
            this.Minutes.Location = new System.Drawing.Point(688, 653);
            this.Minutes.Name = "Minutes";
            this.Minutes.Size = new System.Drawing.Size(28, 21);
            this.Minutes.TabIndex = 20;
            this.Minutes.Text = "00";
            this.Minutes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Minutes.Visible = false;
            // 
            // TimeElapsedLabel
            // 
            this.TimeElapsedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TimeElapsedLabel.AutoSize = true;
            this.TimeElapsedLabel.Location = new System.Drawing.Point(688, 632);
            this.TimeElapsedLabel.Name = "TimeElapsedLabel";
            this.TimeElapsedLabel.Size = new System.Drawing.Size(110, 21);
            this.TimeElapsedLabel.TabIndex = 19;
            this.TimeElapsedLabel.Text = "Elapsed time";
            this.TimeElapsedLabel.Visible = false;
            // 
            // Stopwatch
            // 
            this.Stopwatch.Interval = 60000;
            this.Stopwatch.Tick += new System.EventHandler(this.Stopwatch_Tick);
            // 
            // Refresher
            // 
            this.Refresher.Enabled = true;
            this.Refresher.Interval = 1;
            this.Refresher.Tick += new System.EventHandler(this.Refresher_Tick);
            // 
            // Stopwatch2
            // 
            this.Stopwatch2.Interval = 1000;
            this.Stopwatch2.Tick += new System.EventHandler(this.Stopwatch2_Tick);
            // 
            // Colon
            // 
            this.Colon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Colon.AutoSize = true;
            this.Colon.Location = new System.Drawing.Point(722, 653);
            this.Colon.Name = "Colon";
            this.Colon.Size = new System.Drawing.Size(14, 21);
            this.Colon.TabIndex = 28;
            this.Colon.Text = ":";
            this.Colon.Visible = false;
            // 
            // Seconds
            // 
            this.Seconds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Seconds.AutoSize = true;
            this.Seconds.Location = new System.Drawing.Point(742, 653);
            this.Seconds.Name = "Seconds";
            this.Seconds.Size = new System.Drawing.Size(28, 21);
            this.Seconds.TabIndex = 29;
            this.Seconds.Text = "00";
            this.Seconds.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.VersionBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.NTCodeBox);
            this.groupBox1.Location = new System.Drawing.Point(17, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(787, 118);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Software info";
            // 
            // NotTestedDisplay
            // 
            this.NotTestedDisplay.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.NotTestedDisplay.AutoSize = true;
            this.NotTestedDisplay.Location = new System.Drawing.Point(470, 573);
            this.NotTestedDisplay.Name = "NotTestedDisplay";
            this.NotTestedDisplay.Size = new System.Drawing.Size(19, 21);
            this.NotTestedDisplay.TabIndex = 91;
            this.NotTestedDisplay.Text = "0";
            this.NotTestedDisplay.Visible = false;
            // 
            // LeftDisplay
            // 
            this.LeftDisplay.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LeftDisplay.AutoSize = true;
            this.LeftDisplay.Location = new System.Drawing.Point(552, 573);
            this.LeftDisplay.Name = "LeftDisplay";
            this.LeftDisplay.Size = new System.Drawing.Size(19, 21);
            this.LeftDisplay.TabIndex = 90;
            this.LeftDisplay.Text = "0";
            this.LeftDisplay.Visible = false;
            // 
            // NotFixedDisplay
            // 
            this.NotFixedDisplay.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.NotFixedDisplay.AutoSize = true;
            this.NotFixedDisplay.Location = new System.Drawing.Point(373, 573);
            this.NotFixedDisplay.Name = "NotFixedDisplay";
            this.NotFixedDisplay.Size = new System.Drawing.Size(19, 21);
            this.NotFixedDisplay.TabIndex = 89;
            this.NotFixedDisplay.Text = "0";
            this.NotFixedDisplay.Visible = false;
            // 
            // NADisplay
            // 
            this.NADisplay.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.NADisplay.AutoSize = true;
            this.NADisplay.Location = new System.Drawing.Point(312, 573);
            this.NADisplay.Name = "NADisplay";
            this.NADisplay.Size = new System.Drawing.Size(19, 21);
            this.NADisplay.TabIndex = 88;
            this.NADisplay.Text = "0";
            this.NADisplay.Visible = false;
            // 
            // FixedDisplay
            // 
            this.FixedDisplay.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.FixedDisplay.AutoSize = true;
            this.FixedDisplay.Location = new System.Drawing.Point(230, 573);
            this.FixedDisplay.Name = "FixedDisplay";
            this.FixedDisplay.Size = new System.Drawing.Size(19, 21);
            this.FixedDisplay.TabIndex = 87;
            this.FixedDisplay.Text = "0";
            this.FixedDisplay.Visible = false;
            // 
            // StatsLabel
            // 
            this.StatsLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.StatsLabel.AutoSize = true;
            this.StatsLabel.Location = new System.Drawing.Point(214, 552);
            this.StatsLabel.Name = "StatsLabel";
            this.StatsLabel.Size = new System.Drawing.Size(369, 21);
            this.StatsLabel.TabIndex = 86;
            this.StatsLabel.Text = "Fixed           N/A     Not fixed     Not tested     Left";
            this.StatsLabel.Visible = false;
            // 
            // PathGroup
            // 
            this.PathGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathGroup.Controls.Add(this.PathBox);
            this.PathGroup.Location = new System.Drawing.Point(17, 12);
            this.PathGroup.Name = "PathGroup";
            this.PathGroup.Size = new System.Drawing.Size(787, 78);
            this.PathGroup.TabIndex = 92;
            this.PathGroup.TabStop = false;
            this.PathGroup.Text = "Chronos path";
            // 
            // PathBox
            // 
            this.PathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathBox.Location = new System.Drawing.Point(10, 36);
            this.PathBox.Name = "PathBox";
            this.PathBox.Size = new System.Drawing.Size(771, 27);
            this.PathBox.TabIndex = 0;
            // 
            // LinksButton
            // 
            this.LinksButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LinksButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LinksButton.Image = ((System.Drawing.Image)(resources.GetObject("LinksButton.Image")));
            this.LinksButton.Location = new System.Drawing.Point(591, 624);
            this.LinksButton.Name = "LinksButton";
            this.LinksButton.Size = new System.Drawing.Size(76, 61);
            this.LinksButton.TabIndex = 93;
            this.LinksButton.UseVisualStyleBackColor = true;
            this.LinksButton.Click += new System.EventHandler(this.LinksButton_Click);
            // 
            // Back
            // 
            this.Back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Back.BackColor = System.Drawing.Color.Transparent;
            this.Back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Back.Image = ((System.Drawing.Image)(resources.GetObject("Back.Image")));
            this.Back.Location = new System.Drawing.Point(16, 624);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(75, 61);
            this.Back.TabIndex = 9;
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // GPRIButton
            // 
            this.GPRIButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.GPRIButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GPRIButton.Location = new System.Drawing.Point(108, 626);
            this.GPRIButton.Name = "GPRIButton";
            this.GPRIButton.Size = new System.Drawing.Size(98, 59);
            this.GPRIButton.TabIndex = 98;
            this.GPRIButton.Text = "GPRI";
            this.GPRIButton.UseVisualStyleBackColor = true;
            this.GPRIButton.Click += new System.EventHandler(this.GPRIButton_Click);
            // 
            // Unit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(816, 697);
            this.Controls.Add(this.GPRIButton);
            this.Controls.Add(this.LinksButton);
            this.Controls.Add(this.PathGroup);
            this.Controls.Add(this.NotTestedDisplay);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LeftDisplay);
            this.Controls.Add(this.Seconds);
            this.Controls.Add(this.NotFixedDisplay);
            this.Controls.Add(this.Colon);
            this.Controls.Add(this.NADisplay);
            this.Controls.Add(this.Minutes);
            this.Controls.Add(this.FixedDisplay);
            this.Controls.Add(this.TimeElapsedLabel);
            this.Controls.Add(this.StatsLabel);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.FinishButton);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.Table);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Unit";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unit";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Unit_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Unit_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.PathGroup.ResumeLayout(false);
            this.PathGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button FinishButton;
        private System.Windows.Forms.TextBox VersionBox;
        private System.Windows.Forms.TextBox NTCodeBox;
        private System.Windows.Forms.DataGridView Table;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label Minutes;
        private System.Windows.Forms.Label TimeElapsedLabel;
        private System.Windows.Forms.Timer Stopwatch;
        private System.Windows.Forms.Timer Refresher;
        private System.Windows.Forms.Timer Stopwatch2;
        private System.Windows.Forms.Label Colon;
        private System.Windows.Forms.Label Seconds;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label NotTestedDisplay;
        private System.Windows.Forms.Label LeftDisplay;
        private System.Windows.Forms.Label NotFixedDisplay;
        private System.Windows.Forms.Label NADisplay;
        private System.Windows.Forms.Label FixedDisplay;
        private System.Windows.Forms.Label StatsLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn TD;
        private System.Windows.Forms.DataGridViewComboBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comments;
        private System.Windows.Forms.GroupBox PathGroup;
        private System.Windows.Forms.TextBox PathBox;
        private System.Windows.Forms.Button LinksButton;
        private System.Windows.Forms.Button GPRIButton;
    }
}