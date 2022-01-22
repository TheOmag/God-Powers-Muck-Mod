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
            settings.file.run();
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
                    Debug.LogWarning("Mark 1");
                    fileRead = File.ReadAllLines(placeToStoreCheckerFileDirect);
                    Debug.LogWarning("Mark 2");

                    if (patcher.modVersion == fileRead[0])
                    {
                    }
                    else
                    {
                        announcements.UI.annoucementTitle = "New Update - " + patcher.modTitle + " - " + versionChecker.checker.fileRead[0];
                        announcements.UI.Run();
                        announcements.UI.annoucementText = fileRead[1];
                        announcements.UI.newVersion = true;
                        errorLog.errorLogEnable = true;
                        errorLog.errorText = "Update needed - " + patcher.modTitle + " " + fileRead[0] + " --- " + fileRead[1]; 
                        Debug.LogWarning("Update needed " + patcher.modTitle);
                    }
                }
                catch
                {
                    errorLog.errorLogEnable = true;
                    errorLog.errorText = "Unable to download version checker, if this problem continues join my discord server to report it.";
                    Debug.LogError("Unable to download version checker, if this problem continues join my discord server to report it. - " + patcher.discordServer);
                }
            }
        }
        private static void try1()
        {
            try
            {
                File.Delete(placeToStoreCheckerFileDirect);
            }
            catch
            {
                Debug.LogError("Unable to delete version file, if this is the first time this mod is loaded this is normal.");
            }
        }


        private static WebClient check = new WebClient();
        private static bool connectToInternet()
        {
            try
            {
                using (check.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
