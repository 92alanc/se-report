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
    public partial class Stats : Form
    {
        public Stats()
        {
            InitializeComponent();
            loadData();
            sanitySettings();
            unitSettings();
            issuesSettings();
            qe0Settings();
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
        /// Useful links
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinksButton_Click(object sender, EventArgs e)
        {
            Links links = new Links();
            links.Show();
        }

        /// <summary>
        /// Loads all data
        /// </summary>
        private void loadData()
        {
            settings();

            XmlDocument xml = new XmlDocument();
            string dir = @"\\lgmcfs-sp\SW\CM\SE\TOOLS\NAO MEXER\Projects.xml";
            xml.Load(dir);

            int sanityP = 0;
            int sanityF = 0;
            int sanityC = 0;
            int unitP = 0;
            int unitF = 0;
            int unitC = 0;
            int issuesP = 0;
            int issuesF = 0;
            int issuesC = 0;
            int qeP = 0;
            int qeF = 0;
            int qeC = 0;

            foreach (XmlElement element in xml.GetElementsByTagName("testType"))
            {
                switch (element.InnerText)
                {
                    case "Sanity":

                        switch (element.PreviousSibling.InnerText)
                        {
                            case "ALL PASSED":
                                sanityP++;
                                break;
                            case "FAILED":
                                sanityF++;
                                break;
                            case "Cancelled":
                                sanityC++;
                                break;
                        }

                        break;
                    case "Unit":

                        switch (element.PreviousSibling.InnerText)
                        {
                            case "ALL PASSED":
                                unitP++;
                                break;
                            case "FAILED":
                                unitF++;
                                break;
                            case "Cancelled":
                                unitC++;
                                break;
                        }

                        break;
                    case "Issues DB":

                        switch (element.PreviousSibling.InnerText)
                        {
                            case "ALL PASSED":
                                issuesP++;
                                break;
                            case "FAILED":
                                issuesF++;
                                break;
                            case "Cancelled":
                                issuesC++;
                                break;
                        }

                        break;
                    case "QE0 Gate":

                        switch (element.PreviousSibling.InnerText)
                        {
                            case "ALL PASSED":
                                qeP++;
                                break;
                            case "FAILED":
                                qeF++;
                                break;
                            case "Cancelled":
                                qeC++;
                                break;
                        }

                        break;
                }
            }

            Table[0, 0].Value = sanityP.ToString(); // Sanity + ALL PASSED
            Table[1, 0].Value = unitP.ToString(); // Unit + ALL PASSED
            Table[2, 0].Value = issuesP.ToString(); // Issues DB + ALL PASSED
            Table[3, 0].Value = qeP.ToString(); // QE0 + ALL PASSED

            Table[0, 1].Value = sanityF.ToString(); // Sanity + FAILED
            Table[1, 1].Value = unitF.ToString(); // Unit + FAILED
            Table[2, 1].Value = issuesF.ToString(); // Issues DB + FAILED
            Table[3, 1].Value = qeF.ToString(); // QE0 + FAILED

            Table[0, 2].Value = sanityC.ToString(); // Sanity + Cancelled
            Table[1, 2].Value = unitC.ToString(); // Unit + Cancelled
            Table[2, 2].Value = issuesC.ToString(); // Issues DB + Cancelled
            Table[3, 2].Value = qeC.ToString(); // QE0 + Cancelled

        }

        /// <summary>
        /// Table settings
        /// </summary>
        private void settings()
        {
            Table.RowCount = 3;

            DataGridViewRow allPassed = Table.Rows[0];
            DataGridViewRow failed = Table.Rows[1];
            DataGridViewRow cancelled = Table.Rows[2];

            allPassed.HeaderCell.Value = "ALL PASSED";
            failed.HeaderCell.Value = "FAILED";
            cancelled.HeaderCell.Value = "Cancelled";
        }

        /// <summary>
        /// When the user clicks the 'x' button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stats_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Refreshes the table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            loadData();
        }

        /// <summary>
        /// Sanity chart settings
        /// </summary>
        private void sanitySettings()
        {
            sanityChart.Series[0].Points.AddY(Table[0, 0].Value);
            sanityChart.Series[1].Points.AddY(Table[0, 1].Value);
            sanityChart.Series[2].Points.AddY(Table[0, 2].Value);
        }

        /// <summary>
        /// Unit chart settings
        /// </summary>
        private void unitSettings()
        {
            unitChart.Series[0].Points.AddY(Table[1, 0].Value);
            unitChart.Series[1].Points.AddY(Table[1, 1].Value);
            unitChart.Series[2].Points.AddY(Table[1, 2].Value);
        }

        /// <summary>
        /// Issues DB chart settings
        /// </summary>
        private void issuesSettings()
        {
            issuesChart.Series[0].Points.AddY(Table[2, 0].Value);
            issuesChart.Series[1].Points.AddY(Table[2, 1].Value);
            issuesChart.Series[2].Points.AddY(Table[2, 2].Value);
        }

        /// <summary>
        /// QE0 Gate chart settings
        /// </summary>
        private void qe0Settings()
        {
            qe0Chart.Series[0].Points.AddY(Table[3, 0].Value);
            qe0Chart.Series[1].Points.AddY(Table[3, 1].Value);
            qe0Chart.Series[2].Points.AddY(Table[3, 2].Value);
        }

    }
}
