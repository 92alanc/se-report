using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Report.Resources
{
    static class IO
    {

        public static string dir, sourceFile, targetFolder, targetFolderSwfv;

        /// <summary>
        /// Copies a binary file to desktop
        /// </summary>
        /// <param name="sourceFile"></param>
        public static void copyToDesktop(string sourceFile)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            if (File.Exists(sourceFile))
            {
                IO.sourceFile = sourceFile;
                string name = Path.GetFileName(sourceFile);
                if (!File.Exists(desktop + @"\" + name))
                {
                    File.Copy(sourceFile, desktop + @"\" + name);
                }
            }
        }

        /// <summary>
        /// Checks if a directory is ready to receive reports
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static bool dir_isReady(string dir, bool sanity)
        {
            try
            {
                string path = dir.Remove(dir.IndexOf("Technical"));
                IO.dir = path;
                bool found1 = false;
                bool found2 = false;
                bool found3 = false;
                bool foundSwfv = false;
                string dir1 = null;
                string dir2 = null;
                foreach (string directory in Directory.GetDirectories(path))
                {
                    if (sanity == false)
                    {
                        if (directory.ToLower().Contains("others"))
                        {
                            targetFolder = directory;
                            found3 = true;
                            break;

                        }
                    }
                    else
                    {
                        if (directory.ToLower().Contains("rst"))
                        {
                            dir1 = directory;
                            found1 = true;
                        }
                        else if (directory.ToLower().Contains("others"))
                        {
                            targetFolderSwfv = directory;
                            foundSwfv = true;
                        }
                        if(found1 && foundSwfv)
                        {
                            break;
                        }
                    }

                }


                if (sanity == true)
                {

                    if (foundSwfv == false)
                    {
                        Directory.CreateDirectory(IO.dir + @"Others");
                        targetFolderSwfv = IO.dir + @"Others";
                    }

                    if (found1)
                    {
                        foreach (string directory in Directory.GetDirectories(dir1))
                        {
                            if (directory.ToLower().Contains("general"))
                            {
                                dir2 = directory;
                                found2 = true;
                                break;
                            }
                        }
                    }

                    if (found2)
                    {
                        foreach (string directory in Directory.GetDirectories(dir2))
                        {
                            if (directory.ToLower().Contains("results"))
                            {
                                targetFolder = directory;
                                found3 = true;
                                break;
                            }
                        }
                    }
                }
                return found3;
         
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        /// <summary>
        /// Returns the directory
        /// </summary>
        /// <returns></returns>
        public static string getDir()
        {
            return dir;
        }


        //returns SE version name
        //string[] files = Directory.GetFiles(@"C:\\\lgmcfs-sp\SW\CM\SE\TOOLS\SE Report", "SE Report");
        //DateTime file = Directory.GetCreationTime(@"C:\\\lgmcfs-sp\SW\CM\SE\TOOLS\SE Report\");
        static void Main(string[] args)
        {
            string[] arquivos = Directory.GetFiles("C:\\");
 
            Console.WriteLine("Arquivos:");
            foreach (string arq in arquivos)
            {
                Console.WriteLine(arq);
            }
 
        }



        /// <summary>
        /// Returns the target folder for reports
        /// </summary>
        /// <returns></returns>
        public static string getTargetFolder()
        {
            return targetFolder;
        }




        /// <summary>
        /// Returns the target folder for reports
        /// </summary>
        /// <returns></returns>
        public static string getTargetFolderSwfv()
        {
            return targetFolderSwfv;
        }

        /// <summary>
        /// Returns the report file name
        /// </summary>
        /// <param name="swv"></param>
        /// <returns></returns>
        public static string getReportFileName(string testType, string swv)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string fileName = "";
            foreach (string name in Directory.GetFiles(desktop))
            {
                if (name.ToLower().Contains("report") && name.Contains(swv))
                {
                    fileName = name;
                    break;
                }
            }
            fileName = fileName.Substring(fileName.IndexOf(testType.ToUpper()));

            return fileName;
        }

        /// <summary>
        /// Copies a report to Chronos
        /// </summary>
        /// <param name="chronos"></param>
        /// <returns></returns>
        public static void copyToChronos(string testType, string swv, string chronos)
        {
            try
            {
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string report = null;
                foreach (string name in Directory.GetFiles(desktop))
                {
                    if (chronos.ToLower().Contains("others"))
                    {
                        if (name.ToLower().Contains(testType.ToLower()) && name.ToLower().Contains(swv.ToLower()) && name.ToLower().Contains("internal report") && name.ToLower().Contains("unit") && name.EndsWith(".pdf"))
                        {
                            report = name;
                            break;
                        }
                    }
                    else
                    {
                        if (name.ToLower().Contains(testType.ToLower()) && name.ToLower().Contains(swv.ToLower()) && name.ToLower().Contains("report") && name.EndsWith(".pdf") && !name.ToLower().Contains("internal report"))
                        {
                            report = name;
                            break;
                        }

                    }


                }
                string fileName = report.Substring(report.LastIndexOf(@"\"));
                File.Copy(report, chronos + fileName);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Creates directories for reports
        /// </summary>
        public static void createDirectories(string testType, bool sanity)
        {
            bool foundRST = false;
            bool foundOthers = false;
            bool foundGeneral = false;
            bool foundTarget = false;
            bool foundSWFV = false;
            string rstDir = null;
            string othersDir = null;
            string generalDir = null;
            string target = null;
            if (sanity == true)
            {
                foreach (string directory in Directory.GetDirectories(dir))
                {
                    if (directory.ToLower().Equals("rst"))
                    {
                        foundRST = true;
                        rstDir = directory;
                    }

                    else if (directory.ToLower().Equals("others"))
                    {
                        foundSWFV = true;
                        othersDir = directory;
                    }

                    if(foundSWFV && foundRST)
                    {
                        break;
                    }
                }
                if (foundRST)
                {
                    foreach (string directory in Directory.GetDirectories(rstDir))
                    {
                        if (testType.ToLower().Equals("sanity") || testType.ToLower().Equals("unit"))
                        {
                            if (directory.ToLower().Contains("general"))
                            {
                                foundGeneral = true;
                                generalDir = directory;
                                break;
                            }
                        }
                        else
                        {
                            if (directory.ToLower().Contains("operator"))
                            {
                                foundGeneral = true;
                                generalDir = directory;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    rstDir = dir + @"RST";
                    Directory.CreateDirectory(rstDir);
                    foundRST = true;
                }

                if (foundSWFV == false)
                {
                    othersDir = dir + @"Others";
                    Directory.CreateDirectory(othersDir);
                    foundSWFV = true;
                    targetFolderSwfv = othersDir;
                }
                else
                {
                    targetFolderSwfv = othersDir;
                }

                if (foundGeneral)
                {
                    foreach (string directory in Directory.GetDirectories(generalDir))
                    {
                        if (testType.ToLower().Equals("sanity") || testType.ToLower().Equals("unit"))
                        {
                            if (directory.ToLower().Contains("results"))
                            {
                                foundTarget = true;
                                target = directory;
                                break;
                            }
                        }
                        else
                        {
                            if (directory.ToLower().Contains("operator"))
                            {
                                foundTarget = true;
                                target = directory;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (testType.ToLower().Equals("sanity") || testType.ToLower().Equals("unit"))
                    {
                        generalDir = rstDir + @"\01. General Information";
                        Directory.CreateDirectory(generalDir);
                        foundGeneral = true;
                    }
                    else
                    {
                        generalDir = rstDir + @"\02. Model Spec";
                        Directory.CreateDirectory(generalDir);
                        foundGeneral = true;
                    }
                }

                if (!foundTarget)
                {
                    if (testType.ToLower().Equals("sanity") || testType.ToLower().Equals("unit"))
                    {
                        target = generalDir + @"\05. Test Results";
                        targetFolder = target;
                        Directory.CreateDirectory(target);
                    }
                    else
                    {
                        target = generalDir + @"\03. Operator Spec and Requirements";
                        targetFolder = target;
                        Directory.CreateDirectory(target);
                    }
                }
            }
            else
            {
                foreach (string directory in Directory.GetDirectories(dir))
                {
                    if (directory.ToLower().Equals("others"))
                    {
                        foundOthers = true;
                        othersDir = dir;
                        break;
                    }
                }
                if (foundOthers == false)
                {
                    othersDir = dir + @"\Others";
                    Directory.CreateDirectory(othersDir);
                }
                targetFolder = othersDir;
            }

        }
     


        /// <summary>
        /// Opens the folder where the report has been saved
        /// </summary>
        public static void openFolder()
        {
            Process.Start(targetFolder);
        }

        /// <summary>
        /// Shows a dialogue asking if the user wants to open the folder or copy the .zip file to desktop
        /// </summary>
        public static void showDialogue(string pathToOpen, string fileToCopy)
        {
            DialogResult result = MessageBox.Show("Would you like to copy the binary file to your desktop? (Yes - copy / No - open folder / Cancel - do nothing)", "Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                copyToDesktop(fileToCopy);
            }
            else if (result == DialogResult.No)
            {
                Process.Start(pathToOpen);
            }
        }

    }
}
