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
    public partial class Links : Form
    {

        public Links()
        {
            InitializeComponent();
        }

        // GPRI
        private void GPRILink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://sso.lge.com/eplogin.fcc?TYPE=33554432&REALMOID=06-529f9a8e-16db-1019-8715-855d840e0000&GUID=&SMAUTHREASON=0&METHOD=GET&SMAGENTNAME=-SM-XqmjgrHj%2faMoFjcnaZrLies2l%2f6wCJpVM%2begdzcM%2fpVLcxDiddJLfpHNDlR%2ba2zO&TARGET=-SM-HTTP%3a%2f%2fgpri%2elge%2ecom%2fViews%2fShared%2fLogin%2easpx%3fReturnUrl%3d-%2fViews-%2fView_GPRI-%2f");
        }

        // Models
        private void ModelsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://collab.lge.com/main/display/SCAI/05.+MT+-+Models");
        }

        // RBS Calendar
        private void CalendarLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://10.193.225.22:9595/");
        }

        // RBS Test Sets
        private void TestSetsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://10.193.225.22:9595/TestSet/Index");
        }

        // NT code list
        private void NTCodeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://collab.lge.com/main/display/~gihoon.jang/NT+Code+List");
        }

        // MCC/MNC list
        private void MCCMNCLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://en.wikipedia.org/wiki/Mobile_country_code");
        }

        // TD
        private void TDLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "http://td3.lge.com/qcbin/start_a.jsp");
        }

        // EAD
        private void EADLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://136.166.97.136/login/index.php");
        }

        // MLM
        private void MLMLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://mlm.lge.com/di/browse/SCACM");
        }

    }

}
