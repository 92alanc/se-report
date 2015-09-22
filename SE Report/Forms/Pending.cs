using System;
using System.Data;
using System.Drawing;
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
            catch (IndexOutOfRangeException)
            {
                // Irrelevant exception: left blank on purpose
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

            for (int i = 0; i < Table.RowCount; i++)
            {
                if (Table[4, i].Value.ToString().Contains(">>>"))
                {
                    Table[4, i].Value = Table[4, i].Value.ToString().Replace(">>>", "");
                }
            }

            Table.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            Table.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            DataGridViewColumn status = Table.Columns[0]; // level
            DataGridViewColumn testType = Table.Columns[1]; // test type
            DataGridViewColumn creationDate = Table.Columns[2]; // creation date
            DataGridViewColumn chronos = Table.Columns[3]; // chronos
            DataGridViewColumn unit = Table.Columns[4]; // unit

            status.Width = 120;
            status.HeaderText = "LEVEL";

            testType.Width = 110;
            testType.HeaderText = "TEST TYPE";

            creationDate.Width = 210;
            creationDate.HeaderText = "CREATION DATE";

            chronos.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            chronos.HeaderText = "CHRONOS PATH";

            unit.Width = 210;
            unit.HeaderText = "UNIT";
            unit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

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
                switch (Table[0, i].Value.ToString())
                {
                    case "NEW":
                        Table.Rows[i].Cells[0].Style.BackColor = Color.Lime;
                        break;
                    case "UPDATE":
                        Table.Rows[i].Cells[0].Style.BackColor = Color.Yellow;
                        break;
                }
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
                bool ok = false;
                string id = null, id2 = null;
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    if (gridView[0, i].Value.ToString().ToLower().Equals("update"))
                    {
                        for (int j = 0; j < gridView.RowCount; j++)
                        {
                            id = gridView[3, j].Value.ToString().Split('_')[1].Split('\\')[0];
                            id2 = gridView[3, i].Value.ToString().Split('_')[1].Split('\\')[0];
                            if (!gridView[2, j].Value.ToString().Equals(gridView[2, i].Value.ToString()) && id.Equals(id2))
                            {
                                gridView.Rows[j].Selected = true;
                                gridView.Rows.Remove(gridView.SelectedRows[0]);
                                XmlDocument xml = new XmlDocument();
                                xml.Load(@"\\lgmcfs-sp\SW\CM\SE\TOOLS\NAO MEXER\Pending.xml");
                                XmlNode root = xml.SelectSingleNode("projects");
                                root.RemoveChild(root.ChildNodes.Item(j));
                                xml.Save(@"\\lgmcfs-sp\SW\CM\SE\TOOLS\NAO MEXER\Pending.xml");
                                ok = true;
                                break;
                            }
                        }
                        if (ok)
                        {
                            break;
                        }
                    }
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
