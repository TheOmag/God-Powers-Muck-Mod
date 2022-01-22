using System.IO;
using UnityEngine;
using System.Net;
namespace settings
{
    public class file
    {
        //file info
        public static string fileDirect = crafterbotsFolderCheck.crafterbotsFolder.FileDirect + "\\afoikaegrowoiergnw2eogrewwe.txt";
        public static string[] fileRead = new string[] { };
        public static string[] fileDefault = new string[] { "---Muck God Powers Internal data storage---", "If you are in this file you probably took a wrong turn, so get out" };
        public static bool fileGood = false;

        //Net
            //public static string fileServerId = "";
        public static void run()
        {
            //fileServerId = versionChecker.checker.fileRead[2];
            try
            {
                if (!File.Exists(fileDirect))
                {
                    CreateFile();
                    fileGood = true;
                }
                else
                {
                    fileGood = true;
                }
            } catch
            {

            }
        }
        public static void CreateFile()
        {
           try
            {
                try
                {
                    File.Delete(fileDirect);
                } catch
                {

                }
                File.WriteAllLines(fileDirect, fileDefault);
            } catch
            {
                errorLog.errorLogEnable = true;
                errorLog.errorText = "Unable to create settings save folder   " + fileDirect;
            }
        }
    }
    public class handler
    {

    }
}
/* file index
 * 
 * Header
 * 
 
 
 
 */