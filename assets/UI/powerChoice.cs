using BepInEx;
using System.IO;
using UnityEngine;
public class powerChoice
{

    public static float currentAbility = 0;
    public static bool windowActive = false;

    private static string currentAbilityString = "";

    private static bool oneOff = false;
    public static void Window(int windowID)
    {
        GUI.color = Color.yellow;
        GUI.backgroundColor = Color.yellow;
        if (GUI.Button(new Rect(5, 100, 500, 500), patcher.modAbilitysTitle[0]))
        {
            currentAbility = 1;
            windowActive = false;
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 250, 100, 500, 500), patcher.modAbilitysTitle[1]))
        {
            currentAbility = 2;
            windowActive = false;
        }
        if (GUI.Button(new Rect(Screen.width - 500 - 5, 100, 500, 500), patcher.modAbilitysTitle[2]))
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
            currentAbilityString = "laser ability selected";
        }
        else if (currentAbility == 2)
        {
            currentAbilityString = "Kill All selected";
        }
        else if (currentAbility == 3)
        {
            currentAbilityString = "Freeze laser selected";
        }
    }
}