using UnityEngine;
public class No_clip
{
    private static Vector3 save = new Vector3();
    public static void run()
    {
        foreach (var x in Resources.FindObjectsOfTypeAll<Collider>())
        {
            try
            {
                if (x.isTrigger)
                {
                    x.isTrigger = false;
                }
                else
                {
                    x.isTrigger = true;
                }
            }
            catch { }
        }
    }
    public static void stop()
    {
        foreach (var x in Resources.FindObjectsOfTypeAll<Collider>())
        {
            try
            {
                if (x.isTrigger)
                {
                    x.isTrigger = false;
                }
                else
                {
                    x.isTrigger = true;
                }
            }
            catch { }
        }
    }
}

