using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_Report.Forms
{
    public partial class Developers : Form
    {

        public const string VersionName = "9.1.2";



        public Developers()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Menu startup = new Menu();
            this.Hide();
            startup.Show();
        }

        private void Developers_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
