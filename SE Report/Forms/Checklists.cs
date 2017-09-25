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
    public partial class Checklists : Form
    {
        public Checklists()
        {
            InitializeComponent();
        }


        private void Checklists_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (RNDButton.Checked)
            {
                RndSelfChecklist rnd = new RndSelfChecklist();
                this.Hide();
                rnd.Show();
                
            }
            else if (afwButton.Checked)
            {
                AFW_Checklist afw = new AFW_Checklist();
                this.Hide();
                afw.Show();
                
            }
            else if (efuseButton.Checked)
            {
                EfuseChecklist efuse = new EfuseChecklist();
                this.Hide();
                efuse.Show();
            }
            else if (qfuseButton.Checked)
            {
                QfuseChecklist qfuse = new QfuseChecklist();
                this.Hide();
                qfuse.Show();
            }
            else if (CodenameButton.Checked)
            {
                CodenameChecklist codename = new CodenameChecklist();
                this.Hide();
                codename.Show();
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }
    }
}
