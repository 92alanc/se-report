using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SE_Report.Forms
{
    public partial class Pending : Form
    {
        public Pending()
        {
            InitializeComponent();
            loadProjects();
        }

        /// <summary>
        /// When the user clicks the 'x' button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pending_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Goes back to main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }

        /// <summary>
        /// Loads all pending projects
        /// </summary>
        private void loadProjects()
        {
            try
            {
                string dir = @"\\lgmcfs-sp\SW\CM\SE\TOOLS\NAO MEXER\Pending.xml";
                DataSet ds = new DataSet();
                ds.ReadXml(dir);
                if (ds.Tables.Count > 0)
                {
                    Table.DataSource = ds.Tables[0];
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Table settings
        /// </summary>
        private void settings()
        {
            for (int i = 0; i < Table.ColumnCount; i++)
            {
                Table.Columns[i].ReadOnly = true;
                Table.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                if (i != 3)
                {
                    Table.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    Table.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }

            Table.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            Table.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            DataGridViewColumn status = Table.Columns[0]; // status
            DataGridViewColumn testType = Table.Columns[1]; // test type
            DataGridViewColumn creationDate = Table.Columns[2]; // creation date
            DataGridViewColumn chronos = Table.Columns[3]; // chronos
            DataGridViewColumn assignedTo = Table.Columns[4]; // assigned to

            status.DefaultCellStyle.BackColor = Color.Lime;
            status.Width = 120;
            status.HeaderText = "STATUS";

            testType.Width = 110;
            testType.HeaderText = "TEST TYPE";

            creationDate.Width = 210;
            creationDate.HeaderText = "CREATION DATE";

            chronos.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            chronos.HeaderText = "CHRONOS PATH";

            assignedTo.Visible = false;

            Table.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Table.RowHeadersWidth = 60;
            
        }

        /// <summary>
        /// Sets cell colours according to their value
        /// </summary>
        private void setColours()
        {
            for (int i = 0; i < Table.RowCount; i++)
            {
                if (Table[1, i].Value.Equals("SANITY")) // Test type
                {
                    Table.Rows[i].Cells[1].Style.BackColor = Color.RoyalBlue;
                    Table.Rows[i].Cells[1].Style.ForeColor = Color.White;
                }
                else if (Table[1, i].Value.Equals("UNIT"))
                {
                    Table.Rows[i].Cells[1].Style.BackColor = Color.BurlyWood;
                    Table.Rows[i].Cells[1].Style.ForeColor = Color.Black;
                }
                else if (Table[1, i].Value.Equals("ISSUES DB"))
                {
                    Table.Rows[i].Cells[1].Style.BackColor = Color.Peru;
                    Table.Rows[i].Cells[1].Style.ForeColor = Color.Black;
                }
                else if (Table[1, i].Value.Equals("QE0"))
                {
                    Table.Rows[i].Cells[1].Style.BackColor = Color.Chocolate;
                    Table.Rows[i].Cells[1].Style.ForeColor = Color.White;
                }
            }
        }

        /// <summary>
        /// When all data is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Table_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (gridView != null)
            {
                foreach (DataGridViewRow row in gridView.Rows)
                {
                    gridView.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
                }
            }
            settings();
            setColours();
        }

        /// <summary>
        /// Refreshes the table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            loadProjects();
        }

        /// <summary>
        /// Useful links
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinksButton_Click(object sender, EventArgs e)
        {
            Links links = new Links();
            links.Show();
        }

    }
}
