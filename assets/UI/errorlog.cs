using UnityEngine;
public class errorLog : MonoBehaviour
{
    public static string errorText = "";
    public static bool errorLogEnable = false;

    private static bool oneOff = false;
    private static string[] save = new string[] { };
    public static void errorLogWindow1(int windowID)
    {
        if (errorLogEnable && !oneOff)
        {
            errorText = errorText;

            oneOff = true;
        }
        if (GUI.Button(new Rect(500 - 120, 0, 100, 20), "Close"))
        {
            errorLogEnable = false;
        }
        GUI.color = Color.red;
        GUI.Label(new Rect(15, 15, 500, 200), errorText);
    }
}