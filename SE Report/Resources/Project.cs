using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SE_Report.Resources
{
    class Project
    {

        private string status, testType, chronos, timeStarted, tester;
        private string creationDate;
        XmlDocument xml = new XmlDocument();
        string dir = @"\\lgmcfs-sp\SW\CM\SE\TOOLS\NAO MEXER\Projects.xml";

        public Project(string testType, string timeStarted, string creationDate, string chronos, string tester)
        {
            this.testType = testType;
            this.timeStarted = timeStarted;
            this.creationDate = creationDate;
            this.chronos = chronos;
            this.tester = tester;
            status = "In progress";
            toXml();
        }

        /// <summary>
        /// Exports the project to xml
        /// </summary>
        public void toXml()
        {
            if (File.Exists(dir))
            {
                xml.Load(dir);
                XmlNode project = xml.CreateElement("project");
                xml.SelectSingleNode("projects").AppendChild(project);

                XmlNode xmlStatus = xml.CreateElement("status");
                xmlStatus.InnerText = status;
                project.AppendChild(xmlStatus);

                XmlNode testType = xml.CreateElement("testType");
                testType.InnerText = getTestType();
                project.AppendChild(testType);

                XmlNode timeStarted = xml.CreateElement("timeStarted");
                timeStarted.InnerText = getTimeStarted().ToString();
                project.AppendChild(timeStarted);

                XmlNode creationDate = xml.CreateElement("creationDate");
                creationDate.InnerText = getCreationDate().ToString();
                project.AppendChild(creationDate);

                XmlNode chronos = xml.CreateElement("chronos");
                chronos.InnerText = getChronos();
                project.AppendChild(chronos);

                XmlNode assignedTo = xml.CreateElement("assignedTo");
                assignedTo.InnerText = getTester();
                project.AppendChild(assignedTo);
                xml.Save(dir);
            }
        }

        /// <summary>
        /// Returns the tester to which the project is assigned
        /// </summary>
        /// <returns></returns>
        public string getTester()
        {
            return tester;
        }

        /// <summary>
        /// Sets the status
        /// </summary>
        /// <param name="status"></param>
        public void setStatus(string status)
        {
            this.status = status;
        }

        /// <summary>
        /// Returns the status
        /// </summary>
        /// <returns></returns>
        public string getStatus()
        {
            return status;
        }

        /// <summary>
        /// Returns the test type
        /// </summary>
        /// <returns></returns>
        public string getTestType()
        {
            return testType;
        }

        /// <summary>
        /// Returns the Chronos path
        /// </summary>
        /// <returns></returns>
        public string getChronos()
        {
            return chronos;
        }

        /// <summary>
        /// Returns the time when a project started
        /// </summary>
        /// <returns></returns>
        public string getTimeStarted()
        {
            return timeStarted;
        }

        /// <summary>
        /// Returns the time when a software has been created
        /// </summary>
        /// <returns></returns>
        public string getCreationDate()
        {
            return creationDate;
        }

        /// <summary>
        /// Finishes the project
        /// </summary>
        public void finish()
        {
            xml.Load(dir);
            foreach (XmlElement element in xml.GetElementsByTagName("project"))
            {
                foreach (XmlElement element1 in xml.GetElementsByTagName("creationDate"))
                {
                    if (element1.InnerText.Equals(creationDate) && element1.PreviousSibling.PreviousSibling.InnerText.Equals(testType))
                    {
                        element.FirstChild.InnerText = status;
                    }
                }
            }
        }

    }
}
