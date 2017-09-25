using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Xml;
using System.Net;
using SE_Report.Resources;
using System.Globalization;

namespace SE_Report.Forms
{
    public partial class IssuesDB : Form
    {

        private string timeStarted;
        //TesterList list = new TesterList();

        /*
         * Initialises the frame
         * Reads the .xml file containing all test cases
         */
        public IssuesDB()
        {
            try
            {
                InitializeComponent();
                TestCases();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
         * Reads the.xml file containing all test cases
         */
        private void TestCases()
        {
            XmlReader xmlFile;
            FileStream fs = new FileStream(@"\\lgmcfs-sp\SW\CM\SE\TOOLS\DATABASE\IssuesDB.xml", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            xmlFile = XmlReader.Create(fs, new XmlReaderSettings());

            DataSet ds = new DataSet();
            ds.ReadXml(xmlFile);

            Table.DataSource = ds.Tables[1];

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
            Table.Columns.Add(Results);

            // Comments
            DataGridViewTextBoxColumn Comments = new DataGridViewTextBoxColumn();
            Comments.HeaderText = "COMMENTS";
            Comments.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Comments.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Comments.SortMode = DataGridViewColumnSortMode.NotSortable;
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
        /*private void projectCancelled()
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
                    if (element1.NextSibling.NextSibling.InnerText.Trim().Equals(timeStarted))
                    {
                        element1.InnerText = "Cancelled";
                    }
                }
            }

            list.getTester().setAvailability(true);
            list.toXml();
            xml.Save(dir);

        }*/

        /*
         * Back to main menu
         */
        private void BackButton_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            if (((string)PathBox.Text != "" || (string)CreationDateBox.Text != "" || (string)NTCodeBox.Text != "") && timer2.Enabled == true)
            {
                string msg = "Some changes have been made. Are you sure you want to exit?";
                DialogResult res = MessageBox.Show(msg, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    //projectCancelled();
                    timer2.Enabled = false;
                    this.Hide();
                    menu.Show();
                }
            }
            else
            {
                timer2.Enabled = false;
                this.Hide();
                menu.Show();
            }
        }

        /*
         * Finishes the test
         */
        private void FinishButton_Click_1(object sender, EventArgs e)
        {
            

            VersionBox.ReadOnly = false;
            NTCodeBox.ReadOnly = false;

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
            else if (NTCodeBox.Text.Equals("") || NTCodeBox.Text.Equals(null))
            {
                MessageBox.Show("Please fill in the NT Code text box", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (VersionBox.Text == "LG[MODEL][OS]_[SUFFIX]_[DATE]")
            {
                MessageBox.Show("You must fill the Version field according to requirement established!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                PDF();
                //projectFinished();
                checkDirectory();
                CreateTemplate();
            }
        }

        /*
         * Sets the current project as a new project
         */
        /*private void newProject(string creationDate)
        {
            if (list.isEmpty())
            {
                list.refresh();
            }

            Project project = new Project(this.Text, getTimeStarted(), creationDate, PathBox.Text, list.getTester().getName());
            project.setStatus("In progress");
            list.getTester().setAvailability(false);
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
         * When a project is finished
         */
        /*private void projectFinished()
        {
            list.refresh();
            list.getTester().setAvailability(true);
            list.toXml();

            XmlDocument xml = new XmlDocument();
            string dir = @"\\lgmcfs-sp\SW\CM\SE\TOOLS\NAO MEXER\Projects.xml";
            xml.Load(dir);
            foreach (XmlElement element1 in xml.GetElementsByTagName("creationDate"))
            {
                if (element1.InnerText.Trim().Equals(getCreationDate().ToString()) && element1.NextSibling.InnerText.Trim().Equals(PathBox.Text) && element1.PreviousSibling.InnerText.Trim().Equals(timeStarted))
                {
                    element1.PreviousSibling.PreviousSibling.PreviousSibling.InnerText = xmlResult();
                    break;
                }
            }
            xml.Save(dir);
        }*/

        /*
         * Saves the report as .pdf
         */
        private void PDF()
        {
            Paragraph line = new Paragraph("____________________________________________________________________________\n");
            Paragraph line2 = new Paragraph("____________________________________________________________________________\n\n");
            string minutes = " minutes";
            if (Minutes.Text.Equals("1"))
            {
                minutes = " minute";
            }

            // Header elements
            // Release Information
            string ri = "Release Information";
            Paragraph rInfo = new Paragraph("\n" + ri);
            rInfo.Font.Size = 12;
            rInfo.Font.SetStyle("bold");
            rInfo.Font.SetFamily("Times new roman");
            rInfo.Alignment = Element.ALIGN_CENTER;
            string sw = "Software version: " + VersionBox.Text;
            Paragraph swv = new Paragraph(sw + "\n\n");
            swv.Font.SetFamily("Times new roman");
            swv.Font.Size = 10;
            PdfPCell model = new PdfPCell(new Phrase("Model: " + ModelBox.Text, FontFactory.GetFont("Time news roman", 10)));
            PdfPCell buyer = new PdfPCell(new Phrase("Buyer: " + BuyerBox.Text + "    PKG" + PackageBox.Text, FontFactory.GetFont("Time news roman", 10)));
            PdfPCell creation = new PdfPCell(new Phrase("Creation date: " + CreationDateBox.Text, FontFactory.GetFont("Time news roman", 10)));
            PdfPCell time = new PdfPCell(new Phrase("Elapsed time: " + Minutes.Text + minutes, FontFactory.GetFont("Time news roman", 10)));
            Paragraph tester = new Paragraph("Tester: " + Environment.UserName);
            tester.Font.Size = 10;
            Paragraph ntcode = new Paragraph("NT code: " + NTCodeBox.Text);
            ntcode.Font.Size = 10;

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
            Paragraph stats = new Paragraph("\n\nTest summary\n");
            stats.Font.SetFamily("Times new roman");
            stats.Font.SetStyle("bold");
            stats.Font.Size = 12;
            stats.Alignment = Element.ALIGN_CENTER;
            Paragraph stats2 = new Paragraph("Passed: " + PassedDisplay.Text + space3 + "N/A: " + NADisplay.Text + space3 + "Not tested: " + NotTestedDisplay.Text + space3 + "Failed: " + FailedDisplay.Text + "\n\n");
            stats2.Font.SetFamily("Times new roman");
            stats2.Font.Size = 10;
            stats2.Alignment = Element.ALIGN_CENTER;

            // PDF table
            PdfPTable sheet = new PdfPTable(Table.Columns.Count - 1);
            sheet.WidthPercentage = 100;
            float[] widths = { 30, 20, 60 };
            sheet.SetWidths(widths);

            // Copy column headers to PDF - had to add them manually, otherwise they go to the pdf shuffled
            PdfPCell testCase = new PdfPCell(new Phrase(Table.Columns[2].HeaderText.ToUpper(), FontFactory.GetFont("Time news roman", 10)));
            testCase.HorizontalAlignment = Element.ALIGN_CENTER;
            sheet.AddCell(testCase); // Column headers
            PdfPCell result = new PdfPCell(new Phrase(Table.Columns[0].HeaderText.ToUpper(), FontFactory.GetFont("Time news roman", 10)));
            result.HorizontalAlignment = Element.ALIGN_CENTER;
            sheet.AddCell(result);
            PdfPCell comments = new PdfPCell(new Phrase(Table.Columns[1].HeaderText.ToUpper(), FontFactory.GetFont("Time news roman", 10)));
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
                    sheet.AddCell(new Phrase(Table[2, j].Value.ToString(), FontFactory.GetFont("Time news roman", 10))); // If the contents aren't empty, export to PDF
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
                        sheet.AddCell(new Phrase(Table[0, j].Value.ToString(), FontFactory.GetFont("Time news roman", 10)));
                    }
                    else if ((string)Table[0, j].Value == "N/A")
                    {
                        sheet.DefaultCell.BackgroundColor = BaseColor.YELLOW;
                        sheet.AddCell(new Phrase(Table[0, j].Value.ToString(), FontFactory.GetFont("Time news roman", 10)));
                    }
                    else if ((string)Table[0, j].Value == "FAILED")
                    {
                        sheet.DefaultCell.BackgroundColor = BaseColor.RED;
                        sheet.AddCell(new Phrase(Table[0, j].Value.ToString(), FontFactory.GetFont("Time news roman", 10)));
                    }
                    else if ((string)Table[0, j].Value == "NOT TESTED")
                    {
                        sheet.DefaultCell.BackgroundColor = BaseColor.GRAY;
                        sheet.AddCell(new Phrase(Table[0, j].Value.ToString(), FontFactory.GetFont("Time news roman", 10)));
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
                    sheet.AddCell(new Phrase(Table[1, j].Value.ToString(), FontFactory.GetFont("Time news roman", 10))); // If the contents aren't empty, export to PDF
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
                // Issues DB logo
                string JPGpath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                string FileName = "Issues DB Logo.jpg";
                iTextSharp.text.Image IssuesDBLogo = iTextSharp.text.Image.GetInstance(JPGpath + "\\" + FileName);
                IssuesDBLogo.ScaleToFit(150f, 70f);
                IssuesDBLogo.SpacingBefore = 10f;
                IssuesDBLogo.SpacingAfter = 1f;
                IssuesDBLogo.Alignment = Element.ALIGN_CENTER;

                // LG logo
                string FileName2 = "LG Logo.jpg";
                iTextSharp.text.Image LGLogo = iTextSharp.text.Image.GetInstance(JPGpath + "\\" + FileName2);
                LGLogo.ScaleToFit(120f, 80f);
                LGLogo.SpacingBefore = 10f;
                LGLogo.SpacingAfter = 1f;
                LGLogo.Alignment = Element.ALIGN_LEFT;

                //SE Report Version
                Paragraph versionLabel = new Paragraph("SE Report Version: " + Developers.VersionName);
                versionLabel.Font.SetFamily("Times new roman");
                versionLabel.Font.Size = 6;
                versionLabel.Alignment = Element.ALIGN_BOTTOM;
                versionLabel.Alignment = Element.ALIGN_RIGHT;

                //Looking for XML Version
                XmlDocument issues = new XmlDocument();
                string issuesDir = @"\\lgmcfs-sp\SW\CM\SE\TOOLS\DATABASE\IssuesDB.xml";
                issues.Load(issuesDir);
                XmlNode root = issues.SelectSingleNode("issuesdb");
                string version = null;

                foreach (XmlElement element in issues.GetElementsByTagName("version"))
                {
                    version = element.InnerText;
                }

                //XML Version
                Paragraph xmlVersion = new Paragraph("XML Version: " + version);
                xmlVersion.Font.SetFamily("Times new roman");
                xmlVersion.Font.Size = 6;
                xmlVersion.Alignment = Element.ALIGN_BOTTOM;
                xmlVersion.Alignment = Element.ALIGN_RIGHT;

                // Saves the PDF as ISSUES DB REPORT - (software version)
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\ISSUES DB REPORTS"))
                {
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\ISSUES DB REPORTS");
                }
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\ISSUES DB REPORTS" + "\\ISSUES DB REPORT - " + VersionBox.Text + ".pdf";
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));

                // Exports all to PDF
                doc.Open();
                doc.Add(LGLogo);
                doc.Add(IssuesDBLogo);
                doc.Add(rInfo);
                doc.Add(line);
                doc.Add(swv);
                doc.Add(header);
                doc.Add(tester);
                doc.Add(ntcode);
                doc.Add(stats);
                doc.Add(line);
                doc.Add(stats2);
                doc.Add(sheet);
                doc.Add(versionLabel);
                doc.Add(xmlVersion);
                doc.Close();

                // Confirmation message
                string msg = "Report generated successfully!\nDirectory -> " + path;
                MessageBox.Show(msg, "Report saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Error message
            }

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

                timer1.Enabled = true;
                timer2.Enabled = true;
                BackButton.Show();
                ColonLabel.Show();
                MinutesLabel.Show();
                SecondsLabel.Show();
                Table.Show();
                FinishButton.Show();
                ElapsedTimeLabel.Show();
                StatsLabel.Show();
                StartButton.Hide();
                PassedDisplay.Show();
                NADisplay.Show();
                FailedDisplay.Show();
                NotTestedDisplay.Show();
                LeftDisplay.Show();
                //newProject(CreationDateBox.Text);
                //IO.showDialogue(PathBox.Text.Substring(0, PathBox.Text.LastIndexOf("Documents") + 10), PathBox.Text); // + 10 to get the full path until ...technical documents\
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

                // Sets the text boxes contents
                VersionBox.Text = "LG[MODEL][OS]_[SUFFIX]_[DATE]";
                ModelBox.Text = model;
                BuyerBox.Text = buyer;
                CycleBox.Text = cycle;
                PackageBox.Text = package;
                CreationDateBox.Text = creationDate;
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

            string text = System.IO.File.ReadAllText(@"\\lgmcfs-sp\SW\CM\SE\TOOLS\DATABASE\new_reporte_template_issuesdb.html");
            text = text.Replace("::TYPE::", "Issues DB");
            text = text.Replace("::VERSION::", VersionBox.Text);
            text = text.Replace("::RESULT::", htmlResult());
            text = text.Replace("::TESTER::", Environment.UserName);
            text = text.Replace("::COMMENTS::", Comments());
            text = text.Replace("::PATH::", IO.getTargetFolder());

            using (FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\IssuesDBTemplate.html", FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.WriteLine(text);
                }
            }

            // Opens the saved html file
            System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\IssuesDBTemplate.html");

        }

        /*
         * Controls the minutes
         */
        private void timer1_Tick(object sender, EventArgs e)
        {
            MinutesLabel.Text = (Convert.ToDouble(MinutesLabel.Text) + 1).ToString();
            if (Convert.ToDouble(MinutesLabel.Text) < 10)
            {
                MinutesLabel.Text = "0" + MinutesLabel.Text;
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
                    sb.Append("<b>Test case:</b>&nbsp;" + Table[2, i].Value + "<br><b>Result:</b>" + Table[0, i].Value + "<br><b>Tester's comments:</b>&nbsp;" + Table[1, i].Value + "<br><br>");
                }
            }
            return sb.ToString();
        }

        /*
         * Counts how many tests have passed
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
         * Counts how many tests have not been tested
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
        private void timer3_Tick(object sender, EventArgs e)
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
        private void timer2_Tick(object sender, EventArgs e)
        {
            SecondsLabel.Text = (Convert.ToDouble(SecondsLabel.Text) + 1).ToString();
            if ((string)SecondsLabel.Text == "60")
            {
                SecondsLabel.Text = "0";
            }
            else if (Convert.ToDouble(SecondsLabel.Text) < 10)
            {
                SecondsLabel.Text = "0" + SecondsLabel.Text;
            }
        }

        /*
         * When you click the 'x' button
         */
        private void IssuesDB_FormClosed(object sender, FormClosedEventArgs e)
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
        private void IssuesDB_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer2.Enabled)
            {
                string msg = "You haven't finished your test yet. Are you sure you want to exit?";
                DialogResult res = MessageBox.Show(msg, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.No)
                {
                    e.Cancel = true;
                }
                /*
                else
                {
                    projectCancelled();
                }*/
            }
        }

