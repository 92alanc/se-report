﻿using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net;
using System.Xml;
using SE_Report.Resources;
using System.Globalization;

namespace SE_Report.Forms
{
    public partial class Unit : Form
    {
        /*
         * Starts the frame
         */
        public Unit()
        {
            InitializeComponent();
        }

        private string timeStarted;
        //TesterList list = new TesterList();

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
        private void Back_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            if (((string)VersionBox.Text != "" || (string)NTCodeBox.Text != "" || Table.RowCount > 1) && Stopwatch2.Enabled == true)
            {
                string msg = "Some changes have been made. Are you sure you want to exit?";
                DialogResult res = MessageBox.Show(msg, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    //projectCancelled();
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
         * Adds a row
         */
        private void Add_Click(object sender, EventArgs e)
        {
            Table.RowCount++;
        }

        /*
         * Removes a row
         */
        private void Remove_Click(object sender, EventArgs e)
        {
            if (Table.RowCount > 0)
            {
                Table.RowCount--;
            }
        }

        /*
         * Finishes the test
         */
        private void FinishButton_Click(object sender, EventArgs e)
        {

            if (VersionBox.Text.Equals("") || NTCodeBox.Text.Equals("")) // Blank fields
            {
                MessageBox.Show("You must fill in all of the fields before saving your report", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (TestsLeft() > 0) // Tests yet to be done
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
            else if (NTCodeBox.Text.Equals("") || NTCodeBox.Text.Equals(null))
            {
                MessageBox.Show("Please fill in the NT Code text box", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            else
            {
                Stopwatch.Enabled = false; // Stops the minutes counter
                Stopwatch2.Enabled = false; // Stops the seconds counter
                PDF();
                //projectFinished();
                /*Reminder reminder = new Reminder();
                reminder.Show();
                reminder.showText(1, this.Text);*/
                checkDirectory();
                //CreateTemplate();
            }

        }

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
                if (element1.InnerText.Trim().Equals(getCreationDate()) && element1.NextSibling.InnerText.Trim().Equals(PathBox.Text) && element1.PreviousSibling.InnerText.Trim().Equals(timeStarted))
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
            // PDF title
            Paragraph line = new Paragraph("____________________________________________________________________________\n");
            Paragraph line2 = new Paragraph("____________________________________________________________________________\n\n");

            // Header
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
            // Release Information
            string ri = "Release Information";
            Paragraph rInfo = new Paragraph("\n" + ri);
            rInfo.Font.Size = 12;
            rInfo.Font.SetStyle("bold");
            rInfo.Font.SetFamily("Times new roman");
            rInfo.Alignment = Element.ALIGN_CENTER;
            string sw = "Software version: " + VersionBox.Text;
            Paragraph swv = new Paragraph(sw + "\n");
            swv.Font.SetFamily("Times new roman");
            swv.Font.Size = 10;
            Paragraph ntcode = new Paragraph("NT code: " + NTCodeBox.Text);
            ntcode.Font.SetFamily("Times new roman");
            ntcode.Font.Size = 10;
            Paragraph time = new Paragraph("Elapsed time: " + Minutes.Text + minutes);
            time.Font.SetFamily("Times new roman");
            time.Font.Size = 10;
            Paragraph tester = new Paragraph("Tester: " + Environment.UserName);
            tester.Font.SetFamily("Times new roman");
            tester.Font.Size = 10;

            // Stats
            string space3 = "   ";
            Paragraph stats = new Paragraph("\nTest summary\n");
            stats.Font.SetFamily("Times new roman");
            stats.Font.SetStyle("bold");
            stats.Font.Size = 12;
            stats.Alignment = Element.ALIGN_CENTER;
            Paragraph stats2 = new Paragraph("Passed: " + FixedDisplay.Text + space3 + "N/A: " + NADisplay.Text + space3 + "Not tested: " + NotTestedDisplay.Text + space3 + "Failed: " + NotFixedDisplay.Text + "\n\n");
            stats2.Font.SetFamily("Times new roman");
            stats2.Font.Size = 10;
            stats2.Alignment = Element.ALIGN_CENTER;


            // Spreadsheet
            PdfPTable sheet = new PdfPTable(Table.Columns.Count);

            // Copy column headers to PDF
            for (int i = 0; i < Table.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell(new Phrase(Table.Columns[i].HeaderText.ToUpper(), FontFactory.GetFont("Time news roman", 10)));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                sheet.AddCell(cell); // Column headers
            }

            sheet.HeaderRows = 1; // Making sure the 1st row is the one with the column headers

            // Copy the rows contents to PDF
            for (int j = 0; j < Table.Rows.Count; j++)
            {
                for (int k = 0; k < Table.Columns.Count; k++)
                {
                    if ((string)Table[1, j].Value == "FIXED")
                    {
                        sheet.DefaultCell.BackgroundColor = BaseColor.GREEN;
                    }
                    else if ((string)Table[1, j].Value == "N/A")
                    {
                        sheet.DefaultCell.BackgroundColor = BaseColor.YELLOW;
                    }
                    else if ((string)Table[1, j].Value == "NOT FIXED")
                    {
                        sheet.DefaultCell.BackgroundColor = BaseColor.RED;
                    }
                    else if ((string)Table[1, j].Value == "NOT TESTED")
                    {
                        sheet.DefaultCell.BackgroundColor = BaseColor.GRAY;
                    }
                    if (k != 1)
                    {
                        sheet.DefaultCell.BackgroundColor = BaseColor.WHITE;
                    }
                    if (Table[k, j].Value != null)
                    {
                        sheet.AddCell(new Phrase(Table[k, j].Value.ToString(), FontFactory.GetFont("Time news roman", 10))); // If the contents aren't empty, export to PDF
                    }
                    else
                    {
                        sheet.AddCell(new Phrase("")); // If the contents are empty, copy "" (empty string) to PDF
                    }
                }
            }

            // PDF settings
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 50, 50, 42, 35); // Numbers = margins (left, right, up, down)

            float[] widths = { 30f, 50f, 90f };

            sheet.WidthPercentage = 100.0f;
            sheet.HorizontalAlignment = 0;
            sheet.TotalWidth = 500f;
            sheet.LockedWidth = true;
            sheet.SetWidths(widths);

            try
            {

                // Unit logo
                string JPGpath3 = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                string FileName3 = "Unit Logo.jpg";
                iTextSharp.text.Image UnitLogo = iTextSharp.text.Image.GetInstance(JPGpath3 + "\\" + FileName3);
                UnitLogo.ScaleToFit(150f, 70f);
                UnitLogo.SpacingBefore = 10f;
                UnitLogo.SpacingAfter = 1f;
                UnitLogo.Alignment = Element.ALIGN_CENTER;

                // LG logo
                string FileName2 = "LG Logo.jpg";
                iTextSharp.text.Image LGLogo = iTextSharp.text.Image.GetInstance(JPGpath3 + "\\" + FileName2);
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


                // Saves the PDF as UNIT REPORT - (software version)
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\UNIT REPORTS"))
                {
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\UNIT REPORTS");
                }
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\UNIT REPORTS" +  "\\UNIT REPORT - " + VersionBox.Text + ".pdf";
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));


                // Exports all to PDF
                doc.Open();
                doc.Add(LGLogo);
                doc.Add(UnitLogo);
                doc.Add(rInfo);
                doc.Add(line);
                doc.Add(swv);
                doc.Add(ntcode);
                doc.Add(tester);
                doc.Add(time);
                doc.Add(stats);
                doc.Add(line);
                doc.Add(stats2);
                doc.Add(sheet);
                doc.Add(versionLabel);
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
         * Start button
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
                Refresher.Enabled = true;
                Minutes.Show();
                Colon.Show();
                Seconds.Show();
                Table.Show();
                FinishButton.Show();
                TimeElapsedLabel.Show();
                AddButton.Show();
                RemoveButton.Show();
                StatsLabel.Show();
                StartButton.Hide();
                FixedDisplay.Show();
                NADisplay.Show();
                NotTestedDisplay.Show();
                NotFixedDisplay.Show();
                LeftDisplay.Show();
                //newProject(getCreationDate());
                /*Reminder reminder = new Reminder();
                reminder.Show();
                reminder.showText(0, this.Text);
                IO.showDialogue(PathBox.Text.Substring(0, PathBox.Text.LastIndexOf("Documents") + 10), PathBox.Text); // + 10 to get the full path until ...technical documents\*/
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
                string suffix = null;
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

                foreach (string s in words)
                {
                    string[] jsonkeys = s.Split(delimiterChars4);
                    final = string.Concat(final, "-", jsonkeys[0], "\n");
                    if (jsonkeys[0].Equals("\"Swv\"", StringComparison.OrdinalIgnoreCase)) // Version
                    {
                        version = jsonkeys[1].Split(',')[0].Split('\"')[1].Split('\"')[0];
                    }
                    else if (jsonkeys[0].Equals("\"Suffix\"", StringComparison.OrdinalIgnoreCase))
                    {
                        suffix = jsonkeys[1].Split(',')[0].Split('\"')[1].Split('\"')[0];
                    }
                }

                // Sets the text boxes contents
                VersionBox.Text = version;

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

            string text = System.IO.File.ReadAllText(@"\\lgmcfs-sp\SW\CM\SE\TOOLS\DATABASE\new_reporte_template_unit.html");
            text = text.Replace("::TYPE::", "Unit");
            text = text.Replace("::VERSION::", VersionBox.Text);
            text = text.Replace("::RESULT::", htmlResult());
            text = text.Replace("::TESTER::", Environment.UserName);
            text = text.Replace("::COMMENTS::", Comments_());
            text = text.Replace("::PATH::", IO.getTargetFolder());

            using (FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\UnitTemplate.html", FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.WriteLine(text);
                }
            }

            // Opens the saved html file
            System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\UnitTemplate.html");

        }

        /*
         * Returns the test and the comments if not fixed or not tested
         */
        private string Comments_()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Table.Rows.Count; i++)
            {
                if ((string)Table[1, i].Value == "NOT TESTED" || (string)Table[1, i].Value == "NOT FIXED")
                {
                    sb.Append("<b>Test case:</b>&nbsp;" + Table[0, i].Value + "<br><b>Result:</b>&nbsp;" + Table[1, i].Value + "<br><b>Tester's comments:</b>&nbsp;" + Table[2, i].Value + "<br><br>");
                }
            }
            return sb.ToString();
        }

