using Data_Structures.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SE_Report.Resources
{
    class TesterList : SinglyLinkedList<Tester>
    {

        XmlDocument xml = new XmlDocument();
        string dir = @"\\lgmcfs-sp\SW\CM\SE\TOOLS\NAO MEXER\Testers.xml";

        /// <summary>
        /// Returns the tester's name
        /// </summary>
        /// <returns></returns>
        public string getTesterName()
        {
            string name = "";

            xml.Load(dir);

            foreach (XmlElement element in xml.GetElementsByTagName("tester"))
            {
                foreach (XmlElement element1 in xml.GetElementsByTagName("id"))
                {
                    if (element1.InnerText.Equals(Environment.UserName))
                    {
                        name = element1.NextSibling.InnerText;
                    }
                }
            }
            return name;
        }

        /// <summary>
        /// Looks for available testers to add to the list
        /// </summary>
        public void refresh()
        {
            xml.Load(dir);
            foreach (XmlElement element1 in xml.GetElementsByTagName("id"))
            {
                Tester tester = new Tester(element1.InnerText);
                if (element1.NextSibling.NextSibling.InnerText.Equals("Available"))
                {
                    tester.setAvailability(true); 
                }
                else
                {
                    tester.setAvailability(false);
                }
                add(tester);
            }
        }

        /// <summary>
        /// Returns you
        /// </summary>
        /// <returns></returns>
        public Tester getTester()
        {
            Tester tester = null;
            for (int i = 0; i < getCount(); i++)
            {
                if (get(i).getName().Equals(Environment.UserName))
                {
                    tester = get(i);
                    break;
                }
            }
            return tester;
        }

        /// <summary>
        /// Exports the tester's status to xml
        /// </summary>
        public void toXml()
        {
            xml.Load(dir);
            foreach (XmlElement element in xml.GetElementsByTagName("status"))
            {
                if (element.PreviousSibling.PreviousSibling.InnerText.Equals(Environment.UserName))
                {
                    element.InnerText = getTester().getAvailability();
                    break;
                }
            }
            xml.Save(dir);
        }

    }

}
