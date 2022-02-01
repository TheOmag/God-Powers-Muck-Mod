using System.IO;
using System.Net;
using UnityEngine;

namespace versionChecker
{
    public class checker : MonoBehaviour
    {
        private static string githubFileChecker = "http://versioncheckers.crafterbot.com/MuckGodPower";
        private static string placeToStoreCheckerFileDirect = crafterbotsFolderCheck.crafterbotsFolder.FileDirect + "\\God Power.txt";
        private static WebClient download = new WebClient();

        public static string[] fileRead = { "" };
        public static void run()
        {
            if (!connectToInternet())
            {
                errorLog.errorLogEnable = true;
                errorLog.errorText = "Please connect to the internet";
                Debug.Log("Please connect to internet");
            }
            else
            {

                Debug.Log("Connected to internet");
                try
                {
                    download.DownloadFile(githubFileChecker, placeToStoreCheckerFileDirect);
                    fileRead = File.ReadAllLines(placeToStoreCheckerFileDirect);
                    if (patcher.modVersion != fileRead[0])
                    {
                        announcementsPopout.InGameUI.annoucementTitle = "New Update - " + patcher.modTitle + " - " + fileRead[0];
                        announcementsPopout.InGameUI.annoucementText = fileRead[1];
                        announcementsPopout.InGameUI.newVersion = true;
                        errorLog.errorLogEnable = true;
                        errorLog.errorText = "Update needed - " + patcher.modTitle + " " + fileRead[0] + " --- " + fileRead[1];
                        Debug.LogWarning("Update needed " + patcher.modTitle);
                    }
                }
                catch
                {
                    errorLog.errorLogEnable = true;
                    errorLog.errorText = "Unable to download version checker, if this problem continues join my discord server to report it. - " + patcher.discordServer;
                    Debug.LogError("Unable to download version checker, if this problem continues join my discord server to report it. - " + patcher.discordServer);
                }
                //CheckAnnouncements();
            }
        }
        /*public static void CheckAnnouncements()
        {
            try
            {
                settings.file.fileRead = File.ReadAllLines(settings.file.fileDirect);
                if (settings.file.fileRead[3] != fileRead[2])
                {
                    settings.file.EditLine(3, fileRead[2]);
                    //announcment
                    announcementsPopout.InGameUI.annoucementTitle = fileRead[3];
                    announcementsPopout.InGameUI.annoucementText = fileRead[4];
                    announcementsPopout.InGameUI.normalAnnouncement = true;
                }
            }
            catch
            {
                errorLog.errorLogEnable = true;
                errorLog.errorText = "Error: announcment system: code 1";
            }
        }*/
        private static WebClient check = new WebClient();
        private static bool connectToInternet()
        {
            try
            {
                using (check.OpenRead("http://google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