        /*
         * Counts how many issues have been fixed
         */
        private int Fixed()
        {
            int passed = 0;
            for (int i = 0; i < Table.RowCount; i++)
            {
                if ((string)Table.Rows[i].Cells[1].Value == "FIXED")
                {
                    passed++;
                    Table.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    Table.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
            return passed;
        }

        /*
         * Counts how many issues are not applicable for testing
         */
        private int NA()
        {
            int na = 0;
            for (int i = 0; i < Table.RowCount; i++)
            {
                if ((string)Table.Rows[i].Cells[1].Value == "N/A")
                {
                    na++;
                    Table.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    Table.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
            return na;
        }

        /*
         * Counts how many issues have not been fixed
         */
        private int NotFixed()
        {
            int failed = 0;
            for (int i = 0; i < Table.RowCount; i++)
            {
                if ((string)Table.Rows[i].Cells[1].Value == "NOT FIXED")
                {
                    failed++;
                    Table.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    Table.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
            }
            return failed;
        }

        /*
         * Counts how many issues have not been fixed
         */
        private int NotTested()
        {
            int notTested = 0;
            for (int i = 0; i < Table.RowCount; i++)
            {
                if ((string)Table.Rows[i].Cells[1].Value == "NOT TESTED")
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
                if ((string)Table.Rows[i].Cells[1].Value == null)
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
            if (NotFixed() == 0 && Fixed() > 0)
            {
                result = "<font color=\"green\">ALL PASSED</font>";
            }
            else if (NotFixed() > 0)
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
            if (NotFixed() == 0 && Fixed() > 0)
            {
                result = "ALL PASSED";
            }
            else if (NotFixed() > 0)
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
        private void Refresher_Tick(object sender, EventArgs e)
        {
            FixedDisplay.Text = Fixed().ToString();
            NADisplay.Text = NA().ToString();
            NotFixedDisplay.Text = NotFixed().ToString();
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
        private void Unit_FormClosed(object sender, FormClosedEventArgs e)
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
        private void Unit_FormClosing(object sender, FormClosingEventArgs e)
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
                    //projectCancelled();
                }
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
                    string getPathUnit = PathBox.Text.Remove(PathBox.Text.IndexOf("Technical"));
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\UNIT REPORTS" + "\\UNIT REPORT - " + VersionBox.Text + ".pdf";


                    getPathUnit = getPathUnit + @"Others";
                    if (!Directory.Exists(getPathUnit))
                    {
                        Directory.CreateDirectory(getPathUnit);
                    }

                    IO.targetFolder = getPathUnit;
                    File.Copy(path, getPathUnit + "\\UNIT REPORT - " + VersionBox.Text + ".pdf");
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