        /// <summary>
        /// Checks if the chronos directory is ready for the report
        /// </summary>
        private void checkDirectory()
        {
            try
            {
                DialogResult result = MessageBox.Show("Would you like to copy it to Chronos?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    string getPathIssues = PathBox.Text.Remove(PathBox.Text.IndexOf("Technical"));
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\ISSUES DB REPORTS" + "\\ISSUES DB REPORT - " + VersionBox.Text + ".pdf";


                    getPathIssues = getPathIssues + @"RST\";
                    if (!Directory.Exists(getPath‪Issues))
                    {
                        Directory.CreateDirectory(getPath‪Issues);
                    }

                    getPath‪Issues = getPath‪Issues + @"02. Model Spec\";
                    if (!Directory.Exists(getPath‪Issues))
                    {
                        Directory.CreateDirectory(getPath‪Issues);
                    }
                    getPath‪Issues = getPath‪Issues + @"03. Operator Spec and Requirements";
                    if (!Directory.Exists(getPath‪Issues))
                    {
                        Directory.CreateDirectory(getPath‪Issues);
                    }

                    IO.targetFolder = getPathIssues;
                    File.Copy(path, getPathIssues + "\\ISSUES DB REPORT - " + VersionBox.Text + ".pdf");
                    IO.openFolder();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}
