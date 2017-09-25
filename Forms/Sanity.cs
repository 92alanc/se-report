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
    public partial class Sanity : Form
    {

        private string directory;
        private string timeStarted;

        //TesterList list = new TesterList();

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
            FileStream fs = new FileStream(@"\\lgmcfs-sp\SW\CM\SE\TOOLS\DATABASE\Sanity.xml", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            xmlFile = XmlReader.Create(fs, new XmlReaderSettings());

            DataSet ds = new DataSet();
            ds.ReadXml(xmlFile);

            


            Table.DataSource = ds.Tables[1];

            // ID
            Table.Columns[0].Width = 30;
            Table.Columns[0].Resizable = DataGridViewTriState.False;
            Table.Columns[0].ReadOnly = true;
            Table.Columns[0].HeaderText = "ID";
            Table.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Table.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            Table.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            Table.Columns[0].Visible = false;

            // Test case
            Table.Columns[1].Width = 300;
            Table.Columns[1].Resizable = DataGridViewTriState.False;
            Table.Columns[1].ReadOnly = true;
            Table.Columns[1].HeaderText = "TEST CASE";
            Table.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Table.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            Table.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Description
            Table.Columns[2].Width = 600;
            Table.Columns[2].Resizable = DataGridViewTriState.True;
            Table.Columns[2].ReadOnly = true;
            Table.Columns[2].HeaderText = "DESCRIPTION";
            Table.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Table.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            Table.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
            Table.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            
            
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
         * Read sanity automation xml and fill the tests
        */
        private void GetSanityAutomation()
        {   
            //Verifying if Others path and Sanity automation exists
            string othersPath = PathBox.Text;
            string getOthersPath = othersPath.Remove(othersPath.IndexOf("Technical"));
            getOthersPath = getOthersPath + @"Others\";
            string getSanityAutomation = getOthersPath + "sanity_automation.xml";
            if (!Directory.Exists(getOthersPath))
            {
                Directory.CreateDirectory(getOthersPath);
            }

            if (!File.Exists(getSanityAutomation))
            {
                MessageBox.Show("XML Sanity Automation not found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                string id_sanity = "";
                string id = "";
                string result = "";
                string comments = "";
                string testcase = "";

                for (int i = 0; i < Table.RowCount; i++)
                {

                    id_sanity = Table.Rows[i].Cells[2].Value.ToString();

                    //Getting ID and result of Sanity Automation
                    XmlDocument sanityAutomation = new XmlDocument();
                    sanityAutomation.Load(getSanityAutomation);
                    foreach (XmlElement element in sanityAutomation.GetElementsByTagName("test"))
                    {
                        id = element.Attributes["id"].Value;
                        if (id == id_sanity)
                        {
                            result = element.Attributes["pass"].Value;
                            if (result.Equals("True"))
                            {
                                Table.Rows[i].Cells[0].Value = "PASSED";
                                Table.Rows[i].Cells[1].Value = "[AUTO]\n";
                            }
                            else if(result.Equals("False"))
                            {
                                Table.Rows[i].Cells[0].Value = "FAILED";

                                comments = "[AUTO]\n";


                                XmlNodeList parentNode = element.ChildNodes;
                                foreach (XmlNode childNode in parentNode)
                                {
                                    testcase = childNode.Attributes["name"].Value;
                                    comments = comments + testcase + " - " + childNode.ChildNodes[0].InnerText + "\n";
                                }

                                Table.Rows[i].Cells[1].Value = comments;
                            }
                            else
                            {
                                Table.Rows[i].Cells[0].Value = "N/A";
                                Table.Rows[i].Cells[1].Value = "[AUTO]\n";
                            }
                        }
                    }
                    
                }
            }
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
            /*if (list.isEmpty())
            {
                list.refresh();
            }*/

            DialogResult result = MessageBox.Show("Cancel the project? (Yes - Cancel / No - move back to pending list / Cancel - Do nothing)", "Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Menu menu = new Menu();
                this.Hide();
                menu.Show();
            }
            else if (result == DialogResult.No)
            {
                sendBackToPending(CreationDateBox.Text);
            }

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

            //Create SWFV TXT
            using (FileStream fs2 = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + SwfvBox.Text + ".txt", FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs2, Encoding.UTF8))
                {
                    w.WriteLine("SWFV = " + SwfvBox.Text);
                }
            }


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
            else if (NTCodeBox.Text.Equals("") || NTCodeBox.Text.Equals(null))
            {
                MessageBox.Show("Please fill in the NT Code text box", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (SwfvBox.Text.Equals("") || SwfvBox.Text.Equals(null))
            {
                SwfvBox.ReadOnly = false;
                MessageBox.Show("Please fill in the SWFV Box text box", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Stopwatch.Enabled = false;
                Stopwatch2.Enabled = false;
                PDF();
                //projectFinished();
                //Reminder reminder = new Reminder();
                //reminder.Show();
                //reminder.showText(1, this.Text);
                checkDirectory();
                //CreateTemplate();
            }
        }

        
        
        
     




        /*
         * Generates the .pdf report
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
            else if (Minutes.Text.Equals("00"))
            {
                Minutes.Text = "1";
                minutes = " minute";
            }


            string path = PathBox.Text;
            string version = null;


            // Release Information
            string ri = "Release Information";
            Paragraph rInfo = new Paragraph("\n" + ri);
            rInfo.Font.Size = 12;
            rInfo.Font.SetStyle("bold");
            rInfo.Font.SetFamily("Times new roman");
            rInfo.Alignment = Element.ALIGN_CENTER;
            string sw = "Software version: " + VersionBox.Text;
            Paragraph swv = new Paragraph(sw + "\n");
            swv.Font.Size = 10;
            swv.Font.SetFamily("Times new roman");
            string swf = "SWFV: " + SwfvBox.Text;
            Paragraph swfv = new Paragraph(swf + "");
            swfv.Font.Size = 10;
            swfv.Font.SetFamily("Times new roman");
            string finger = "Fingerprint: " + fingerBox.Text;
            Paragraph fingerp = new Paragraph(finger + "\n\n");
            fingerp.Font.Size = 10;
            fingerp.Font.SetFamily("Times new roman");
            PdfPCell model = new PdfPCell(new Phrase("Model: " + ModelBox.Text + "   Cycle: " + CycleBox.Text, FontFactory.GetFont("Time news roman", 10)));
            PdfPCell buyer = new PdfPCell(new Phrase("Buyer: " + BuyerBox.Text + "    " + PackageBox.Text, FontFactory.GetFont("Time news roman", 10)));
            PdfPCell creation = new PdfPCell(new Phrase("Creation date: " + CreationDateBox.Text, FontFactory.GetFont("Time news roman", 10)));
            PdfPCell time = new PdfPCell(new Phrase("Elapsed time: " + Minutes.Text + minutes, FontFactory.GetFont("Time news roman", 10)));
            Paragraph tester = new Paragraph("Tester: " + Environment.UserName);
            tester.Font.Size = 10;
            tester.Font.SetFamily("Times new roman");
            Paragraph ntcode = new Paragraph("NT Code: " + NTCodeBox.Text);
            ntcode.Font.Size = 10;
            ntcode.Font.SetFamily("Times new roman");



            //Verifying if Others path and Sanity automation exists
            string othersPath = PathBox.Text;
            string getOthersPath = othersPath.Remove(othersPath.IndexOf("Technical"));
            getOthersPath = getOthersPath + @"Others\";
            string getSanityAutomation = getOthersPath + "sanity_automation.xml";
            string fingerprintDevice = "";
            string hwv = "";
            string swfvDevice = "";
            string swvDevice = "";
            string ntcodeDevice = "";
            string mccmnc = "";
            string qfuseEnable = "";
            string duration = "";
            string sanityAutoVersion = "";
            bool notFound = false;
            if (!Directory.Exists(getOthersPath))
            {
                Directory.CreateDirectory(getOthersPath);
            }

            if (!File.Exists(getSanityAutomation))
            {
                notFound = true;
            }
            else
            {

                //Getting information of Sanity Automation
                XmlDocument sanityAutomation = new XmlDocument();
                sanityAutomation.Load(getSanityAutomation);
                XmlNodeList xnList = sanityAutomation.SelectNodes("/sanity/device");
                foreach (XmlNode xn in xnList)
                {
                    fingerprintDevice = xn["fingerprint"].InnerText;
                    hwv = xn["hardware_version"].InnerText;
                    swfvDevice = xn["swfv"].InnerText;
                    swvDevice = xn["swv"].InnerText;
                    ntcodeDevice = xn["ntcode"].InnerText;
                    mccmnc = xn["mcc_mnc"].InnerText;
                    qfuseEnable = xn["qfuse_enable"].InnerText;

                }

                foreach (XmlElement element in sanityAutomation.GetElementsByTagName("test_duration"))
                {
                    duration = element.InnerText;
                }
                foreach (XmlElement element in sanityAutomation.GetElementsByTagName("automation_version"))
                {
                    sanityAutoVersion = element.InnerText;
                }

            }


            //Device Information
            string di = "Device Information";
            Paragraph dInfo = new Paragraph("\n\n" + di);
            dInfo.Font.Size = 12;
            dInfo.Font.SetStyle("bold");
            dInfo.Font.SetFamily("Times new roman");
            dInfo.Alignment = Element.ALIGN_CENTER;

            string swDevice = "Software version: " + swvDevice;
            Paragraph swvPdf = new Paragraph(swDevice + "\n");
            swvPdf.Font.Size = 10;
            swvPdf.Font.SetFamily("Times new roman");

            string swfDevice = "SWFV: " + swfvDevice;
            Paragraph swfvPdf = new Paragraph(swfDevice + "\n");
            swfvPdf.Font.Size = 10;
            swfvPdf.Font.SetFamily("Times new roman");

            string ntDevice = "Ntcode: " + ntcodeDevice;
            Paragraph ntPdf = new Paragraph(ntDevice + "\n");
            ntPdf.Font.Size = 10;
            ntPdf.Font.SetFamily("Times new roman");

            string fingerpdevice = "Fingerprint: " + fingerprintDevice;
            Paragraph fingerpd = new Paragraph(fingerpdevice + "\n\n");
            fingerpd.Font.Size = 10;
            fingerpd.Font.SetFamily("Times new roman");

            string testTime = "Test Duration: " + duration;
            Paragraph timeTest = new Paragraph(testTime + "\n");
            timeTest.Font.Size = 10;
            timeTest.Font.SetFamily("Times new roman");

            string mcc_mnc = "MCC & MNC: " + mccmnc;
            Paragraph mcc = new Paragraph(mcc_mnc + "\n");
            mcc.Font.Size = 10;
            mcc.Font.SetFamily("Times new roman");

            PdfPCell hw = new PdfPCell(new Phrase("Hardware Version: " + hwv, FontFactory.GetFont("Time news roman", 10)));
            PdfPCell qfuse = new PdfPCell(new Phrase("Qfuse Enable: " + qfuseEnable, FontFactory.GetFont("Time news roman", 10)));

            Paragraph ntcodePdf = new Paragraph("NT Code: " + ntcode);
            ntcodePdf.Font.Size = 10;
            ntcodePdf.Font.SetFamily("Times new roman");

            //XML Version
            Paragraph xmlVersionAuto = new Paragraph("Sanity Automation Version: " + sanityAutoVersion);
            xmlVersionAuto.Font.SetFamily("Times new roman");
            xmlVersionAuto.Font.Size = 6;
            xmlVersionAuto.Alignment = Element.ALIGN_BOTTOM;
            xmlVersionAuto.Alignment = Element.ALIGN_RIGHT;


            // HeadersDevice
            PdfPTable headers = new PdfPTable(2);
            headers.WidthPercentage = 100;
            float[] widths3 = { 60, 80 };
            headers.SetWidths(widths3);
            headers.AddCell(qfuse);
            headers.AddCell(hw);





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
            Paragraph stats = new Paragraph("\n\nTest summary");
            stats.Font.SetFamily("Times new roman");
            stats.Font.SetStyle("bold");
            stats.Font.Size = 12;
            stats.Alignment = Element.ALIGN_CENTER;
            Paragraph stats2 = new Paragraph("Passed: " + PassedDisplay.Text + space3 + "N/A: " + NADisplay.Text + space3 + "Not tested: " + NotTestedDisplay.Text + space3 + "Failed: " + FailedDisplay.Text + "\n\n");
            stats2.Font.SetFamily("Times new roman");
            stats2.Font.Size = 10;
            stats2.Alignment = Element.ALIGN_CENTER;


            //Looking for XML Version
            XmlDocument sanity = new XmlDocument();
            string sanityDir = @"\\lgmcfs-sp\SW\CM\SE\TOOLS\DATABASE\Sanity.xml";
            sanity.Load(sanityDir);
            XmlNode root = sanity.SelectSingleNode("sanity");

            foreach (XmlElement element in sanity.GetElementsByTagName("version"))
            {
                version = element.InnerText;
            }


            //XML Version
            Paragraph xmlVersion = new Paragraph("XML Version: " + version);
            xmlVersion.Font.SetFamily("Times new roman");
            xmlVersion.Font.Size = 6;
            xmlVersion.Alignment = Element.ALIGN_BOTTOM;
            xmlVersion.Alignment = Element.ALIGN_RIGHT;

            
            
            //SE Report Version
            Paragraph versionLabel = new Paragraph("SE Report Version: " + Developers.VersionName);
            versionLabel.Font.SetFamily("Times new roman");
            versionLabel.Font.Size = 6;
            versionLabel.Alignment = Element.ALIGN_BOTTOM;
            versionLabel.Alignment = Element.ALIGN_RIGHT;



            // PDF table
            PdfPTable sheet = new PdfPTable(Table.Columns.Count -2);
            sheet.WidthPercentage = 100;
            float[] widths = { 30, 20, 60 };
            sheet.SetWidths(widths);

            // Copy column headers to PDF - had to add them manually, otherwise they go to the pdf shuffled
            PdfPCell testCase = new PdfPCell(new Phrase(Table.Columns[3].HeaderText.ToUpper(), FontFactory.GetFont("Time news roman", 10))); // Test case
            testCase.HorizontalAlignment = Element.ALIGN_CENTER;
            sheet.AddCell(testCase); // Column headers
            PdfPCell result = new PdfPCell(new Phrase(Table.Columns[0].HeaderText.ToUpper(), FontFactory.GetFont("Time news roman", 10))); // Result
            result.HorizontalAlignment = Element.ALIGN_CENTER;
            sheet.AddCell(result);
            PdfPCell comments = new PdfPCell(new Phrase(Table.Columns[1].HeaderText.ToUpper(), FontFactory.GetFont("Time news roman", 10))); // Comments
            comments.HorizontalAlignment = Element.ALIGN_CENTER;
            sheet.AddCell(comments);

            sheet.HeaderRows = 1; // Making sure the 1st row is the one with the column headers

            // Copies the rows contents to PDF and changes the "RESULT" column's cells according to test cases results
            for (int j = 0; j < Table.Rows.Count; j++)
            {
                // Exports cell contents to PDF
                if (Table[3, j].Value != null)
                {
                    sheet.DefaultCell.BackgroundColor = BaseColor.WHITE;
                    sheet.AddCell(new Phrase(Table[3, j].Value.ToString(), FontFactory.GetFont("Time news roman", 10))); // If the contents aren't empty, export to PDF
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
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\SANITY REPORTS"))
                {
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\SANITY REPORTS");
                }
                string path2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\SANITY REPORTS" + "\\SANITY REPORT - " + VersionBox.Text + ".pdf";
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path2, FileMode.Create));



                // Exports all to PDF
                doc.Open();
                doc.Add(LGLogo);
                doc.Add(SanityLogo);
                doc.Add(rInfo);
                doc.Add(line);
                doc.Add(swv);
                doc.Add(swfv);
                doc.Add(fingerp);
                doc.Add(header);
                doc.Add(tester);
                doc.Add(ntcode);
                if(notFound == false)
                {
                    doc.Add(dInfo);
                    doc.Add(line);
                    doc.Add(swvPdf);
                    doc.Add(swfvPdf);
                    doc.Add(fingerpd);
                    doc.Add(headers);
                    doc.Add(timeTest);
                    doc.Add(ntPdf);
                    doc.Add(mcc);
                }
                doc.Add(stats);
                doc.Add(line);
                doc.Add(stats2);
                doc.Add(sheet);
                doc.Add(versionLabel);
                doc.Add(xmlVersion);
                if (notFound == false)
                {
                    doc.Add(xmlVersionAuto);
                }
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
                CreationDateBox.ReadOnly = false;





                string x = "http://10.193.225.22:9596/service.svc/getRelease?Chronosid=";
                string y = id;
                string all = string.Concat(x, y);
                WebClient client = new WebClient();
                Stream stream = client.OpenRead(all);
                StreamReader reader = new StreamReader(stream);
                Newtonsoft.Json.Linq.JObject Json = Newtonsoft.Json.Linq.JObject.Parse(reader.ReadLine());
                string downloadString = client.DownloadString(all);

                //Verifying if Others path and Sanity automation exists
                string othersPath = PathBox.Text;
                string getOthersPath = othersPath.Remove(othersPath.IndexOf("Technical"));
                getOthersPath = getOthersPath + @"Others\";
                string getSanityAutomation = getOthersPath + "sanity_automation.xml";
                if (!Directory.Exists(getOthersPath))
                {
                    Directory.CreateDirectory(getOthersPath);
                }

                if (File.Exists(getSanityAutomation))
                {
                    var swfv = "";
                    swfv = (string)Json["SWFV"];
                    SwfvBox.Text = swfv;
                }

                var requestCTS = (string)Json["RequestCTS"];
                var versionBinary = (string)Json["VersionType"];
                var finger = (string)Json["Fingerprint"];





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
                VersionBox.Text = version;
                ModelBox.Text = model;
                BuyerBox.Text = buyer;
                CycleBox.Text = cycle;
                PackageBox.Text = package;
                CreationDateBox.Text = cd;
                fingerBox.Text = finger;



                if (requestCTS == "NO" || versionBinary == "SUBSET" || versionBinary == "SUPERSET")
                {
                    MessageBox.Show("This binary is probably the same as another. Please check that !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            string text = System.IO.File.ReadAllText(@"\\lgmcfs-sp\SW\CM\SE\TOOLS\DATABASE\new_reporte_template_sanityofficial.html");
            text = text.Replace("::TYPE::", "Sanity");
            text = text.Replace("::VERSION::", VersionBox.Text);
            text = text.Replace("::SWFV::", SwfvBox.Text);
            text = text.Replace("::RESULT::", htmlResult());
            text = text.Replace("::TESTER::", Environment.UserName);
            text = text.Replace("::COMMENTS::", Comments());
            text = text.Replace("::PATH::", IO.getTargetFolder());


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
                projectExists(getCreationDate());
                Please_Wait please = new Please_Wait();
                please.Show();
                Application.DoEvents();
                GetData();
                System.Threading.Thread.Sleep(2000);
                please.Close();
                Stopwatch.Enabled = true;
                Stopwatch2.Enabled = true;
                Minutes.Show();
                Colon.Show();
                Seconds.Show();
                GetSanityAutomation();
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
                //newProject(CreationDateBox.Text);
                /*Reminder reminder = new Reminder();
                reminder.Show();
                reminder.showText(0, this.Text);
                IO.showDialogue(PathBox.Text.Substring(0, PathBox.Text.LastIndexOf("Documents") + 10), PathBox.Text); // + 10 to get the full path until ...technical documents\*/
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
        /*private void newProject(string creationDate)
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
                    if (element1.InnerText.Trim().Equals(getCreationDate()) && element1.NextSibling.InnerText.Trim().Equals(PathBox.Text) && element1.PreviousSibling.InnerText.Trim().Equals(timeStarted))
                    {
                        element1.PreviousSibling.PreviousSibling.PreviousSibling.InnerText = xmlResult();
                        break;
                    }
                }
            xml.Save(dir);
        }*/

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
                    sb.Append("<b>Test case:</b>&nbsp;" + Table[2, i].Value + "<br><b>Result:</b>&nbsp;" + Table[0, i].Value + "<br><b>Tester's comments:</b>&nbsp;" + Table[1, i].Value + "<br><br>");
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
                    string getPathSanity = PathBox.Text.Remove(PathBox.Text.IndexOf("Technical"));
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\SANITY REPORTS" + "\\SANITY REPORT - " + VersionBox.Text + ".pdf";


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
                    File.Copy(path, getPathSanity + "\\SANITY REPORT - " + VersionBox.Text + ".pdf");
                    IO.openFolder();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




            //Copying TEST DESCRIPTION PDF to Chronos
            string filepath = @"\\lgmcfs-sp\SW\CM\SE\TOOLS\DATABASE\";
            DirectoryInfo d = new DirectoryInfo(filepath);

            foreach (var file in d.GetFiles("*.pdf"))
            {
                   directory = filepath + file.Name;
                   if (!File.Exists(IO.getTargetFolder() + "\\" + file.Name))
                   File.Copy(directory, IO.getTargetFolder() + "\\" + file.Name);
            }


            //Copying txt to Chronos
            string path2 = PathBox.Text;
            string getPath2 = path2.Remove(path2.IndexOf("Technical"));

            getPath2 = getPath2 + @"Others";
            if (!Directory.Exists(getPath2))
            {
                Directory.CreateDirectory(getPath2);
            }

            try
            {
                File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + SwfvBox.Text + ".txt", getPath2 + "\\" + SwfvBox.Text + ".txt");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + SwfvBox.Text + ".txt");


            
        }

        /// <summary>
        /// Sends a project back to pending projects list
        /// </summary>
        /// <param name="creationDate"></param>
        private void sendBackToPending(string creationDate)
        {
            string chronos = PathBox.Text;

            XmlDocument xml = new XmlDocument();
            xml.Load(@"\\lgmcfs-sp\SW\CM\SE\TOOLS\NAO MEXER\Pending.xml");
            XmlNode project = xml.CreateElement("project");
            XmlNode status = xml.CreateElement("status");
            status.InnerText = "NEW";
            XmlNode testType = xml.CreateElement("testType");
            testType.InnerText = this.Text.ToUpper();
            XmlNode creationDateNode = xml.CreateElement("creationDate");
            creationDateNode.InnerText = creationDate;
            XmlNode chronosNode = xml.CreateElement("chronos");
            chronosNode.InnerText = chronos;
            XmlNode unit = xml.CreateElement("Unit");
            XmlNode forecast = xml.CreateElement("forecast");
            project.AppendChild(status);
            project.AppendChild(testType);
            project.AppendChild(creationDateNode);
            project.AppendChild(chronosNode);
            project.AppendChild(unit);
            project.AppendChild(forecast);
            xml.SelectSingleNode("projects").AppendChild(project);
            xml.Save(@"\\lgmcfs-sp\SW\CM\SE\TOOLS\NAO MEXER\Pending.xml");

        }


    }
}