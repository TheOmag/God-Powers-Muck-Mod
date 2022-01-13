using BepInEx;
using System.IO;
using UnityEngine;
public class powerChoice
{
    public static float currentAbility = 0;
    public static bool windowActive = false;

    private static string currentAbilityString = "";
    public static void Window(int windowID)
    {
        GUI.color = Color.yellow;
        GUI.backgroundColor = Color.yellow;
        if (GUI.Button(new Rect(5, 100, 500, 500), "Lazer"))
        {
            currentAbility = 1;
            windowActive = false;
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 250, 100, 500, 500), "Kill All"))
        {
            currentAbility = 2;
            windowActive = false;
        }
        if (GUI.Button(new Rect(Screen.width - 500 - 5, 100, 500, 500), "Freeze Lazer"))
        {
            currentAbility = 3;
            windowActive = false;
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 250, 700, 500, 250), "Turn Off Current Ability"))
        {
            currentAbility = 0;
            main.active = false;
            windowActive = false;
        }
        GUI.Label(new Rect(Screen.width / 2 + 400, 1000, 500, 500), "Current Ability: " + currentAbilityString);


        if (currentAbility == 0)
        {
            currentAbilityString = "No ability selected";
        }
        else if (currentAbility == 1)
        {
            currentAbilityString = "Lazer ability selected";
        }
        else if (currentAbility == 2)
        {
            currentAbilityString = "Kill All selected";
        }
        else if (currentAbility == 3)
        {
            currentAbilityString = "Freeze lazer selected";
        }
    }


    //for later us
    /*
    public static AssetBundle assetbundle = null;
    public static GameObject ui = null;
    public static GameObject uiAssetbundleLocation = null;
    public static void LoadUI()
    {
        try
        {
            Debug.Log("loading UI");
            try
            {
                assetbundle = AssetBundle.LoadFromFile(crafterbotsFolderCheck.crafterbotsFolder.FileDirect + "\\ui");
                uiAssetbundleLocation = assetbundle.LoadAsset<GameObject>("ui");
            }
            catch
            {
                Debug.LogError("Loading asset(assetbundle, uiAssetbundleLocation), failed " + patcher.modTitle + " - " + patcher.discordServer);

            }
            ui = GameObject.Instantiate<GameObject>(uiAssetbundleLocation);
        }
        catch
        {
            try
            {
                if (!File.Exists(crafterbotsFolderCheck.crafterbotsFolder.FileDirect + "\\ui"))
                {
                    Debug.LogError("Asset not found ");
                }
                else
                {
                    try
                    {
                        assetbundle = AssetBundle.LoadFromFile(crafterbotsFolderCheck.crafterbotsFolder.FileDirect + "\\ui");
                    }
                    catch
                    {
                        errorLog.errorLogEnable = true;
                        errorLog.errorText = "Unknown error - this issue has something to do with the asset file not being found or not being able to download it: ";
                        Debug.LogError("Unknown error: " + patcher.discordServer + " -- " + patcher.modTitle);
                    }
                }
            }
            catch
            {
                Debug.Log("Total failure " + patcher.modTitle + " " + patcher.discordServer);
            }
        }
    }
    */
}

