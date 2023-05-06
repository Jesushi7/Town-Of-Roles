using HarmonyLib;
using System;
using UnityEngine;
using static UnityEngine.UI.Button;
using Object = UnityEngine.Object;
using TMPro;
using TownOfRoles.Classes;

namespace TownOfRoles.Patches
{
    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
    public static class MainMenuPatch
    {
        private static Sprite Sprite => TownOfRoles.ToUBanner;
        private static AnnouncementPopUp popUp;
        static void Postfix(MainMenuManager __instance)
        {
            var amongUsLogo = GameObject.Find("bannerLogo_AmongUs");
            if (amongUsLogo != null) {
                amongUsLogo.transform.localScale *= 0.6f;
                amongUsLogo.transform.position += Vector3.up * 0.25f;
            }

            var torLogo = new GameObject("bannerLogo_TownOfRoles");
            torLogo.transform.position = Vector3.up;
            torLogo .transform.localScale /= 1.7f;
            var renderer = torLogo.AddComponent<SpriteRenderer>();
            renderer.sprite = Sprite;

            var InvButton = GameObject.Find("InventoryButton");

            if (InvButton == null)
                return;
        }
    }
}