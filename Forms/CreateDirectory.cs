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
using SE_Report.Resources;

namespace SE_Report.Forms
{
    public partial class CreateDirectory : Form
    {
      

        public CreateDirectory()
        {
            InitializeComponent();
        }


        private void CreateDirectory_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void createDirectoryButton_Click(object sender, EventArgs e)
        {


            string path = chronosPathBox.Text;


            if (sanityDirectory.Checked)
            {

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

                IO.targetFolder = getPathSanity;

                IO.openFolder();



            }

            if (vp0Directory.Checked)
            {

                string getPath‪vp0 = path.Remove(path.IndexOf("Technical"));



                getPath‪vp0 = getPath‪vp0 + @"RST\";
                if (!Directory.Exists(getPath‪vp0))
                {
                    Directory.CreateDirectory(getPath‪vp0);
                }

                getPath‪vp0 = getPath‪vp0 + @"02. Model Spec\";
                if (!Directory.Exists(getPath‪vp0))
                {
                    Directory.CreateDirectory(getPath‪vp0);
                }
                getPath‪vp0 = getPath‪vp0 + @"03. Operator Spec and Requirements\";
                if (!Directory.Exists(getPath‪vp0))
                {
                    Directory.CreateDirectory(getPath‪vp0);
                }

                IO.targetFolder = getPath‪vp0;
                IO.openFolder();
            }
        
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Menu startup = new Menu();
            this.Hide();
            startup.Show();
        }
    }
}


