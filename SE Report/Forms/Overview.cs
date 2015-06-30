using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using SE_Report.Resources;

namespace SE_Report.Forms
{
    public partial class Overview : Form
    {
        public Overview()
        {
            InitializeComponent();
            loadProjects();
            loadTesters();
        }

        private string projectsDir = @"\\lgmcfs-sp\SW\CM\SE\TOOLS\NAO MEXER\Projects.xml";
        private string testersDir = @"\\lgmcfs-sp\SW\CM\SE\TOOLS\NAO MEXER\Testers.xml";
        TesterList list = new TesterList();

        /// <summary>
        /// Opens the useful links window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinksButton_Click(object sender, EventArgs e)
        {
            Links links = new Links();
            links.Show();
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
        /// Refreshes the tables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            loadTesters();
            loadProjects();
        }

        /// <summary>
        /// Populates the projects table with xml data
        /// </summary>
        private void loadProjects()
        {

            try
            {
                XmlDocument xml = new XmlDocument();

                if (!File.Exists(projectsDir))
                {
                    XmlDeclaration declaration = xml.CreateXmlDeclaration("1.0", "UTF-8", null);
                    XmlElement root = xml.DocumentElement;
                    xml.InsertBefore(declaration, root);

                    XmlElement element1 = xml.CreateElement("projects");
                    xml.AppendChild(element1);

                    xml.Save(projectsDir);

                    MessageBox.Show("XML file containing all projects has been deleted. A new one has been created", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        ds.ReadXml(projectsDir);
                        if (ds.Tables.Count > 0)
                        {
                            ProjectsTable.DataSource = ds.Tables[0];
                            projectsSettings();
                        }
                    }
                    catch (XmlException e)
                    {
                        MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (IndexOutOfRangeException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentOutOfRangeException)
            {
                // Left it blank on purpose
            }
        }

        /// <summary>
        /// Projects stats
        /// </summary>
        private void stats()
        {
            int p = 0;
            int f = 0;
            int q = 0;
            int c = 0;
            int u = 0;

            StatsTable.RowCount = 1;

            for (int i = 0; i < ProjectsTable.RowCount; i++)
            {
                switch (ProjectsTable[0, i].Value.ToString())
                {
                    case "ALL PASSED":
                        p++;
                        break;
                    case "FAILED":
                        f++;
                        break;
                    case "In progress":
                        q++;
                        break;
                    case "Cancelled":
                        c++;
                        break;
                }

                if (ProjectsTable[5, i].Value.ToString().Equals(Environment.UserName))
                {
                    u++;
                }

                StatsTable[0, 0].Value = p.ToString();
                StatsTable[1, 0].Value = f.ToString();
                StatsTable[2, 0].Value = q.ToString();
                StatsTable[3, 0].Value = c.ToString();
                StatsTable[4, 0].Value = u.ToString();

            }
        }

        /// <summary>
        /// Populates the testers table with xml data
        /// </summary>
        private void loadTesters()
        {

            XmlDocument testers = new XmlDocument();
            testers.Load(testersDir);
            int a = 0;
            int b = 0;

            if (TestersTable.RowCount == 0)
            {
                for (int i = 0; i < testers.GetElementsByTagName("tester").Count; i++)
                {
                    TestersTable.RowCount++;
                }
            }

            try
            {
                foreach (XmlElement element in testers.GetElementsByTagName("status"))
                {
                    switch (element.InnerText.Trim())
                    {
                        case "Available":

                            TestersTable[0, a].Value = element.PreviousSibling.InnerText.Trim();
                            a++;
                            break;
                        case "Busy":
                            TestersTable[1, b].Value = element.PreviousSibling.InnerText.Trim();
                            b++;
                            break;
                    }
                }

                for (int i = 0; i < TestersTable.ColumnCount; i++)
                {
                    for (int j = 0; j < TestersTable.RowCount; j++)
                    {
                        if (i == 0)
                        {
                            if (TestersTable[i, j].Value == null && TestersTable[i + 1, j].Value == null)
                            {
                                TestersTable.RowCount--;
                            }
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentOutOfRangeException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Projects table settings
        /// </summary>
        private void projectsSettings()
        {
            // General settings
            ProjectsTable.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ProjectsTable.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            for (int i = 0; i < ProjectsTable.Columns.Count; i++)
            {
                ProjectsTable.Columns[i].ReadOnly = true;
                ProjectsTable.Columns[i].Resizable = DataGridViewTriState.False;
                ProjectsTable.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            ProjectsTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            ProjectsTable.Sort(ProjectsTable.Columns[2], ListSortDirection.Descending);

            // Columns
            ProjectsTable.Columns[0].Width = 120; // Status
            ProjectsTable.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            ProjectsTable.Columns[1].Width = 170; // Test type
            ProjectsTable.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            ProjectsTable.Columns[2].Width = 170; // Time started
            ProjectsTable.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            ProjectsTable.Columns[3].Width = 170; // Creation date
            ProjectsTable.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

            ProjectsTable.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Chronos path
            ProjectsTable.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            ProjectsTable.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

            ProjectsTable.Columns[5].Width = 190; // Assigned to
            ProjectsTable.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

            // Column headers
            ProjectsTable.Columns[0].HeaderText = "STATUS";
            ProjectsTable.Columns[1].HeaderText = "TEST TYPE";
            ProjectsTable.Columns[2].HeaderText = "TIME STARTED";
            ProjectsTable.Columns[3].HeaderText = "CREATION DATE";
            ProjectsTable.Columns[4].HeaderText = "CHRONOS PATH";
            ProjectsTable.Columns[5].HeaderText = "ASSIGNED TO";

            // Row header settings
            ProjectsTable.RowHeadersWidth = 90;

        }

        /// <summary>
        /// Changes cell colours according to value
        /// </summary>
        private void setColours()
        {
            for (int i = 0; i < ProjectsTable.RowCount; i++)
            {
                if (ProjectsTable[0, i].Value.Equals("Available"))
                {
                    ProjectsTable.Rows[i].Cells[0].Style.BackColor = Color.LightSkyBlue;
                    ProjectsTable.Rows[i].Cells[0].Style.ForeColor = Color.Black;
                }
                else if (ProjectsTable[0, i].Value.Equals("In progress")) // Status
                {
                    ProjectsTable.Rows[i].Cells[0].Style.BackColor = Color.Yellow;
                    ProjectsTable.Rows[i].Cells[0].Style.ForeColor = Color.Black;
                }
                else if (ProjectsTable[0, i].Value.Equals("ALL PASSED"))
                {
                    ProjectsTable.Rows[i].Cells[0].Style.BackColor = Color.Green;
                    ProjectsTable.Rows[i].Cells[0].Style.ForeColor = Color.White;
                }
                else if (ProjectsTable[0, i].Value.Equals("FAILED"))
                {
                    ProjectsTable.Rows[i].Cells[0].Style.BackColor = Color.Red;
                    ProjectsTable.Rows[i].Cells[0].Style.ForeColor = Color.White;
                }

                if (ProjectsTable[1, i].Value.Equals("Sanity")) // Test type
                {
                    ProjectsTable.Rows[i].Cells[1].Style.BackColor = Color.RoyalBlue;
                    ProjectsTable.Rows[i].Cells[1].Style.ForeColor = Color.White;
                }
                else if (ProjectsTable[1, i].Value.Equals("Unit"))
                {
                    ProjectsTable.Rows[i].Cells[1].Style.BackColor = Color.BurlyWood;
                    ProjectsTable.Rows[i].Cells[1].Style.ForeColor = Color.Black;
                }
                else if (ProjectsTable[1, i].Value.Equals("Issues DB"))
                {
                    ProjectsTable.Rows[i].Cells[1].Style.BackColor = Color.Peru;
                    ProjectsTable.Rows[i].Cells[1].Style.ForeColor = Color.Black;
                }
                else if (ProjectsTable[1, i].Value.Equals("QE0 Gate"))
                {
                    ProjectsTable.Rows[i].Cells[1].Style.BackColor = Color.Purple;
                    ProjectsTable.Rows[i].Cells[1].Style.ForeColor = Color.White;
                }

                if (ProjectsTable[5, i].Value.Equals(Environment.UserName)) // Assigned to
                {
                    ProjectsTable.Rows[i].Cells[5].Style.BackColor = Color.Lime;
                    ProjectsTable.Rows[i].Cells[5].Style.ForeColor = Color.Black;
                }

            }
        }

        /// <summary>
        /// Shows row numbers (projects)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjectsTable_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (gridView != null)
            {
                foreach (DataGridViewRow row in gridView.Rows)
                {
                    gridView.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
                }
            }
            setColours();
            stats();
        }

        /// <summary>
        /// Removes a project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this project?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                ProjectsTable.Refresh();
                XmlDocument xml = new XmlDocument();
                xml.Load(projectsDir);

                XmlDocument testers = new XmlDocument();
                testers.Load(testersDir);

                string user = Environment.UserName;

                try
                {
                    DataGridViewRow row = ProjectsTable.SelectedRows[0];

                    if (row.Cells[5].Value.Equals(user)) // Delete a project of yours
                    {

                        if (row.Cells[0].Value.Equals("In progress")) // Delete an ongoing project
                        {
                            foreach (XmlElement element in testers.GetElementsByTagName("id")) // Change the tester's availability
                            {
                                if (element.InnerText.Trim().Equals(user))
                                {
                                    element.NextSibling.NextSibling.InnerText = "Available";
                                    break;
                                }
                            }
                        }

                        XmlNode root = xml.SelectSingleNode("projects");

                        foreach (XmlElement element1 in xml.GetElementsByTagName("project")) // Remove the project from xml
                        {
                            if (element1.ChildNodes.Item(2).InnerText.Trim().Equals(row.Cells[2].Value))
                            {
                                root.RemoveChild(element1);
                                break;
                            }
                        }

                    }
                    else // Trying to delete someone else's project
                    {
                        MessageBox.Show("Only " + row.Cells[5].Value.ToString() + " has permission to delete this project", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("You must select an entire row in order to delete a project", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                if (list.isEmpty())
                {
                    list.refresh();
                }

                list.toXml();
                testers.Save(testersDir);
                xml.Save(projectsDir);
                loadProjects();
                loadTesters();
                TestersTable.Refresh();
            }
        }

        /// <summary>
        /// Search for a project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            search();
        }

        /// <summary>
        /// Closes the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Overview_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void SearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                search();
            }
        }

        /// <summary>
        /// Search
        /// </summary>
        private void search()
        {
            ProjectsTable.CurrentCell = null;

            foreach (DataGridViewRow row in ProjectsTable.Rows)
            {
                for (int i = 0; i < ProjectsTable.ColumnCount; i++)
                {
                    if (row.Cells[i].Value.ToString().ToLower().Contains(SearchBox.Text.ToLower()))
                    {
                        row.Visible = true;
                        break;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }

    }
}
