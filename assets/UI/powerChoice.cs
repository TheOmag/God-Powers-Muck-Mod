using BepInEx;
using System.IO;
using UnityEngine;
public class powerChoice
{
    public static int currentAbility = -1;
    public static bool windowActive = false;

    private static string currentAbilityString = "";

    //button
    private static bool oneOff = false;
    public static void Window(int windowID)
    {
        //info
        GUI.color = Color.yellow;
        GUI.backgroundColor = Color.yellow;

        //top

        if (oneOff == false)
        {

            foreach (int x in patcher.modAbilitysId)
            {
                int y = x;
                patcher.buttons[y] = patcher.buttons[x] = GUI.Button(patcher.buttonPos[x], patcher.modAbilitysTitle[x]);
            }
        }

        foreach (int x in patcher.modAbilitysId)
        {
            if (patcher.buttons[x] == true)
            {
                currentAbility = x;
            }
        }







        //bottom

        if (GUI.Button(new Rect(Screen.width / 2 - 250, Screen.height - 195, 500, 200), "Turn Off Current Ability"))
        {
            currentAbility = -1;
            Powers.active = false;
            windowActive = false;
        }

        GUI.Label(new Rect(Screen.width / 2 + 400, 1000, 500, 500), "Current Ability: " + currentAbilityString);


        if (currentAbility == -1)
        {
            currentAbilityString = "No ability selected";
        }
        else if (currentAbility == 0)
        {
            currentAbilityString = "laser ability selected";
        }
        else if (currentAbility == 1)
        {
            currentAbilityString = "Kill All selected";
        }
        else if (currentAbility == 2)
        {
            currentAbilityString = "Freeze laser selected";
        }
        else if (currentAbility == 3)
        {
            currentAbilityString = "Mob Push selected";
        }
        else if (currentAbility == 4)
        {
            currentAbilityString = "Infinite Stamina selected";
        }
        else if (currentAbility == 5)
        {
            currentAbilityString = "Infinite Health selected";
        }
        else if (currentAbility == 6)
        {
            currentAbilityString = "Friends selected";
        }
        else if (currentAbility == 7)
        {
            currentAbilityString = "No-clip selected";
        }
        else if (currentAbility == 8)
        {
            currentAbilityString = "Cow spawner selected";
        }
    }
}