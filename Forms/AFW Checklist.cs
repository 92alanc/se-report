using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_Report.Forms
{
    public partial class AFW_Checklist : Form
    {
        public AFW_Checklist()
        {
            InitializeComponent();
        }


        private void AFW_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }





        /*
        * Starts the Checklist
        */
        private void StartChecklist()
        {



            //Create directory
            string path = chronosPathBox.Text;
            string getPathSanity = path.Remove(path.IndexOf("Technical"));



            getPathSanity = getPathSanity + @"RST\";
            if (!Directory.Exists(getPathSanity))
            {
                Directory.CreateDirectory(getPathSanity);
            }

            getPathSanity = getPathSanity + @"01. General Information\";
            if (!Directory.Exists(getPathSanity))
            {
                Directory.CreateDirectory(getPathSanity);
            }
            getPathSanity = getPathSanity + @"05. Test Results\";
            if (!Directory.Exists(getPathSanity))
            {
                Directory.CreateDirectory(getPathSanity);
            }





            //Get file in the database folder
            string getPath = path.Remove(path.IndexOf("Technical"));
            string getChronosPath = getPathSanity;
            string filepath = @"\\lgmcfs-sp\SW\CM\SE\TOOLS\DATABASE\Checklists\AfwChecklist\";
            DirectoryInfo d = new DirectoryInfo(filepath);
            string sheetPath = "";

            foreach (var file in d.GetFiles("*.xlsx"))
            {
                getChronosPath = getChronosPath + file.Name;
                sheetPath = filepath + file.Name;

            }



            //Verify if file is already in the folder
            int afw = 0;
            foreach (string f in Directory.GetFiles(getPathSanity))
            {

                if (f.ToLower().Contains("afw"))
                {
                    afw = 1;
                }
            }



            //Copy file and open
            if (afw == 1)
            {
                string msg = "The file already exists";
                DialogResult res = MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                System.Diagnostics.Process.Start(getPathSanity);
            }
            else
            {
                System.Diagnostics.Process.Start(getPathSanity);
                File.Copy(sheetPath, getChronosPath);
                System.Diagnostics.Process.Start(getChronosPath);
            }
        }






        private void Back_Click_1(object sender, EventArgs e)
        {
            Checklists checklist = new Checklists();
            this.Hide();
            checklist.Show();
        }

        private void Start_Click_1(object sender, EventArgs e)
        {
            StartChecklist();
        }
    }
}
