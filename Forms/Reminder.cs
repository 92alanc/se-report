using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SE_Report.Forms
{
    public partial class Reminder : Form
    {

        public Reminder()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Displays the chosen text on the Reminder form
        /// </summary>
        /// <param name="index"></param>
        /// <param name="testType"></param>
        public void showText(int index, string testType)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(@"\\lgmcfs-sp\SW\CM\SE\TOOLS\NAO MEXER\Reminder.xml");
            switch (index)
            {
                case 0:
                    XmlNodeList list = xml.SelectSingleNode("root/start/" + testType.ToLower()).ChildNodes;
                    StringBuilder sb = new StringBuilder();
                    int i = 1;
                    foreach (XmlElement element in list)
                    {
                        sb.Append(i + ". " + element.InnerText + Environment.NewLine);
                        i++;
                    }
                    textBox1.Text = sb.ToString();
                    break;
                case 1:
                    XmlNodeList list2 = xml.SelectSingleNode("root/end/" + testType.ToLower()).ChildNodes;
                    StringBuilder sb2 = new StringBuilder();
                    int j = 1;
                    foreach (XmlElement element in list2)
                    {
                        sb2.Append(j + ". " + element.InnerText + Environment.NewLine);
                        j++;
                    }
                    textBox1.Text = sb2.ToString();
                    break;
                default:
                    textBox1.Text = "";
                    break;
            }
        }

    }
}
