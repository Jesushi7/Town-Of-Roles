using HarmonyLib;

namespace TownOfRoles
{
    [HarmonyPriority(Priority.VeryHigh)] // to show this message first, or be overrided if any plugins do
    [HarmonyPatch(typeof(VersionShower), nameof(VersionShower.Start))]
    public static class VersionShowerUpdate
    {
        public static void Postfix(VersionShower __instance)
        {
            var text = __instance.text;
            text.text += "- Modded By <color=#9fcc90>Jsushi v" + TownOfRoles.VersionString + "</color>";
        }
    }
}
