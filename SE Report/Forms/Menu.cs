using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SE_Report.Forms
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void DevButton_Click(object sender, EventArgs e)
        {
            Developers dev = new Developers();
            this.Hide();
            dev.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            if (SanityButton.Checked)
            {
                Sanity sanity = new Sanity();
                this.Hide();
                sanity.Show();
            } 
            else if (UnitButton.Checked)
            {
                Unit unit = new Unit();
                this.Hide();
                unit.Show();
            }
            else if (IssuesDBButton.Checked)
            {
                IssuesDB issuesdb = new IssuesDB();
                this.Hide();
                issuesdb.Show();
            }
            else if (QE0Button.Checked)
            {
                QE0 qe0 = new QE0();
                this.Hide();
                qe0.Show();
            }
            else if (OverviewButton.Checked)
            {
                Overview overview = new Overview();
                this.Hide();
                overview.Show();
            }
            else if (PendingButton.Checked)
            {
                Pending pending = new Pending();
                this.Hide();
                pending.Show();
            }
            else if (StatsButton.Checked)
            {
                Stats stats = new Stats();
                this.Hide();
                stats.Show();
            }
            else
            {
                string msg = "You must select one of the options";
                MessageBox.Show(msg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
