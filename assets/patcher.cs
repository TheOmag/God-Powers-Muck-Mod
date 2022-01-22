using HarmonyLib;
[HarmonyPatch(typeof(PlayerMovement))]
[HarmonyPatch(typeof(MobManager))]
[HarmonyPatch(typeof(Mob))]
[HarmonyPatch(typeof(PlayerStatus))]

[HarmonyPatch("Update", MethodType.Normal)]
public class patcher
{
    //mod info
    public const string modVersion = "1.0.3";
    public const string modTitle = "God Powers";
    public const string discordServer = "https://discord.gg/MyU9mBR352";
    public const string modPath = "org.Crafterbot.Muck.GodAttacks";
    public const bool IsModABeta = false;

    //mod powers
    public static string[] modAbilitysTitle = new string[] { "Laser", "Kill all", "Freeze Lazer" };
    //public static int[] modAbilitysId = new int[] { 1, 2, 3 };
}

