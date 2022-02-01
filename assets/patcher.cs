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
    public const string modVersion = "1.0.5";
    public const string modTitle = "God Powers";
    public const string discordServer = "https://discord.gg/MyU9mBR352";
    public const string modPath = "org.Crafterbot.Muck.GodAttacks";
    public const string settingsId = "1";
    public const string githubPage = "https://github.com/TheOmag/God-Powers-Muck-Mod";

    public const bool IsModABeta = false;

    //mod powers
    public static string[] modAbilitysTitle = new string[] { "Laser", "Kill All", "Freeze Lazer", "Mob Push", "Inf Stamina", "Inf Health", "Leave Laser", "No-clip" };
    public static int[] modAbilitysId = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };

    //buttons
    public static bool[] buttons = new bool[] { false, false, false, false, false, false, false, false };
    public static Rect[] buttonPos = new Rect[] { new Rect(100, 100, 100, 100), new Rect(300, 100, 100, 100), new Rect(500, 100, 100, 100), new Rect(700, 100, 100, 100), new Rect(900, 100, 100, 100), new Rect(1100, 100, 100, 100), new Rect(1300, 100, 100, 100), new Rect(1500, 100, 100, 100), new Rect(1700, 100, 100, 100) };
}