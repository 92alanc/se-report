using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string path = @"\\lgmcfs-sp\SW\CM\SE\TOOLS\SE Report\";

            if (SanityButton.Checked)
            {
                var directory = new System.IO.DirectoryInfo(@"\\lgmcfs-sp\SW\CM\SE\TOOLS\SE Report\");
                var files = directory.GetFiles("*.exe");
                var ordenedFiles = files.OrderBy(x => x.CreationTime);
                var lastFile = ordenedFiles.Last();

                //Verify if the program is in the last version
                    if (lastFile.Name != "SE Report " + Developers.VersionName + ".exe")
                    {
                        string msg = "New version is available. You must install the last version.";
                        DialogResult res = MessageBox.Show(msg, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (res == DialogResult.OK)
                        {
                            System.Diagnostics.Process.Start(path + lastFile.Name);
                            Application.Exit();
                        }
                        else
                        {
                            Application.Exit();
                        }
                

                    }
                    else
                    {
                        Sanity sanity = new Sanity();
                        this.Hide();
                        sanity.Show();
                    }
                

            }
            else if (sanityInternalButton.Checked)
            {
                var directory = new System.IO.DirectoryInfo(@"\\lgmcfs-sp\SW\CM\SE\TOOLS\SE Report\");
                var files = directory.GetFiles("*.exe");
                var ordenedFiles = files.OrderBy(x => x.CreationTime);
                var lastFile = ordenedFiles.Last();

                //Verify if the program is in the last version

                if (lastFile.Name != "SE Report " + Developers.VersionName + ".exe")
                {
                    string msg = "New version is available. You must install the last version.";
                    DialogResult res = MessageBox.Show(msg, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (res == DialogResult.OK)
                    {
                        System.Diagnostics.Process.Start(path + lastFile.Name);
                        Application.Exit();
                    }
                    else
                    {
                        Application.Exit();
                    }

                }
                else
                {
                    InternalTests internalTests = new InternalTests();
                    this.Hide();
                    internalTests.Show();
                }
            }
            else if (UnitButton.Checked)
            {
                var directory = new System.IO.DirectoryInfo(@"\\lgmcfs-sp\SW\CM\SE\TOOLS\SE Report\");
                var files = directory.GetFiles("*.exe");
                var ordenedFiles = files.OrderBy(x => x.CreationTime);
                var lastFile = ordenedFiles.Last();

                //Verify if the program is in the last version

                if (lastFile.Name != "SE Report " + Developers.VersionName + ".exe")
                {
                    string msg = "New version is available. You must install the last version.";
                    DialogResult res = MessageBox.Show(msg, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (res == DialogResult.OK)
                    {
                        System.Diagnostics.Process.Start(path + lastFile.Name);
                        Application.Exit();
                    }
                    else
                    {
                        Application.Exit();
                    }

                }
                else
                {
                    Unit unit = new Unit();
                    this.Hide();
                    unit.Show();
                }
            }
            else if (IssuesDBButton.Checked)
            {
                var directory = new System.IO.DirectoryInfo(@"\\lgmcfs-sp\SW\CM\SE\TOOLS\SE Report\");
                var files = directory.GetFiles("*.exe");
                var ordenedFiles = files.OrderBy(x => x.CreationTime);
                var lastFile = ordenedFiles.Last();

                //Verify if the program is in the last version

                if (lastFile.Name != "SE Report " + Developers.VersionName + ".exe")
                {
                    string msg = "New version is available. You must install the last version.";
                    DialogResult res = MessageBox.Show(msg, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (res == DialogResult.OK)
                    {
                        System.Diagnostics.Process.Start(path + lastFile.Name);
                        Application.Exit();
                    }
                    else
                    {
                        Application.Exit();
                    }

                }
                else
                {
                    IssuesDB issuesdb = new IssuesDB();
                    this.Hide();
                    issuesdb.Show();
                }
            }
            else if (QE0Button.Checked)
            {
                var directory = new System.IO.DirectoryInfo(@"\\lgmcfs-sp\SW\CM\SE\TOOLS\SE Report\");
                var files = directory.GetFiles("*.exe");
                var ordenedFiles = files.OrderBy(x => x.CreationTime);
                var lastFile = ordenedFiles.Last();

                //Verify if the program is in the last version

                if (lastFile.Name != "SE Report " + Developers.VersionName + ".exe")
                {
                    string msg = "New version is available. You must install the last version.";
                    DialogResult res = MessageBox.Show(msg, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (res == DialogResult.OK)
                    {
                        System.Diagnostics.Process.Start(path + lastFile.Name);
                        Application.Exit();
                    }
                    else
                    {
                        Application.Exit();
                    }

                }
                else
                {
                    QE0 qe0 = new QE0();
                    this.Hide();
                    qe0.Show();
                }
            }
            /*else if (OverviewButton.Checked)
            {
                Overview overview = new Overview();
                this.Hide();
                overview.Show();
            }*/
            else if (pendingButton.Checked)
            {
                var directory = new System.IO.DirectoryInfo(@"\\lgmcfs-sp\SW\CM\SE\TOOLS\SE Report\");
                var files = directory.GetFiles("*.exe");
                var ordenedFiles = files.OrderBy(x => x.CreationTime);
                var lastFile = ordenedFiles.Last();

                //Verify if the program is in the last version

                if (lastFile.Name != "SE Report " + Developers.VersionName + ".exe")
                {
                    string msg = "New version is available. You must install the last version.";
                    DialogResult res = MessageBox.Show(msg, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (res == DialogResult.OK)
                    {
                        System.Diagnostics.Process.Start(path + lastFile.Name);
                        Application.Exit();
                    }
                    else
                    {
                        Application.Exit();
                    }

                }
                else
                {
                    Pending pending = new Pending();
                    this.Hide();
                    pending.Show();
                }
            }
            else if (createDirectoryButton.Checked)
            {
                    CreateDirectory createDirectory = new CreateDirectory();
                    this.Hide();
                    createDirectory.Show();               
            }
            else if (AddTestsButton.Checked)
            {
                    AddTests addTests = new AddTests();
                    this.Hide();
                    addTests.Show();                
            }
            else if (CreateTemplateButton.Checked)
            {
                CreateTemplate createTemplate = new CreateTemplate();
                this.Hide();
                createTemplate.Show();
            }
            else if (ChecklistsButton.Checked)
            {
                var directory = new System.IO.DirectoryInfo(@"\\lgmcfs-sp\SW\CM\SE\TOOLS\SE Report\");
                var files = directory.GetFiles("*.exe");
                var ordenedFiles = files.OrderBy(x => x.CreationTime);
                var lastFile = ordenedFiles.Last();

                //Verify if the program is in the last version

                if (lastFile.Name != "SE Report " + Developers.VersionName + ".exe")
                {
                    string msg = "New version is available. You must install the last version.";
                    DialogResult res = MessageBox.Show(msg, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (res == DialogResult.OK)
                    {
                        System.Diagnostics.Process.Start(path + lastFile.Name);
                        Application.Exit();
                    }
                    else
                    {
                        Application.Exit();
                    }

                }
                else
                {
                    Checklists checklist = new Checklists();
                    this.Hide();
                    checklist.Show();
                }
            }
            /*else if (StatsButton.Checked)
            {
                Stats stats = new Stats();
                this.Hide();
                stats.Show();
            }*/
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
