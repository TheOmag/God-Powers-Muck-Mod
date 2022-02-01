/*

using System;
using System.IO;
using System.Windows;
using UnityEngine;

namespace popoutManager
{
    public class main
    {
        //popout opening
        public static int popoutToOpen = 0;
        public static bool OpenPopoutBool = false;
        //active
        public static bool windows = false;
        public static bool active = false;
        public static void run()
        {
            if (settings.file.fileRead[4] != "null")
            {
                active = bool.Parse(settings.file.fileRead[4]);
            }
            else
            {
                settings.file.EditLine(4, "false");
            }
        }
        public static void Update()
        {

        }
        public static void OpenPopout(int popoutId)
        {
            popoutToOpen = popoutId;
            OpenPopoutBool = true;
        }
    }
}
*/