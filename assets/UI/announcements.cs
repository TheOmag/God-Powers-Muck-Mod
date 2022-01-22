using UnityEngine;
using System.Diagnostics;

namespace announcements
{ 
    public class UI : MonoBehaviour
    {
        public static bool newVersion = false;
        public static string annoucementText = "";
        public static string annoucementTitle = ""; 
        public static void Run()
        {

        }
        public static void Window(int windowID)
        {
            GUI.Label(new Rect(5, 20, 215, 200), annoucementText);
            if(GUI.Button(new Rect(1, 180, 130, 20), "Update"))
            {
                Process.Start("https://muck.thunderstore.io/package/Crafterbot/God_Powers/"); 
                Process.Start("https://github.com/TheOmag/How-to-update-Muck-mod-/blob/main/README.md");
                Application.Quit();
            }
            if (GUI.Button(new Rect(131, 180, 220 - 130, 20), "Close"))
            {
                newVersion = false;
            }
            if(GUI.Button(new Rect(1, 200, 220, 20), "Help"))
            {
                Process.Start("https://github.com/TheOmag/How-to-update-Muck-mod-/blob/main/README.md");
            }
        }
    }
}
