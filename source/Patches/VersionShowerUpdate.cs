using HarmonyLib;
using TMPro;
using UnityEngine;
using UObject = UnityEngine.Object;

namespace TownOfRoles
{
    [HarmonyPriority(Priority.VeryHigh)] // to show this message first, or be overrided if any plugins do
    [HarmonyPatch(typeof(VersionShower), nameof(VersionShower.Start))]
    public static class VersionShowerUpdate
    {
        public static GameObject Logo;        
        public static void Prefix(MainMenuManager __instance)
        {
            ModUpdater.LaunchUpdater();

            if (!Logo)
            {
                Logo = new GameObject("TownOfRolesLogo");
                Logo.transform.position = new (2f, -0.1f, 100f);
                Logo.AddComponent<SpriteRenderer>().sprite = TownOfRoles.ToUBanner;
                Logo.transform.SetParent(__instance.rightPanelMask.transform);
            }
        }
    }
}
