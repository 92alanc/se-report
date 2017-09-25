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

namespace SE_Report.Forms
{
    public partial class AddTests : Form
    {

        public AddTests()
        {
            InitializeComponent();
        }


        /// <summary>
        /// When the user clicks the 'x' button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTests_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }



        //Check if there is blank tests.
        public void CheckBlankTests()
        {
            string path = PathBox.Text;


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



                int checkBlank = 0;
                string x = "http://10.193.225.22:9596/service.svc/getRelease?Chronosid=";
                string y = id;
                string all = string.Concat(x, y);
                WebClient client = new WebClient();
                Stream stream = client.OpenRead(all);
                StreamReader reader = new StreamReader(stream);
                Newtonsoft.Json.Linq.JObject Json = Newtonsoft.Json.Linq.JObject.Parse(reader.ReadLine());

                int length = Json["Tests"].Count();


                for (int i = 0; i < length; i++)
                {
                    var Status = ((string)Json["Tests"][i]["Status"]);
                    var TypeTest = ((string)Json["Tests"][i]["Type"]);


                    if (Status == "" || Status == "NOT TESTED")
                    {
                        checkBlank = 1;
                    }

                }

                if (checkBlank == 1)
                {
                    MessageBox.Show("This project has some blank tests or tests that has not been tested, check if tests are added correctly!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Check if there is Unit tests
        public void CheckUnitTests()
        {
            string path = PathBox.Text;

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


                int checkUnit = 0;
                string x = "http://10.193.225.22:9596/service.svc/getRelease?Chronosid=";
                string y = id;
                string all = string.Concat(x, y);
                WebClient client = new WebClient();
                Stream stream = client.OpenRead(all);
                StreamReader reader = new StreamReader(stream);
                Newtonsoft.Json.Linq.JObject Json = Newtonsoft.Json.Linq.JObject.Parse(reader.ReadLine());

                int length = Json["Tests"].Count();



                for (int i = 0; i < length; i++)
                {
                    var TypeTest = ((string)Json["Tests"][i]["Type"]);

                    if (TypeTest == "Unit")
                    {
                        checkUnit = 1;
                    }

                }

            if(checkUnit == 1)
            {
                MessageBox.Show("This project has some unit tests, they must be added manually!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //Check if there is failed tests
        public void CheckFailedTests()
        {
            string path = PathBox.Text;

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



                string x = "http://10.193.225.22:9596/service.svc/getRelease?Chronosid=";
                string y = id;
                string all = string.Concat(x, y);
                WebClient client = new WebClient();
                Stream stream = client.OpenRead(all);
                StreamReader reader = new StreamReader(stream);
                Newtonsoft.Json.Linq.JObject Json = Newtonsoft.Json.Linq.JObject.Parse(reader.ReadLine());

                int length = Json["Tests"].Count();

                int countFailed = 0;

                for (int i = 0; i < length; i++)
                {
                    var Status = ((string)Json["Tests"][i]["Status"]);
                    var failedTest = ((string)Json["Tests"][i]["Type"]);

                    if(Status == "FAILED")
                    {
                        countFailed = 1;
                    }

                }

                if(countFailed == 1)
                {
                    MessageBox.Show("This project has some failed tests, check if the tests are added correctly!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //Inserting Sanity Test
        public void InsertSanityTest()
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

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://10.193.225.22:9596/service.svc/insertTest?");
            httpWebRequest.ContentType = "Application/Json";
            httpWebRequest.Method = "POST";
            string sanity = "{\"ChronosID\":\"" + id + "\"," + "\"Type\":\"Sanity Official\"}";


            using (var streamWriterSanity = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriterSanity.Write(sanity);
            }

            var httpResponseSanity = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReaderSanity = new StreamReader(httpResponseSanity.GetResponseStream()))
            {
                var resultSanity = streamReaderSanity.ReadToEnd();
            }
        }



        // Inserting Afw test
        public void InsertAfwTest()
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

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://10.193.225.22:9596/service.svc/insertTest?");
            httpWebRequest.ContentType = "Application/Json";
            httpWebRequest.Method = "POST";
            string afw = "{\"ChronosID\":\"" + id + "\"," + "\"Type\":\"AFW\"}";



            using (var streamWriterAfw = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriterAfw.Write(afw);
            }

            var httpResponseAfw = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReaderAfw = new StreamReader(httpResponseAfw.GetResponseStream()))
            {
                var resultAfw = streamReaderAfw.ReadToEnd();
            }

        }




        // Inserting Qfuse test
        public void InsertQfuseTest()
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

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://10.193.225.22:9596/service.svc/insertTest?");
            httpWebRequest.ContentType = "Application/Json";
            httpWebRequest.Method = "POST";
            string qfuse = "{\"ChronosID\":\"" + id + "\"," + "\"Type\":\"QFUSE\"}";



            using (var streamWriterQfuse = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriterQfuse.Write(qfuse);
            }

            var httpResponseQfuse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReaderQfuse = new StreamReader(httpResponseQfuse.GetResponseStream()))
            {
                var resultQfuse = streamReaderQfuse.ReadToEnd();
            }
        }





        // Inserting Hec test
        public void InsertHecTest()
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

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://10.193.225.22:9596/service.svc/insertTest?");
            httpWebRequest.ContentType = "Application/Json";
            httpWebRequest.Method = "POST";
            string hec = "{\"ChronosID\":\"" + id + "\"," + "\"Type\":\"HEC\"}";



            using (var streamWriterHec = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriterHec.Write(hec);
            }

            var httpResponseHec = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReaderHec = new StreamReader(httpResponseHec.GetResponseStream()))
            {
                var resultHec = streamReaderHec.ReadToEnd();
            }
        }





        // Inserting Atos test
        public void InsertAtosTest()
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

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://10.193.225.22:9596/service.svc/insertTest?");
            httpWebRequest.ContentType = "Application/Json";
            httpWebRequest.Method = "POST";
            string atos = "{\"ChronosID\":\"" + id + "\"," + "\"Type\":\"ATOS\"}";



            using (var streamWriterAtos = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriterAtos.Write(atos);
            }

            var httpResponseAtos = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReaderAtos = new StreamReader(httpResponseAtos.GetResponseStream()))
            {
                var resultAtos = streamReaderAtos.ReadToEnd();
            }
        }




