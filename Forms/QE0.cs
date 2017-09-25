using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using SE_Report.Resources;

namespace SE_Report.Forms
{
    public partial class QE0 : Form
    {

        private string result;
        private DateTime start;
        //TesterList list = new TesterList();
        private bool passed;

        public QE0()
        {
            InitializeComponent();
            /*if (list.isEmpty())
            {
                list.refresh();
            }
            if (!list.getTester().isAvailable())
            {
                CancelButton.Visible = true;
                StartButton.Visible = false;
                FinishButton.Visible = true;
            }*/
        }

        /*
         * Parses the "getRelease" web page
         */
        public void GetData()
        {

            try
            {
                string path = PathBox.Text;
                char[] delimiterChars = { '\\' };
                char[] delimiterChars2 = { '_' };
                char[] delimiterChars3 = { '.' };
                char[] delimiterChars4 = { ':' };
                string[] parser = path.Split(delimiterChars);
                string id = null;
                string version = null;
                foreach (string s in parser)
                {
                    string[] parser2 = s.Split(delimiterChars2);
                    if (parser2[0].Equals("ID"))
                    {
                        id = parser2[1];
                    }
                }

                DateTime creation = File.GetCreationTime(path);
                DateTimeFormatInfo format = (new CultureInfo("en-GB")).DateTimeFormat;
                string creationDate = creation.ToString("G", format);

                string x = "http://10.193.225.22:9596/service.svc/getRelease?Chronosid=";
                string y = id;
                string all = string.Concat(x, y);
                WebClient client = new WebClient();
                string downloadString = client.DownloadString(all);

                string[] words = downloadString.Split(',');

                string final = null;

                string model = null;
                string buyer = null;
                string package = null;
                string cycle = null;
                string suffix = null;
                foreach (string s in words)
                {
                    string[] jsonkeys = s.Split(delimiterChars4);
                    final = string.Concat(final, "-", jsonkeys[0], "\n");
                    if (jsonkeys[0].Equals("\"Swv\"", StringComparison.OrdinalIgnoreCase)) // Version
                    {
                        version = jsonkeys[1].Split(',')[0].Split('\"')[1].Split('\"')[0];
                        if (!version.Equals(null))
                        {
                            model = version.Split('A')[0]; // Model
                        }
                    }
                    else if (jsonkeys[0].Equals("\"Cycle\"", StringComparison.OrdinalIgnoreCase)) // Cycle
                    {
                        cycle = jsonkeys[1].Split(',')[0].Split('\"')[1].Split('\"')[0];
                    }
                    else if (jsonkeys[0].Equals("{\"Buyer\"", StringComparison.OrdinalIgnoreCase)) // Buyer
                    {
                        buyer = jsonkeys[1].Split(',')[0].Split('\"')[1].Split('\"')[0];
                    }
                    else if (jsonkeys[0].Equals("\"Suffix\"", StringComparison.OrdinalIgnoreCase)) // Suffix
                    {
                        suffix = jsonkeys[1].Split(',')[0].Split('\"')[1].Split('\"')[0];
                    }
                    else if (jsonkeys[0].Equals("\"GpriPackage\"", StringComparison.OrdinalIgnoreCase)) // Package
                    {
                        if (jsonkeys[1].Contains("\"P"))
                        {
                            package = jsonkeys[2].Split('\"')[0];
                        }
                        else
                        {
                            package = jsonkeys[1].Split(',')[0].Split('\"')[1].Split('\"')[0];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
         * Creates the .html e-mail template
         */
        public void CreateTemplate()
        {

            string text = System.IO.File.ReadAllText(@"\\lgmcfs-sp\SW\CM\SE\TOOLS\DATABASE\new_reporte_template_qe0.html");
            text = text.Replace("::TYPE::", "VP0 Gate");
            text = text.Replace("::VERSION::", "");
            text = text.Replace("::RESULT::", htmlResult());
            text = text.Replace("::TESTER::", Environment.UserName);
            text = text.Replace("::COMMENTS::", "");
            text = text.Replace("::PATH::", IO.getTargetFolder());

            using (FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\QE0Template.html", FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.WriteLine(text);
                }
            }

            // Opens the saved html file
            System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\QE0Template.html");

        }

        /*
         * Returns the final result of the test (html format)
         */
        private string htmlResult()
        {
            switch (result)
            {
                case "ALL PASSED":
                    result = "<font color=\"green\">ALL PASSED</font>";
                    break;
                case "FAILED":
                    result = "<font color=\"red\">FAILED</font>";
                    break;
            }
            return result;
        }

        /// <summary>
        /// Passes the test
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PassButton_Click(object sender, EventArgs e)
        {
            try
            {
                passed = true;
                result = "ALL PASSED";
                //projectFinished();
                checkDirectory();
                CreateTemplate();
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Fails the test
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FailButton_Click(object sender, EventArgs e)
        {
            try
            {
                passed = false;
                result = "FAILED";
                //projectFinished();
                checkDirectory();
                CreateTemplate();
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Start button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_Click(object sender, EventArgs e)
        {
            /*StartButton.Visible = false;
            CancelButton.Visible = true;
            FinishButton.Visible = true;*/
            GetData();
            start = DateTime.Now;
            //newProject(getCreationDate());
            /*Reminder reminder = new Reminder();
            reminder.Show();
            reminder.showText(0, "qe0");
            IO.showDialogue(PathBox.Text.Substring(0, PathBox.Text.LastIndexOf("Documents") + 10), PathBox.Text); // + 10 to get the full path until ...technical documents\*/
        }

        /// <summary>
        /// Returns the time when the project has started
        /// </summary>
        /// <returns></returns>
        private string getTimeStarted()
        {
            DateTimeFormatInfo format = (new CultureInfo("en-GB").DateTimeFormat);
            return start.ToString("G", format);
        }

        /// <summary>
        /// Finish button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinishButton_Click(object sender, EventArgs e)
        {
            ResultsGroup.Visible = true;
            /*Reminder reminder = new Reminder();
            reminder.Show();
            reminder.showText(1, "qe0");*/
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
        /// Back button
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
        /// When a project is cancelled
        /// </summary>
        private void projectCancelled()
        {
            /*if (list.isEmpty())
            {
                list.refresh();
            }*/

            string dir = @"\\lgmcfs-sp\SW\CM\SE\TOOLS\NAO MEXER\Projects.xml";
            XmlDocument xml = new XmlDocument();
            xml.Load(dir);

            foreach (XmlElement element in xml.GetElementsByTagName("project"))
            {
                foreach (XmlElement element1 in xml.GetElementsByTagName("status"))
                {
                    if (element1.NextSibling.NextSibling.InnerText.Trim().Equals(getTimeStarted()))
                    {
                        element1.InnerText = "Cancelled";
                    }
                }
            }

            /*list.getTester().setAvailability(true);
            list.toXml();*/
            xml.Save(dir);

        }

        /*
         * Sets the current project as a new project
         */
        /*private void newProject(string creationDate)
        {
            /*if (list.isEmpty())
            {
                list.refresh();
            }

            Project project = new Project(this.Text, getTimeStarted(), creationDate, PathBox.Text, list.getTester().getName());
            project.setStatus("In progress");
            /*list.getTester().setAvailability(false);
            list.toXml();
        }*/

        /// <summary>
        /// Returns the creation date
        /// </summary>
        /// <returns></returns>
        private string getCreationDate()
        {
            DateTime creation = File.GetCreationTime(PathBox.Text);
            DateTimeFormatInfo format = (new CultureInfo("en-GB")).DateTimeFormat;
            return creation.ToString("G", format);
        }

        /*
         * Returns the final result of the test (xml format)
         */
        private string xmlResult()
        {
            string result;
            if (passed)
            {
                result = "ALL PASSED";
            }
            else
            {
                result = "FAILED";
            }
            return result;
        }

        /*
         * When a project is finished
         */
        private void projectFinished()
        {
            /*list.refresh();
            list.getTester().setAvailability(true);
            list.toXml();*/

            XmlDocument xml = new XmlDocument();
            string dir = @"\\lgmcfs-sp\SW\CM\SE\TOOLS\NAO MEXER\Projects.xml";
            xml.Load(dir);
            foreach (XmlElement element1 in xml.GetElementsByTagName("creationDate"))
            {
                if (element1.InnerText.Trim().Equals(getCreationDate().ToString()) && element1.NextSibling.InnerText.Trim().Equals(PathBox.Text) && element1.PreviousSibling.InnerText.Trim().Equals(getTimeStarted()))
                {
                    element1.PreviousSibling.PreviousSibling.PreviousSibling.InnerText = xmlResult();
                    break;
                }
            }
            xml.Save(dir);
        }

        /// <summary>
        /// Closes the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QE0_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            projectCancelled();
        }

        /// <summary>
        /// GPRI button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GPRIButton_Click(object sender, EventArgs e)
        {
            if (!PathBox.Text.Equals(""))
            {
                string path = PathBox.Text;
                char[] delimiterChars = { '\\' };
                char[] delimiterChars2 = { '_' };
                char[] delimiterChars3 = { '.' };
                char[] delimiterChars4 = { ':' };
                string[] parser = path.Split(delimiterChars);
                string id = null;
                foreach (string s in parser)
                {
                    string[] parser2 = s.Split(delimiterChars2);
                    if (parser2[0].Equals("ID"))
                    {
                        id = parser2[1];
                    }
                }

                string x = "http://10.193.225.22:9596/service.svc/getRelease?Chronosid=";
                string y = id;
                string all = string.Concat(x, y);
                WebClient client = new WebClient();
                string downloadString = client.DownloadString(all);

                string[] words = downloadString.Split(',');

                string final = null;

                string suffix = null;
                string model = null;
                string package = null;
                string buyer = "";

                foreach (string s in words)
                {
                    string[] jsonkeys = s.Split(delimiterChars4);
                    final = string.Concat(final, "-", jsonkeys[0], "\n");
                    if (jsonkeys[0].Equals("{\"Buyer\"", StringComparison.OrdinalIgnoreCase))
                    {
                        buyer = jsonkeys[1].Split(',')[0].Split('\"')[1].Split('\"')[0];
                    }
                    else if (jsonkeys[0].Equals("\"Model\"", StringComparison.OrdinalIgnoreCase)) // Model
                    {
                        model = jsonkeys[1].Split(',')[0].Split('\"')[1].Split('\"')[0];
                    }
                    else if (jsonkeys[0].Equals("\"GpriPackage\"", StringComparison.OrdinalIgnoreCase)) // Package
                    {
                        if (jsonkeys[1].Contains("\"P"))
                        {
                            package = jsonkeys[2].Split('\"')[0];
                        }
                        else
                        {
                            package = jsonkeys[1].Split(',')[0].Split('\"')[1].Split('\"')[0];
                        }
                    }
                    else if (jsonkeys[0].Equals("\"Suffix\"", StringComparison.OrdinalIgnoreCase))
                    {
                        suffix = jsonkeys[1].Split(',')[0].Split('\"')[1].Split('\"')[0];
                        if (!buyer.Contains("Unified"))
                        {
                            System.Diagnostics.Process.Start("http://gpri.lge.com/Views/View_GPRI/Default.aspx?suffix=" + suffix);
                        }
                        else
                        {
                            System.Diagnostics.Process.Start("http://gpri.lge.com/Views/View_GPRI/Default.aspx?");
                        }
                    }

                }
            }
            else
            {
                System.Diagnostics.Process.Start("http://gpri.lge.com/Views/View_GPRI/Default.aspx?");
            }
        }

        /// <summary>
        /// Checks if the chronos directory is ready for the report
        /// </summary>
        private void checkDirectory()
        {
            if (IO.dir_isReady(PathBox.Text, true))
            {
                DialogResult result = MessageBox.Show("This directory is ready to receive your report. Would you like to open?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    IO.openFolder();
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("This directory is not ready to receive your report. Would you like to create the subdirectories and open them?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    IO.createDirectories(this.Text, true);
                    IO.openFolder();
                }
            }
        }

    }
}
