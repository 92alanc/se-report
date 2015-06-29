namespace SE_Report.Forms
{
    partial class Pending
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pending));
            this.Table = new System.Windows.Forms.DataGridView();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.LinksButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            this.SuspendLayout();
            // 
            // Table
            // 
            this.Table.AllowUserToAddRows = false;
            this.Table.AllowUserToDeleteRows = false;
            this.Table.AllowUserToResizeColumns = false;
            this.Table.AllowUserToResizeRows = false;
            this.Table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Table.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table.Location = new System.Drawing.Point(12, 12);
            this.Table.Name = "Table";
            this.Table.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Table.Size = new System.Drawing.Size(737, 571);
            this.Table.TabIndex = 0;
            this.Table.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Table_DataBindingComplete);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RefreshButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RefreshButton.Image = global::SE_Report.Properties.Resources.Refresh2;
            this.RefreshButton.Location = new System.Drawing.Point(326, 589);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 61);
            this.RefreshButton.TabIndex = 100;
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // LinksButton
            // 
            this.LinksButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LinksButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LinksButton.Image = ((System.Drawing.Image)(resources.GetObject("LinksButton.Image")));
            this.LinksButton.Location = new System.Drawing.Point(673, 589);
            this.LinksButton.Name = "LinksButton";
            this.LinksButton.Size = new System.Drawing.Size(76, 61);
            this.LinksButton.TabIndex = 99;
            this.LinksButton.UseVisualStyleBackColor = true;
            this.LinksButton.Click += new System.EventHandler(this.LinksButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackButton.Image = ((System.Drawing.Image)(resources.GetObject("BackButton.Image")));
            this.BackButton.Location = new System.Drawing.Point(12, 589);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 61);
            this.BackButton.TabIndex = 98;
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // Pending
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 662);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.LinksButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.Table);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Pending";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pending projects";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Pending_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Table;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button LinksButton;
        private System.Windows.Forms.Button BackButton;
    }
}