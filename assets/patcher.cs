using HarmonyLib;
using UnityEngine;
[HarmonyPatch(typeof(PlayerMovement))]
[HarmonyPatch(typeof(MobManager))]
[HarmonyPatch(typeof(Mob))]
[HarmonyPatch(typeof(PlayerStatus))]

[HarmonyPatch("Update", MethodType.Normal)]
public class patcher
{
    //mod info
    public const string modVersion = "1.0.4";
    public const string modTitle = "God Powers";
    public const string discordServer = "https://discord.gg/MyU9mBR352";
    public const string modPath = "org.Crafterbot.Muck.GodAttacks";
    public const bool IsModABeta = false;

    //mod powers
    public static string[] modAbilitysTitle = new string[] { "Laser", "Kill all", "Freeze Lazer" };
    public static int[] modAbilitysId = new int[] { 0, 1, 2 };
    public static int NumberOfAbility = 2; //starts at -1

    //buttons
    public static bool[] buttons = new bool[] { false, false, false };
    public static Rect[] buttonPos = new Rect[] { new Rect(100, 100, 100, 100), new Rect(300, 100, 100, 100), new Rect(500, 100, 100, 100) };
    public static int[] buttonArrayPlaceholder = new int[] { 0, 1, 2 };
}

/*
 Index
 
 new Rect(100, 100, 100, 100), new Rect(300, 100, 100, 100), new Rect(500, 100, 100, 100), new Rect(700, 100, 100, 100)
 
 
 
 */