using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SE_Report.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SE_Report.Forms
{
    public partial class CreateTemplate : Form
    {
        public CreateTemplate()
        {
            InitializeComponent();
        }



        private void CreateTemplate_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }





        
        public void GetData()
        {
            string path = chronosPathBox.Text;
            string getPath = path.Remove(path.IndexOf("Technical"));

             getPath = getPath + @"RST\";
             if (!Directory.Exists(getPath))
             {
                 Directory.CreateDirectory(getPath);
             }

             getPath = getPath + @"01. General Information\";
             if (!Directory.Exists(getPath))
             {
                 Directory.CreateDirectory(getPath);
             }
             getPath = getPath + @"05. Test Results";
             if (!Directory.Exists(getPath))
             {
                 Directory.CreateDirectory(getPath);
             }

             string path2 = chronosPathBox.Text;
             string getPath2 = path.Remove(path2.IndexOf("Technical"));

             getPath2 = getPath2 + @"Others";
             if (!Directory.Exists(getPath2))
             {
                 Directory.CreateDirectory(getPath2);
             }







            try
            {
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


                //Getting tests data of Web Service


                string x = "http://10.193.225.22:9596/service.svc/getRelease?Chronosid=";
                string y = id;
                string all = string.Concat(x, y);
                WebClient client = new WebClient();
                Stream stream = client.OpenRead(all);
                StreamReader reader = new StreamReader(stream);
                Newtonsoft.Json.Linq.JObject Json = Newtonsoft.Json.Linq.JObject.Parse(reader.ReadLine());

                int length = Json["Tests"].Count();
                var testersUnit = "";
                var testerComp = "";
                var numberComp1 = "";
                var numberComp2 = "";
                var typeComp1 = "";
                var typeComp2 = "";
                int unitFailed = 0;
                string[] jsonComp;
                jsonComp = new string[length]; 

                    for (int i = 0; i <length; i++)
                    {

                      
                        var AssignedTo = ((string)Json["Tests"][i]["AssignedTo"]);
                        var Status = ((string)Json["Tests"][i]["Status"]);
                        var Type = ((string)Json["Tests"][i]["Type"]);
                        var commentTest = ((string)Json["Tests"][i]["Comments"]);
                        var Number = ((string)Json["Tests"][i]["Number"]);

                        if (Type == "Sanity Official")
                        {
                            testerBox1.Text = AssignedTo;
                            statusBox1.Text = Status;
                        }
                        if(Type == "Sanity Official" && statusBox1.Text == "")
                        {
                            statusBox1.Text = "NOT TESTED";
                        }
                        if (Type == "Sanity Official" && testerBox1.Text == "")
                        {
                            testerBox1.Text = "Not Assigned";
                        }


                        if (Type == "QFUSE")
                        {
                            testerBox3.Text = AssignedTo;
                            statusBox3.Text = Status;
                        }
                        if (Type == "QFUSE" && statusBox3.Text == "")
                        {
                            statusBox3.Text = "NOT TESTED";

                        }
                        if (Type == "QFUSE" && testerBox3.Text == "")
                        {
                            testerBox3.Text = "Not Assigned";
                        }

                        if (Type == "HEC")
                        {
                            testerBox4.Text = AssignedTo;
                            statusBox4.Text = Status;
                        }
                        if (Type == "HEC" && statusBox4.Text == "")
                        {
                            statusBox4.Text = "NOT TESTED";

                        }
                        if (Type == "HEC" && testerBox4.Text == "")
                        {
                            testerBox4.Text = "Not Assigned";
                        }


                        if (Type == "Sanity Internal")
                        {
                            testerBox6.Text = AssignedTo;
                            statusBox6.Text = Status;
                        }
                        if (Type == "Sanity Internal" && statusBox6.Text == "")
                        {
                            statusBox6.Text = "NOT TESTED";
                        }
                        if (Type == "Sanity Internal" && testerBox6.Text == "")
                        {
                            testerBox6.Text = "Not Assigned";
                        }

                        if (Type == "RnD Self Check - SIM Lock")
                        {
                            testerBox8.Text = AssignedTo;
                            statusBox8.Text = Status;
                        }
                        if (Type == "RnD Self Check - SIM Lock" && statusBox8.Text == "")
                        {
                            statusBox8.Text = "NOT TESTED";
                        }
                        if (Type == "RnD Self Check - SIM Lock" && testerBox8.Text == "")
                        {
                            testerBox8.Text = "Not Assigned";
                        }

                        if (Type == "RnD Self Check - FOTA")
                        {
                            testerBox9.Text = AssignedTo;
                            statusBox9.Text = Status;
                        }
                        if (Type == "RnD Self Check - FOTA" && statusBox9.Text == "")
                        {
                            statusBox9.Text = "NOT TESTED";
                        }
                        if (Type == "RnD Self Check - FOTA" && testerBox9.Text == "")
                        {
                            testerBox9.Text = "Not Assigned";
                        }


                        if (Type == "RnD Self Check - WebDL")
                        {
                            testerBox10.Text = AssignedTo;
                            statusBox10.Text = Status;
                        }
                        if (Type == "RnD Self Check - WebDL" && statusBox10.Text == "")
                        {
                            statusBox10.Text = "NOT TESTED";
                        }
                        if (Type == "RnD Self Check - webDL" && testerBox10.Text == "")
                        {
                            testerBox10.Text = "Not Assigned";
                        }

                        if (Type == "MID")
                        {
                            testerBox11.Text = AssignedTo;
                            statusBox11.Text = Status;
                        }
                        if (Type == "MID" && statusBox11.Text == "")
                        {
                            statusBox11.Text = "NOT TESTED";
                        }
                        if (Type == "MID" && testerBox11.Text == "")
                        {
                            testerBox11.Text = "Not Assigned";
                        }

                        if(Type == "Unit")
                        {
                            if (!testerBox7.Visible && !unitLabel.Visible && !statusBox7.Visible)
                            {
                                testerBox7.Visible = true;
                                unitLabel.Visible = true;
                                statusBox7.Visible = true;
                            }
                            if(testerComp != AssignedTo)
                            {
                                testersUnit = testersUnit + AssignedTo + "<br>";
                                testerComp = AssignedTo;
                            }
                            statusBox7.Text = Status;
                            if(Status == "FAILED")
                            {
                                unitFailed = 1;
                            }
                            if(unitFailed == 1)
                            {
                                statusBox7.Text = "FAILED";
                            }
                            
                        }

                        

                        if(Status == "FAILED" && Type != "Unit" && typeComp1 != Type)
                        {
                            commentsBox.Text = commentsBox.Text + "<b>" + Type + "</b>" + ":<br>" + "Status: " +  "<b> <font color=\"red\">" + Status + "</font> </b>" + "<br>" +  commentTest + "<br><br>"; 
                        }
                        if (Status == "FAILED" && Type == "Unit" && numberComp1 != Number)
                        {
                            unitFailed = 1;
                            commentsBox.Text = commentsBox.Text + "<b>" + Type + ": " + "(" + Number + ")" + "</b>" + "<br>" + "Status: " + "<b> <font color=\"red\">" + Status + "</font> </b>" + "<br>" + commentTest + "<br><br>";
                            numberComp1 = Number;
                        }

                        if (Status == "NOT TESTED" && Type != "Unit" && typeComp2 != Type)
                        {
                            commentsBox.Text = commentsBox.Text + "<b>" + Type + "</b>" + ":<br>" + "Status: " + "<b> <font color=\"gray\">" + Status + "</font> </b>" + "<br>" + commentTest + "<br><br>"; 
                        }
                        if (Status == "NOT TESTED" && Type == "Unit" && numberComp2 != Number)
                        {
                            commentsBox.Text = commentsBox.Text + "<b>" + Type + ": " + "(" + Number + ")" + "</b>" + "<br>" + "Status: " + "<b> <font color=\"gray\">" + Status + "</font> </b>" + "<br>" + commentTest + "<br><br>"; 
                            numberComp2 = Number;
                        }

                    }


                    //Verifying if Others path and Sanity automation exists
                    string othersPath = chronosPathBox.Text;
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
                        swfvBox.Text = swfv;
                    }

                    testerBox7.Text = testersUnit;



                //Setting comments
                



                //Seting N/A to tests

                if (testerBox1.Text == "")
                {
                    testerBox1.Text = "N/A";
                }
                if (statusBox1.Text == "")
                {
                    statusBox1.Text = "N/A";
                }

                if (testerBox3.Text == "")
                {
                    testerBox3.Text = "N/A";
                }
                if (statusBox3.Text == "")
                {
                    statusBox3.Text = "N/A";
                }

                if (testerBox4.Text == "")
                {
                    testerBox4.Text = "N/A";
                }
                if (statusBox4.Text == "")
                {
                    statusBox4.Text = "N/A";
                }


                if (testerBox6.Text == "")
                {
                    testerBox6.Text = "N/A";
                }
                if (statusBox6.Text == "")
                {
                    statusBox6.Text = "N/A";
                }

                if (testerBox7.Text == "")
                {
                    testerBox7.Text = "N/A";
                }
                if (statusBox7.Text == "")
                {
                    statusBox7.Text = "N/A";
                }

                if (testerBox8.Text == "")
                {
                    testerBox8.Text = "N/A";
                }
                if (statusBox8.Text == "")
                {
                    statusBox8.Text = "N/A";
                }

                if (testerBox9.Text == "")
                {
                    testerBox9.Text = "N/A";
                }
                if (statusBox9.Text == "")
                {
                    statusBox9.Text = "N/A";
                }

                if (testerBox10.Text == "")
                {
                    testerBox10.Text = "N/A";
                }
                if (statusBox10.Text == "")
                {
                    statusBox10.Text = "N/A";
                }

                if (testerBox11.Text == "")
                {
                    testerBox11.Text = "N/A";
                }
                if (statusBox11.Text == "")
                {
                    statusBox11.Text = "N/A";
                }

                // Sets the text boxes contents
                var swv = (string)Json["Swv"];
                swvBox.Text = swv;
                detailsBox.Text = getPath;
                detailsBox2.Text = getPath2;
    
    

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public void CheckQeChecklist()
        {

            int qeChecklist = 0;

            string path = chronosPathBox.Text;
            string getPath = path.Remove(path.IndexOf("Technical"));


            //D:Dir dhould exists in ur system
            DirectoryInfo dir1 = new DirectoryInfo(getPath);
            FileInfo [] files = dir1.GetFiles("*txt", SearchOption.AllDirectories);
            foreach (FileInfo f in files)
            {
                string filename = f.Name.ToString();
                filename= filename.Replace(".txt", "");
                if (filename == "QE_CHECKLIST_OK")
                {
                    qeChecklist = 1;
                }

            }
            if (qeChecklist == 1)
            {
                string msgOk = "QE Checklist is OK, you can send email!";
                MessageBox.Show(msgOk, "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string msgNg = "QE Checklist is NOT OK. Would you like to open the ID folder?";
                DialogResult res = MessageBox.Show(msgNg, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(getPath);
                }

            }



        }

        


        public void GenerateTemplate()
        {
            bool waiting = false;
            string testStatus;
            if ((statusBox3.Text == "N/A" || statusBox3.Text == "NOT TESTED") || (statusBox4.Text == "N/A" || statusBox4.Text == "NOT TESTED"))
            {
                string msgWaiting = "Qfuse and Hec have not been done. Would you like to generate Template for Waiting Status?";
                DialogResult res = MessageBox.Show(msgWaiting, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    waiting = true;
                }
            }
       

            if (waiting == true)
            {
                testStatus = "Waiting Gate Approved by PL.";
            }
            else if (waiting == false && (statusBox1.Text == "NOT TESTED" ||statusBox3.Text == "NOT TESTED" ||statusBox3.Text == "NOT TESTED" || statusBox4.Text == "NOT TESTED" || statusBox6.Text == "NOT TESTED" || statusBox7.Text == "NOT TESTED" || statusBox8.Text == "NOT TESTED" || statusBox9.Text == "NOT TESTED" || statusBox10.Text == "NOT TESTED" || statusBox11.Text == "NOT TESTED"))
            {
                testStatus = "Test in progress.";
            }
            else
            {
                testStatus = "Tests done.";
            }



            string text = System.IO.File.ReadAllText(@"\\lgmcfs-sp\SW\CM\SE\TOOLS\DATABASE\new_reporte_template_sanityofficial.html");
            text = text.Replace("::TESTSTATUS::", testStatus);
            text = text.Replace("::SANITY::", "Sanity");
            text = text.Replace("::QFUSE::", "QFUSE");
            text = text.Replace("::HEC::", "HEC");
            text = text.Replace("::SANITYINTERNAL::", "Sanity Internal");
            text = text.Replace("::RNDSIMLOCK::", "RnD Self Check - SIM Lock");
            text = text.Replace("::RNDFOTA::", "RnD Self Check - FOTA");
            text = text.Replace("::RNDWDL::", "RnD Self Check - WebDL");
            text = text.Replace("::MID::", "MID");
            text = text.Replace("::UNIT::", "Unit");
            text = text.Replace("::VERSION::", swvBox.Text);
            text = text.Replace("::SWFV::", swfvBox.Text);

            //Seting Results to Template

            if (statusBox1.Text == "PASSED")
            {
                text = text.Replace("::RESULTSANITY::", "<font color=\"green\">" + statusBox1.Text + "</font>");
            }
            else if (statusBox1.Text == "FAILED")
            {
                text = text.Replace("::RESULTSANITY::", "<font color=\"red\">" + statusBox1.Text + "</font>");
            }
            else
            {
                text = text.Replace("::RESULTSANITY::", "<font color=\"gray\">" + statusBox1.Text + "</font>");
            }

            if (statusBox3.Text == "PASSED")
            {
                text = text.Replace("::RESULTQFUSE::", "<font color=\"green\">" + statusBox3.Text + "</font>");
            }
            else if (statusBox3.Text == "FAILED")
            {
                text = text.Replace("::RESULTQFUSE::", "<font color=\"red\">" + statusBox3.Text + "</font>");
            }
            else
            {
                text = text.Replace("::RESULTQFUSE::", "<font color=\"gray\">" + statusBox3.Text + "</font>");
            }

            if (statusBox4.Text == "PASSED")
            {
                text = text.Replace("::RESULTHEC::", "<font color=\"green\">" + statusBox4.Text + "</font>");
            }
            else if (statusBox4.Text == "FAILED")
            {
                text = text.Replace("::RESULTHEC::", "<font color=\"red\">" + statusBox4.Text + "</font>");
            }
            else
            {
                text = text.Replace("::RESULTHEC::", "<font color=\"gray\">" + statusBox4.Text + "</font>");
            }

            if (statusBox6.Text == "PASSED")
            {
                text = text.Replace("::RESULTSANITYINTERNAL::", "<font color=\"green\">" + statusBox6.Text + "</font>");
            }
            else if (statusBox6.Text == "FAILED")
            {
                text = text.Replace("::RESULTSANITYINTERNAL::", "<font color=\"red\">" + statusBox6.Text + "</font>");
            }
            else
            {
                text = text.Replace("::RESULTSANITYINTERNAL::", "<font color=\"gray\">" + statusBox6.Text + "</font>");
            }

            if (statusBox8.Text == "PASSED")
            {
                text = text.Replace("::RESULTRNDSIMLOCK::", "<font color=\"green\">" + statusBox8.Text + "</font>");
            }
            else if (statusBox8.Text == "FAILED")
            {
                text = text.Replace("::RESULTRNDSIMLOCK::", "<font color=\"red\">" + statusBox8.Text + "</font>");
            }
            else
            {
                text = text.Replace("::RESULTRNDSIMLOCK::", "<font color=\"gray\">" + statusBox8.Text + "</font>");
            }

            if (statusBox9.Text == "PASSED")
            {
                text = text.Replace("::RESULTRNDFOTA::", "<font color=\"green\">" + statusBox9.Text + "</font>");
            }
            else if (statusBox9.Text == "FAILED")
            {
                text = text.Replace("::RESULTRNDFOTA::", "<font color=\"red\">" + statusBox9.Text + "</font>");
            }
            else
            {
                text = text.Replace("::RESULTRNDFOTA::", "<font color=\"gray\">" + statusBox9.Text + "</font>");
            }

            if (statusBox10.Text == "PASSED")
            {
                text = text.Replace("::RESULTRNDWDL::", "<font color=\"green\">" + statusBox10.Text + "</font>");
            }
            else if (statusBox10.Text == "FAILED")
            {
                text = text.Replace("::RESULTRNDWDL::", "<font color=\"red\">" + statusBox10.Text + "</font>");
            }
            else
            {
                text = text.Replace("::RESULTRNDWDL::", "<font color=\"gray\">" + statusBox10.Text + "</font>");
            }

            if (statusBox11.Text == "PASSED")
            {
                text = text.Replace("::RESULTMID::", "<font color=\"green\">" + statusBox11.Text + "</font>");
            }
            else if (statusBox11.Text == "FAILED")
            {
                text = text.Replace("::RESULTMID::", "<font color=\"red\">" + statusBox11.Text + "</font>");
            }
            else
            {
                text = text.Replace("::RESULTMID::", "<font color=\"gray\">" + statusBox11.Text + "</font>");
            }

            if (statusBox7.Text == "PASSED")
            {
                text = text.Replace("::RESULTUNIT::", "<font color=\"green\">" + statusBox7.Text + "</font>");
            }
            else if (statusBox7.Text == "FAILED")
            {
                text = text.Replace("::RESULTUNIT::", "<font color=\"red\">" + statusBox7.Text + "</font>");
            }
            else
            {
                text = text.Replace("::RESULTUNIT::", "<font color=\"gray\">" + statusBox7.Text + "</font>");
            }


            //Seting Testers to Template.

            if (testerBox1.Text == "N/A" || testerBox1.Text == "Not Assigned")
            {
                text = text.Replace("::TESTER1::", "<font color=\"gray\">" + testerBox1.Text + "</font>");
            }
            else
            {
                text = text.Replace("::TESTER1::", testerBox1.Text);
            }

            if (testerBox3.Text == "N/A" || testerBox3.Text == "Not Assigned")
            {
                text = text.Replace("::TESTER3::", "<font color=\"gray\">" + testerBox3.Text + "</font>");
            }
            else
            {
                text = text.Replace("::TESTER3::", testerBox3.Text);
            }

            if (testerBox4.Text == "N/A" || testerBox4.Text == "Not Assigned")
            {
                text = text.Replace("::TESTER4::", "<font color=\"gray\">" + testerBox4.Text + "</font>");
            }
            else
            {
                text = text.Replace("::TESTER4::", testerBox4.Text);
            }

            if (testerBox6.Text == "N/A" || testerBox6.Text == "Not Assigned")
            {
                text = text.Replace("::TESTER6::", "<font color=\"gray\">" + testerBox6.Text + "</font>");
            }
            else
            {
                text = text.Replace("::TESTER6::", testerBox6.Text);
            }

            if (testerBox7.Text == "N/A" || testerBox7.Text == "Not Assigned")
            {
                text = text.Replace("::TESTER7::", "<font color=\"gray\">" + testerBox7.Text + "</font>");
            }
            else
            {
                text = text.Replace("::TESTER7::", testerBox7.Text);
            }

            if (testerBox8.Text == "N/A" || testerBox8.Text == "Not Assigned")
            {
                text = text.Replace("::TESTER8::", "<font color=\"gray\">" + testerBox8.Text + "</font>");
            }
            else
            {
                text = text.Replace("::TESTER8::", testerBox8.Text);
            }

            if (testerBox9.Text == "N/A" || testerBox9.Text == "Not Assigned")
            {
                text = text.Replace("::TESTER9::", "<font color=\"gray\">" + testerBox9.Text + "</font>");
            }
            else
            {
                text = text.Replace("::TESTER9::", testerBox9.Text);
            }

            if (testerBox10.Text == "N/A" || testerBox10.Text == "Not Assigned")
            {
                text = text.Replace("::TESTER10::", "<font color=\"gray\">" + testerBox10.Text + "</font>");
            }
            else
            {
                text = text.Replace("::TESTER10::", testerBox10.Text);
            }

            if (testerBox11.Text == "N/A" || testerBox11.Text == "Not Assigned")
            {
                text = text.Replace("::TESTER11::", "<font color=\"gray\">" + testerBox11.Text + "</font>");
            }
            else
            {
                text = text.Replace("::TESTER11::", testerBox11.Text);
            }

            text = text.Replace("::COMMENTS::", commentsBox.Text);
            text = text.Replace("::PATH::", detailsBox.Text);
            text = text.Replace("::PATH2::", detailsBox2.Text);


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
        * Returns the final result of the test (html format)
        */


        private void BackButton_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (swfvBox.Text == "")
            {
                MessageBox.Show("Please insert SWFV field!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                GenerateTemplate();
            }
        }



        private void getTestInformationButton_Click_1(object sender, EventArgs e)
        {
            Please_Wait pleaseWait = new Please_Wait();
            pleaseWait.Show();
            Application.DoEvents();
            GetData();
            pleaseWait.Close();
            CheckQeChecklist();
        }
    }
}
