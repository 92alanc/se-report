using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Xml;
using System.Net;
using SE_Report.Resources;
using System.Globalization;

namespace SE_Report.Forms
{
    public partial class Sanity : Form
    {

        private string timeStarted;
        TesterList list = new TesterList();

        /*
         * Initialises the frame
         * Reads the .xml file containing all test cases
         */
        public Sanity()
        {
            try
            {
                InitializeComponent();
                TestCases();
            }
            catch (Exception)
            {
                MessageBox.Show("Network address not found. Please check your network and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
         * Reads the.xml file containing all test cases
         */
        private void TestCases()
        {
            XmlReader xmlFile;
            FileStream fs = new FileStream(@"\\lgmcfs-sp\SW\CM\SE\TOOLS\NAO MEXER\Sanity.xml", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            xmlFile = XmlReader.Create(fs, new XmlReaderSettings());

            DataSet ds = new DataSet();
            ds.ReadXml(xmlFile);

            Table.DataSource = ds.Tables[0];

            // Test case
            Table.Columns[0].Width = 300;
            Table.Columns[0].Resizable = DataGridViewTriState.False;
            Table.Columns[0].ReadOnly = true;
            Table.Columns[0].HeaderText = "TEST CASE";
            Table.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Table.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            Table.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Description
            Table.Columns[1].Width = 600;
            Table.Columns[1].Resizable = DataGridViewTriState.True;
            Table.Columns[1].ReadOnly = true;
            Table.Columns[1].HeaderText = "DESCRIPTION";
            Table.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Table.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            Table.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
            Table.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Results
            DataGridViewComboBoxColumn Results = new DataGridViewComboBoxColumn();
            Results.MaxDropDownItems = 4;
            Results.HeaderText = "RESULT";
            Results.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Results.Items.Add("PASSED");
            Results.Items.Add("N/A");
            Results.Items.Add("FAILED");
            Results.Items.Add("NOT TESTED");
            Results.Width = 130;
            Results.Resizable = DataGridViewTriState.False;
            Results.SortMode = DataGridViewColumnSortMode.NotSortable;
            Results.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            Table.Columns.Add(Results);

            // Comments
            DataGridViewTextBoxColumn Comments = new DataGridViewTextBoxColumn();
            Comments.HeaderText = "COMMENTS";
            Comments.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Comments.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Comments.SortMode = DataGridViewColumnSortMode.NotSortable;
            Comments.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            Table.Columns.Add(Comments);

            // Refresher
            Timer Refresher = new Timer();
            Refresher.Interval = 1;
            Refresher.Enabled = true;
        }

        /*
         * Returns the time when the project has started
         */
        private string getTimeStarted()
        {
            DateTime now = DateTime.Now;
            DateTimeFormatInfo format = (new CultureInfo("en-GB")).DateTimeFormat;
            string timeStarted = now.ToString("G", format);
            this.timeStarted = timeStarted;
            return timeStarted;
        }

        /// <summary>
        /// When a project is cancelled
        /// </summary>
        private void projectCancelled()
        {
            if (list.isEmpty())
            {
                list.refresh();
            }

            string dir = @"\\lgmcfs-sp\SW\CM\SE\TOOLS\NAO MEXER\Projects.xml";
            XmlDocument xml = new XmlDocument();
            xml.Load(dir);

            foreach (XmlElement element in xml.GetElementsByTagName("project"))
            {
                foreach (XmlElement element1 in xml.GetElementsByTagName("status"))
                {
                    if (element1.NextSibling.NextSibling.InnerText.Equals(timeStarted))
                    {
                        element1.InnerText = "Cancelled";
                    }
                }
            }

            list.getTester().setAvailability(true);
            list.toXml();
            xml.Save(dir);

        }

        /*
         * Back to main menu
         */
        private void BackButton_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            if (((string)PathBox.Text != "" || (string)CreationDateBox.Text != "" || (string)NTCodeBox.Text != "") && Stopwatch2.Enabled == true)
            {
                string msg = "Some changes have been made. Are you sure you want to exit?";
                DialogResult res = MessageBox.Show(msg, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    projectCancelled();
                    Stopwatch2.Enabled = false;
                    this.Hide();
                    menu.Show();
                }
            }
            else
            {
                Stopwatch2.Enabled = false;
                this.Hide();
                menu.Show();
            }
        }

        /*
         * Finishes the test
         */
        private void FinishButton_Click(object sender, EventArgs e)
        {

            if (TestsLeft() > 0) // Tests yet to be done
            {
                string single = "There is still 1 test to be done. Please finish it before saving.";
                string multiple = "There are still " + TestsLeft() + " tests to be done. Please finish them before saving.";
                if (TestsLeft() == 1)
                {
                    MessageBox.Show(single, "Test incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(multiple, "Test incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (!VersionBox.Text.StartsWith("LG") || !VersionBox.Text.Contains("+"))
            {
                MessageBox.Show("Invalid software version name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VersionBox.ReadOnly = false;
            }
            else
            {
                Stopwatch.Enabled = false;
                Stopwatch2.Enabled = false;
                timer1.Enabled = false;
                PDF();
                CreateTemplate();
                projectFinished();
            }
        }

        /*
         * Generates the .pdf report
         */
        private void PDF()
        {
            Paragraph line = new Paragraph("\n____________________________________________________________________________\n\n");
            string minutes = " minutes";
            if (Minutes.Text.Equals("1"))
            {
                minutes = " minute";
            }
            else if (Minutes.Text.Equals("00"))
            {
                Minutes.Text = "1";
                minutes = " minute";
            }

            // Header elements
            string sw = "Software version: " + VersionBox.Text;
            Paragraph swv = new Paragraph(sw + "\n\n");
            swv.Font.Size = 12;
            swv.Font.SetFamily("Times new roman");
            PdfPCell model = new PdfPCell(new Phrase("Model: " + ModelBox.Text + "   Cycle: " + CycleBox.Text));
            PdfPCell buyer = new PdfPCell(new Phrase("Buyer: " + BuyerBox.Text + "    " + PackageBox.Text));
            PdfPCell creation = new PdfPCell(new Phrase("Creation date: " + CreationDateBox.Text));
            PdfPCell time = new PdfPCell(new Phrase("Elapsed time: " + Minutes.Text + minutes));
            Paragraph tester = new Paragraph("Tester: " + Environment.UserName);
            Paragraph ntcode = new Paragraph("NT code: " + NTCodeBox.Text);

            // Header
            PdfPTable header = new PdfPTable(2);
            header.WidthPercentage = 100;
            float[] widths2 = { 60, 80 };
            header.SetWidths(widths2);
            header.AddCell(model);
            header.AddCell(buyer);
            header.AddCell(creation);
            header.AddCell(time);

            // Stats
            string space3 = "   ";
            Paragraph stats = new Paragraph("Test summary\nPassed: " + PassedDisplay.Text + space3 + "N/A: " + NADisplay.Text + space3 + "Not tested: " + NotTestedDisplay.Text + space3 + "Failed: " + FailedDisplay.Text + "\n\n");
            stats.Font.SetFamily("Times new roman");
            stats.Font.Size = 15;
            stats.Alignment = Element.ALIGN_CENTER;

            // PDF table
            PdfPTable sheet = new PdfPTable(Table.Columns.Count - 1);
            sheet.WidthPercentage = 100;
            float[] widths = { 30, 20, 60 };
            sheet.SetWidths(widths);

            // Copy column headers to PDF - had to add them manually, otherwise they go to the pdf shuffled
            PdfPCell testCase = new PdfPCell(new Phrase(Table.Columns[2].HeaderText.ToUpper())); // Test case
            testCase.HorizontalAlignment = Element.ALIGN_CENTER;
            sheet.AddCell(testCase); // Column headers
            PdfPCell result = new PdfPCell(new Phrase(Table.Columns[0].HeaderText.ToUpper())); // Result
            result.HorizontalAlignment = Element.ALIGN_CENTER;
            sheet.AddCell(result);
            PdfPCell comments = new PdfPCell(new Phrase(Table.Columns[1].HeaderText.ToUpper())); // Comments
            comments.HorizontalAlignment = Element.ALIGN_CENTER;
            sheet.AddCell(comments);

            sheet.HeaderRows = 1; // Making sure the 1st row is the one with the column headers

            // Copies the rows contents to PDF and changes the "RESULT" column's cells according to test cases results
            for (int j = 0; j < Table.Rows.Count; j++)
            {
                // Exports cell contents to PDF
                if (Table[2, j].Value != null)
                {
                    sheet.DefaultCell.BackgroundColor = BaseColor.WHITE;
                    sheet.AddCell(new Phrase(Table[2, j].Value.ToString())); // If the contents aren't empty, export to PDF
                }
                else
                {
                    sheet.DefaultCell.BackgroundColor = BaseColor.WHITE;
                    sheet.AddCell(new Phrase("")); // If the contents are empty, copy "" (empty string) to PDF
                }
                if (Table[0, j].Value != null)
                {
                    if ((string)Table[0, j].Value == "PASSED")
                    {
                        sheet.DefaultCell.BackgroundColor = BaseColor.GREEN;
                        sheet.AddCell(new Phrase(Table[0, j].Value.ToString()));
                    }
                    else if ((string)Table[0, j].Value == "N/A")
                    {
                        sheet.DefaultCell.BackgroundColor = BaseColor.YELLOW;
                        sheet.AddCell(new Phrase(Table[0, j].Value.ToString()));
                    }
                    else if ((string)Table[0, j].Value == "FAILED")
                    {
                        sheet.DefaultCell.BackgroundColor = BaseColor.RED;
                        sheet.AddCell(new Phrase(Table[0, j].Value.ToString()));
                    }
                    else if ((string)Table[0, j].Value == "NOT TESTED")
                    {
                        sheet.DefaultCell.BackgroundColor = BaseColor.GRAY;
                        sheet.AddCell(new Phrase(Table[0, j].Value.ToString()));
                    }
                }
                else
                {
                    sheet.DefaultCell.BackgroundColor = BaseColor.WHITE;
                    sheet.AddCell(new Phrase("")); // If the contents are empty, copy "" (empty string) to PDF
                }
                if (Table[1, j].Value != null)
                {
                    sheet.DefaultCell.BackgroundColor = BaseColor.WHITE;
                    sheet.AddCell(new Phrase(Table[1, j].Value.ToString())); // If the contents aren't empty, export to PDF
                }
                else
                {
                    sheet.DefaultCell.BackgroundColor = BaseColor.WHITE;
                    sheet.AddCell(new Phrase("")); // If the contents are empty, copy "" (empty string) to PDF
                }
            }

            // PDF settings
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 50, 50, 42, 35); // Numbers = margins (left, right, up, down)

            try
            {
                // Sanity logo
                string JPGpath = AppDomain.CurrentDomain.BaseDirectory.ToString();
                string FileName = "Sanity Logo.jpg";
                iTextSharp.text.Image SanityLogo = iTextSharp.text.Image.GetInstance(JPGpath + "\\" + FileName);
                SanityLogo.ScaleToFit(150f, 70f);
                SanityLogo.SpacingBefore = 10f;
                SanityLogo.SpacingAfter = 1f;
                SanityLogo.Alignment = Element.ALIGN_CENTER;

                // LG logo
                string FileName2 = "LG Logo.jpg";
                iTextSharp.text.Image LGLogo = iTextSharp.text.Image.GetInstance(JPGpath + "\\" + FileName2);
                LGLogo.ScaleToFit(120f, 80f);
                LGLogo.SpacingBefore = 10f;
                LGLogo.SpacingAfter = 1f;
                LGLogo.Alignment = Element.ALIGN_LEFT;

                // Saves the PDF as SANITY REPORT - (software version)
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "SANITY REPORT - " + VersionBox.Text + ".pdf";
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));

                // Exports all to PDF
                doc.Open();
                doc.Add(LGLogo);
                doc.Add(SanityLogo);
                doc.Add(line);
                doc.Add(swv);
                doc.Add(header);
                doc.Add(tester);
                doc.Add(ntcode);
                doc.Add(line);
                doc.Add(stats);
                doc.Add(sheet);
                doc.Close();

                // Confirmation message
                string msg = "Report generated successfully!\nDirectory -> " + path;
                MessageBox.Show(msg, "Report saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Opens the saved .pdf file
                System.Diagnostics.Process.Start(path);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Error message
            }
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
                string cd = creation.ToString("G", format);

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

                XmlDocument xml = new XmlDocument();
                xml.Load(@"\\lgmcfs-sp\SW\CM\SE\TOOLS\NAO MEXER\NTCodes.xml");
                XmlNodeList list = xml.SelectNodes("ntcodes/" + suffix);
                string ntcode = null;

                foreach (XmlNode node in list)
                {
                    if (node.Name.Equals(suffix))
                    {
                        ntcode = node.InnerText.ToString();
                    }
                }

                if (suffix.Equals("BRA"))
                {
                    DialogResult result = MessageBox.Show("Brazil Open projects come with the non-global release NT code by default (34), would you like to change it to global release (31)?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        ntcode = "\"1\",\"FFF,FFF,FFFFFFFF,FFFFFFFF,31\"";
                    }
                }

                // Sets the text boxes contents
                VersionBox.Text = version;
                ModelBox.Text = model;
                BuyerBox.Text = buyer;
                CycleBox.Text = cycle;
                PackageBox.Text = package;
                CreationDateBox.Text = cd;
                if (!(suffix.Equals("TFH") && model.Contains("H635")))
                {
                    NTCodeBox.Text = ntcode;
                }
                else
                {
                    NTCodeBox.ReadOnly = false;
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

            string text = System.IO.File.ReadAllText(@"\\lgmcfs-sp\SW\CM\SE\TOOLS\NAO MEXER\report_template.html");
            text = text.Replace("::TYPE::", "Sanity");
            text = text.Replace("::VERSION::", VersionBox.Text);
            text = text.Replace("::RESULT::", htmlResult());
            text = text.Replace("::TESTER::", Environment.UserName);
            text = text.Replace("::COMMENTS::", Comments());
            text = text.Replace("::PATH::", "");

            using (FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\SanityTemplate.html", FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.WriteLine(text);
                }
            }

            // Opens the saved html file
            System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\SanityTemplate.html");

        }

        /*
         * Start button
         * Displays all test cases imported from .xml in the spreadsheet and starts the stopwatch
         */
        private void StartButton_Click(object sender, EventArgs e)
        {
            // Blank fields
            if ((string)PathBox.Text == "")
            {
                MessageBox.Show("You must fill in the Chronos path text box", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!PathBox.Text.StartsWith(@"\\lgmcfs-sp\ChronosStorage\"))
            {
                MessageBox.Show("Invalid Chronos path", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                GetData();
                Stopwatch.Enabled = true;
                Stopwatch2.Enabled = true;
                Minutes.Show();
                Colon.Show();
                Seconds.Show();
                Table.Show();
                FinishButton.Show();
                TimeElapsedLabel.Show();
                StatsLabel.Show();
                StartButton.Hide();
                PassedDisplay.Show();
                NADisplay.Show();
                FailedDisplay.Show();
                NotTestedDisplay.Show();
                LeftDisplay.Show();
                newProject(CreationDateBox.Text);
            }
        }

        /*
         * Looks for the current project in the pending list
         */
        private bool projectExists(string creationDate)
        {
            XmlDocument pending = new XmlDocument();
            string pendingDir = @"\\lgmcfs-sp\SW\CM\SE\TOOLS\NAO MEXER\Pending.xml";
            pending.Load(pendingDir);
            XmlNode root = pending.SelectSingleNode("projects");
            bool found = false;
            string cd = null;

            try
            {

                foreach (XmlElement element in pending.GetElementsByTagName("project"))
                {
                    cd = element.ChildNodes.Item(2).InnerText.Trim();
                    if (cd.Trim().Equals(creationDate))
                    {
                        found = true;
                        root.RemoveChild(element);
                        break;
                    }
                }

            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            pending.Save(pendingDir);

            if (!found)
            {
                MessageBox.Show("This project does not exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }

        }

        /*
         * Sets the current project as a new project
         */
        private void newProject(string creationDate)
        {
            if (list.isEmpty())
            {
                list.refresh();
            }

            if (projectExists(creationDate))
            {
                Project project = new Project(this.Text, getTimeStarted(), creationDate, PathBox.Text, list.getTester().getName());
                project.setStatus("In progress");
                list.getTester().setAvailability(false);
                list.toXml();
            }

        }

        /// <summary>
        /// Returns the creation date
        /// </summary>
        /// <returns></returns>
        private DateTime getCreationDate()
        {
            DateTime creation = File.GetCreationTime(PathBox.Text);
            DateTimeFormatInfo format = (new CultureInfo("en-GB")).DateTimeFormat;
            string creationDate = creation.ToString("G", format);
            return Convert.ToDateTime(creationDate);
        }

        /*
         * When a project is finished
         */
        private void projectFinished()
        {
            list.refresh();
            list.getTester().setAvailability(true);
            list.toXml();

            XmlDocument xml = new XmlDocument();
            string dir = @"\\lgmcfs-sp\SW\CM\SE\TOOLS\NAO MEXER\Projects.xml";
            xml.Load(dir);
                foreach (XmlElement element1 in xml.GetElementsByTagName("creationDate"))
                {
                    if (element1.InnerText.Equals(getCreationDate().ToString()) && element1.NextSibling.InnerText.Equals(PathBox.Text) && element1.PreviousSibling.InnerText.Equals(timeStarted))
                    {
                        element1.PreviousSibling.PreviousSibling.PreviousSibling.InnerText = xmlResult();
                        break;
                    }
                }
            xml.Save(dir);
        }

        /*
         * Controls the minutes
         */
        private void Stopwatch_Tick(object sender, EventArgs e)
        {
            Minutes.Text = (Convert.ToDouble(Minutes.Text) + 1).ToString();
            if (Convert.ToDouble(Minutes.Text) < 10)
            {
                Minutes.Text = "0" + Minutes.Text;
            }
        }

        /*
         * Returns the test and the comments if failed or not tested
         */
        private string Comments()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Table.Rows.Count; i++)
            {
                if ((string)Table[0, i].Value == "NOT TESTED" || (string)Table[0, i].Value == "FAILED")
                {
                    sb.Append("<b>Test case:</b>&nbsp;" + Table[2, i].Value + "&nbsp;&nbsp;&nbsp;&nbsp;<b>Result:</b>&nbsp;" + Table[0, i].Value + "&nbsp;&nbsp;&nbsp;&nbsp;<b>Tester's comments:</b>&nbsp;" + Table[1, i].Value + "<br>");
                }
            }
            return sb.ToString();
        }

        /*
         * Counts how many issues have been fixed
         */
        private int Passed()
        {
            int passed = 0;
            for (int i = 0; i < Table.RowCount; i++)
            {
                if ((string)Table[0, i].Value == "PASSED")
                {
                    passed++;
                    Table.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    Table.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
            return passed;
        }

        /*
         * Counts how many tests are not applicable
         */
        private int NA()
        {
            int na = 0;
            for (int i = 0; i < Table.RowCount; i++)
            {
                if ((string)Table[0, i].Value == "N/A")
                {
                    na++;
                    Table.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    Table.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
            return na;
        }

        /*
         * Counts how many tests have failed
         */
        private int Failed()
        {
            int failed = 0;
            for (int i = 0; i < Table.RowCount; i++)
            {
                if ((string)Table[0, i].Value == "FAILED")
                {
                    failed++;
                    Table.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    Table.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
            }
            return failed;
        }

        /*
         * Counts how many tests have failed
         */
        private int NotTested()
        {
            int notTested = 0;
            for (int i = 0; i < Table.RowCount; i++)
            {
                if ((string)Table[0, i].Value == "NOT TESTED")
                {
                    notTested++;
                    Table.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                    Table.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
            }
            return notTested;
        }

        /*
         * Counts how many tests are left
         */
        private int TestsLeft()
        {
            int left = 0;
            for (int i = 0; i < Table.RowCount; i++)
            {
                if ((string)Table[0, i].Value == null)
                {
                    left++;
                }
            }
            return left;
        }

        /*
         * Returns the final result of the test (html format)
         */
        private string htmlResult()
        {
            string result;
            if (Failed() == 0 && Passed() > 0)
            {
                result = "<font color=\"green\">ALL PASSED</font>";
            }
            else if (Failed() > 0)
            {
                result = "<font color=\"red\">FAILED</font>";
            }
            else
            {
                result = "Not tested. Please check the comments";
            }
            return result;
        }

        /*
         * Returns the final result of the test (xml format)
         */
        private string xmlResult()
        {
            string result;
            if (Failed() == 0 && Passed() > 0)
            {
                result = "ALL PASSED";
            }
            else if (Failed() > 0)
            {
                result = "FAILED";
            }
            else
            {
                result = "Not tested. Please check the comments";
            }
            return result;
        }

        /*
         * Refreshes the counters every millisecond
         */
        private void timer1_Tick(object sender, EventArgs e)
        {
            PassedDisplay.Text = Passed().ToString();
            NADisplay.Text = NA().ToString();
            FailedDisplay.Text = Failed().ToString();
            NotTestedDisplay.Text = NotTested().ToString();
            LeftDisplay.Text = TestsLeft().ToString();
        }

        /*
         * Controls the seconds
         */
        private void Stopwatch2_Tick(object sender, EventArgs e)
        {
            Seconds.Text = (Convert.ToDouble(Seconds.Text) + 1).ToString();
            if ((string)Seconds.Text == "60")
            {
                Seconds.Text = "0";
            }
            else if (Convert.ToDouble(Seconds.Text) < 10)
            {
                Seconds.Text = "0" + Seconds.Text;
            }
        }

        /*
         * When you click the 'x' button
         */
        private void Sanity_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /*
         * Useful links
         */
        private void LinksButton_Click(object sender, EventArgs e)
        {
            Links links = new Links();
            links.Show();
        }

        /*
         * Opens the current project in GPRI
         */
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

        /*
         * Trying to close the program before finishing the test
         */
        private void Sanity_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Stopwatch2.Enabled)
            {
                string msg = "You haven't finished your test yet. Are you sure you want to exit?";
                DialogResult res = MessageBox.Show(msg, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    projectCancelled();
                }
            }
        }

    }
}