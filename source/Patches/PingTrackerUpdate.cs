using HarmonyLib;
using UnityEngine;

namespace TownOfRoles
{

    [HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
    public static class PingTracker_Update
    {
        [HarmonyPrefix]
        public static void Prefix(PingTracker __instance)
        {
            if (!__instance.GetComponentInChildren<SpriteRenderer>())
            {
                var spriteObject = new GameObject("Logo");
                spriteObject.AddComponent<SpriteRenderer>().sprite = TownOfRoles.Logo;
                spriteObject.transform.parent = __instance.transform;
                spriteObject.transform.localPosition = new Vector3(-1f, -0.3f, -1);
                spriteObject.transform.localScale *= 0.72f;
            }
        }        

        [HarmonyPostfix]
        public static void Postfix(PingTracker __instance)
        {
            var position = __instance.GetComponent<AspectPosition>();
            position.DistanceFromEdge = new Vector3(3.6f, 0.1f, 0);
            position.AdjustPosition();

            __instance.text.text =
                "<color=#9fcc90>TownOfRoles v1.1.0</color> <color=#FF0000FF>BETA</color>\n" +
                $"Ping: {AmongUsClient.Instance.Ping}ms\n" +
                "Modded By: <color=#9fcc90>Jsushi</color>\nFormerly From <color=#9fcc90>Town Of Us Reactivated</color>\n" +                
                (AmongUsClient.Instance.GameState != InnerNet.InnerNetClient.GameStates.Started
                    ? "Helped From: <color=#9fcc90>AlchlcDvl</color>\nArtwork By <color=#9fcc90>Lotty</color>" : "");
        }
    }
}