        // Inserting Sanity Internal test
        public void InsertSanityInternalTest()
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

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://10.193.225.22:9596/service.svc/insertTest?");
            httpWebRequest.ContentType = "Application/Json";
            httpWebRequest.Method = "POST";
            string sanityInternal = "{\"ChronosID\":\"" + id + "\"," + "\"Type\":\"Sanity Internal\"}";



            using (var streamWriterSanityInternal = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriterSanityInternal.Write(sanityInternal);
            }

            var httpResponseSanityInternal = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReaderSanityInternal = new StreamReader(httpResponseSanityInternal.GetResponseStream()))
            {
                var resultSanityInternal = streamReaderSanityInternal.ReadToEnd();
            }
        }




        private void addTestsButton_Click(object sender, EventArgs e)
        {
            if(newBoardBtn.Checked)
            {
                InsertSanityTest();
                InsertAfwTest();
                InsertQfuseTest();
                InsertHecTest();
                InsertAtosTest();
                InsertSanityInternalTest();
                CheckUnitTests();
                CheckBlankTests();
                MessageBox.Show("Tests for New Board has been created successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (sameBoardBtn.Checked)
            {
                InsertSanityTest();
                InsertQfuseTest();
                InsertAtosTest();
                CheckFailedTests();
                CheckUnitTests();
                CheckBlankTests();
                MessageBox.Show("Tests for Same Board has been created successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (cupssBtn.Checked)
            {
                InsertSanityTest();
                InsertQfuseTest();
                CheckFailedTests();
                CheckUnitTests();
                CheckBlankTests();
                MessageBox.Show("Tests for CUPSS has been created successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
