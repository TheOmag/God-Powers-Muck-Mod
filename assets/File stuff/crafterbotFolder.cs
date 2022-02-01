using System.IO;
using UnityEngine;

namespace crafterbotsFolderCheck
{
    public class crafterbotsFolder : MonoBehaviour
    {
        public static string FileDirect = "BepInEx\\Crafterbots mod dump";
        public static string fileName = "Crafterbots mod dump";

        public static bool folderExists = false;
        public static void run()
        {
            if (File.Exists(FileDirect))
            {
                folderExists = true;
                settings.file.run();
                if (!patcher.IsModABeta){ versionChecker.checker.run();}
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(FileDirect);
                    settings.file.run();
                    if (!patcher.IsModABeta){versionChecker.checker.run(); }
                }
                catch
                {
                    Debug.LogError("------Unable to create game dump folder------");
                }
            }
        }
    }
}