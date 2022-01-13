using HarmonyLib;
[HarmonyPatch(typeof(PlayerMovement))]
[HarmonyPatch(typeof(MobManager))]
[HarmonyPatch(typeof(Mob))]
[HarmonyPatch(typeof(PlayerStatus))]

[HarmonyPatch("Update", MethodType.Normal)]
public class patcher
{
    public const string modVersion = "1.0.0";
    public const string modTitle = "God Attacks";
    public const string discordServer = "https://discord.gg/MyU9mBR352";
    public const string modPath = "org.Crafterbot.Muck.GodAttacks";
}

