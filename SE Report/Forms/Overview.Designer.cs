namespace SE_Report.Forms
{
    partial class Overview
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Overview));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ProjectsTable = new System.Windows.Forms.DataGridView();
            this.deleteButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.LinksButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.TestersTable = new System.Windows.Forms.DataGridView();
            this.available = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.busy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatsTable = new System.Windows.Forms.DataGridView();
            this.allPassed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.failed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inProgress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cancelled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.you = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestersTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // ProjectsTable
            // 
            this.ProjectsTable.AllowUserToAddRows = false;
            this.ProjectsTable.AllowUserToDeleteRows = false;
            this.ProjectsTable.AllowUserToResizeColumns = false;
            this.ProjectsTable.AllowUserToResizeRows = false;
            this.ProjectsTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProjectsTable.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProjectsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ProjectsTable.ColumnHeadersHeight = 30;
            this.ProjectsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ProjectsTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.ProjectsTable.Location = new System.Drawing.Point(12, 45);
            this.ProjectsTable.Name = "ProjectsTable";
            this.ProjectsTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ProjectsTable.Size = new System.Drawing.Size(727, 362);
            this.ProjectsTable.TabIndex = 0;
            this.ProjectsTable.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ProjectsTable_DataBindingComplete);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.deleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteButton.Image = global::SE_Report.Properties.Resources.Bin;
            this.deleteButton.Location = new System.Drawing.Point(468, 653);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 61);
            this.deleteButton.TabIndex = 99;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RefreshButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RefreshButton.Image = global::SE_Report.Properties.Resources.Refresh2;
            this.RefreshButton.Location = new System.Drawing.Point(179, 653);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 61);
            this.RefreshButton.TabIndex = 97;
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // LinksButton
            // 
            this.LinksButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LinksButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LinksButton.Image = ((System.Drawing.Image)(resources.GetObject("LinksButton.Image")));
            this.LinksButton.Location = new System.Drawing.Point(663, 653);
            this.LinksButton.Name = "LinksButton";
            this.LinksButton.Size = new System.Drawing.Size(76, 61);
            this.LinksButton.TabIndex = 96;
            this.LinksButton.UseVisualStyleBackColor = true;
            this.LinksButton.Click += new System.EventHandler(this.LinksButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackButton.Image = ((System.Drawing.Image)(resources.GetObject("BackButton.Image")));
            this.BackButton.Location = new System.Drawing.Point(12, 653);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 61);
            this.BackButton.TabIndex = 46;
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // TestersTable
            // 
            this.TestersTable.AllowUserToAddRows = false;
            this.TestersTable.AllowUserToResizeColumns = false;
            this.TestersTable.AllowUserToResizeRows = false;
            this.TestersTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TestersTable.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TestersTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.TestersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TestersTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.available,
            this.busy});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TestersTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.TestersTable.Location = new System.Drawing.Point(12, 413);
            this.TestersTable.Name = "TestersTable";
            this.TestersTable.RowHeadersVisible = false;
            this.TestersTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.TestersTable.Size = new System.Drawing.Size(727, 159);
            this.TestersTable.TabIndex = 100;
            // 
            // available
            // 
            this.available.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.available.HeaderText = "AVAILABLE";
            this.available.Name = "available";
            this.available.ReadOnly = true;
            this.available.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // busy
            // 
            this.busy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.busy.HeaderText = "BUSY";
            this.busy.Name = "busy";
            this.busy.ReadOnly = true;
            this.busy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // StatsTable
            // 
            this.StatsTable.AllowUserToAddRows = false;
            this.StatsTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatsTable.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.StatsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.StatsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StatsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.allPassed,
            this.failed,
            this.inProgress,
            this.cancelled,
            this.you});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.StatsTable.DefaultCellStyle = dataGridViewCellStyle5;
            this.StatsTable.Location = new System.Drawing.Point(12, 578);
            this.StatsTable.Name = "StatsTable";
            this.StatsTable.RowHeadersVisible = false;
            this.StatsTable.Size = new System.Drawing.Size(727, 69);
            this.StatsTable.TabIndex = 101;
            // 
            // allPassed
            // 
            this.allPassed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.allPassed.HeaderText = "ALL PASSED";
            this.allPassed.Name = "allPassed";
            this.allPassed.ReadOnly = true;
            this.allPassed.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // failed
            // 
            this.failed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.failed.HeaderText = "FAILED";
            this.failed.Name = "failed";
            this.failed.ReadOnly = true;
            this.failed.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // inProgress
            // 
            this.inProgress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.inProgress.HeaderText = "In progress";
            this.inProgress.Name = "inProgress";
            this.inProgress.ReadOnly = true;
            this.inProgress.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // cancelled
            // 
            this.cancelled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cancelled.HeaderText = "Cancelled";
            this.cancelled.Name = "cancelled";
            this.cancelled.ReadOnly = true;
            this.cancelled.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // you
            // 
            this.you.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.you.HeaderText = "Your projects";
            this.you.Name = "you";
            this.you.ReadOnly = true;
            this.you.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // SearchBox
            // 
            this.SearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchBox.Location = new System.Drawing.Point(12, 12);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(645, 27);
            this.SearchBox.TabIndex = 102;
            this.SearchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchBox_KeyPress);
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchButton.Location = new System.Drawing.Point(663, 12);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(76, 27);
            this.SearchButton.TabIndex = 103;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // Overview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 726);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.StatsTable);
            this.Controls.Add(this.TestersTable);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.LinksButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.ProjectsTable);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(767, 726);
            this.Name = "Overview";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Projects overview";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Overview_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.ProjectsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestersTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ProjectsTable;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button LinksButton;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.DataGridView TestersTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn available;
        private System.Windows.Forms.DataGridViewTextBoxColumn busy;
        private System.Windows.Forms.DataGridView StatsTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn allPassed;
        private System.Windows.Forms.DataGridViewTextBoxColumn failed;
        private System.Windows.Forms.DataGridViewTextBoxColumn inProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn cancelled;
        private System.Windows.Forms.DataGridViewTextBoxColumn you;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Button SearchButton;
    }
}