using System.IO;
using UnityEngine;
namespace settings
{
    public class file
    {
        //file info
        public static string fileDirect = crafterbotsFolderCheck.crafterbotsFolder.FileDirect + "\\MuckGodPowersInternalStorage233528525573768547437637783736613474.txt";
        public static string[] fileRead = new string[] { "" };

        public static bool fileGood = false;

        //Net
        public static void run()
        {
            try
            {
                if (!File.Exists(fileDirect))
                {
                    CreateFile();
                    fileGood = true;
                }
                else
                {
                    CheckFileID();
                }
                //popoutManager.main.run();
            }
            catch
            {

            }
        }
        public static void CheckFileID()
        {
            if (fileDefault[1] == patcher.settingsId)
            {
                CreateFile();
            }
            fileGood = true;
        }
        public static void CreateFile()
        {
            try
            {
                try
                {
                    File.Delete(fileDirect);
                }
                catch
                {

                }
                File.WriteAllLines(fileDirect, fileDefault);
            }
            catch
            {
                errorLog.errorLogEnable = true;
                errorLog.errorText = "Unable to create settings save folder   " + fileDirect;
            }
        }
        public static void EditLine(int lineNum, string textToAdd)
        {
            try
            {
                string[] fileSave = new string[] { };
                fileSave = File.ReadAllLines(fileDirect);
                fileSave[lineNum] = textToAdd;
                File.Delete(fileDirect);
                File.WriteAllLines(fileDirect, fileSave);
                fileRead = File.ReadAllLines(fileDirect);
            }
            catch
            {
                Debug.LogError("Settings file complete failure: code 0");
                Debug.LogError("Look at github page to find error " + patcher.githubPage);

                errorLog.errorLogEnable = true;
                errorLog.errorText = "Settings file complete failure: code 0" +
                    "Look at github page to find error " + patcher.githubPage;
            }
        }
        public static string[] fileDefault = new string[]
        {
            "---Muck God Powers Internal data storage---", //#0
            patcher.settingsId, //#1
            "If you are in this file you probably took a wrong turn, so get out", //#2
            "0", //#3 announcment number, if this number is less than the version checker announcement number it will make an announcement and update the number.
            ""
        };
    }
}
