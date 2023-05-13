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
        public static void Postfix(VersionShower __instance)
        {
            var gameObject = GameObject.Find("bannerLogo_AmongUs");


            if (gameObject != null)
            {
                var textMeshPro = UObject.Instantiate(__instance.text);
                textMeshPro.transform.position = new(0f, -0.3f, 0f);
                textMeshPro.text = $"<color=#9fcc90>Modded By Jsushi - v1.0.5</color> <color=#FF0000FF>BETA Version</color>\n";
                textMeshPro.alignment = TextAlignmentOptions.Center;
                textMeshPro.fontSize *= 0.75f;
                textMeshPro.fontStyle = FontStyles.Bold;
                textMeshPro.transform.SetParent(gameObject.transform);
            }
        }
    }
}
