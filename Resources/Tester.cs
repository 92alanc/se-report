using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Report.Resources
{
    class Tester
    {

        private string name;
        private bool available;

        public Tester(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Tells if the tester is available
        /// </summary>
        /// <returns></returns>
        public bool isAvailable()
        {
            return available;
        }

        /// <summary>
        /// Changes the availability
        /// </summary>
        public void changeAvailability()
        {
            available = !available;
        }

        /// <summary>
        /// Returns the user name
        /// </summary>
        /// <returns></returns>
        public string getName()
        {
            return name;
        }

        /// <summary>
        /// Returns available/busy
        /// </summary>
        /// <returns></returns>
        public string getAvailability()
        {
            if (isAvailable())
            {
                return "Available";
            }
            else
            {
                return "Busy";
            }
        }

        /// <summary>
        /// Sets the availability
        /// </summary>
        /// <param name="available"></param>
        public void setAvailability(bool available)
        {
            this.available = available;
        }

    }
}
