using System;
using HarmonyLib;
using TownOfRoles.Roles;
using Object = UnityEngine.Object;

namespace TownOfRoles.ImpostorRoles.EscapistMod
{
    [HarmonyPatch(typeof(Object), nameof(Object.Destroy), typeof(Object))]
    public static class HUDClose
    {
        public static void Postfix(Object obj)
        {
            if (ExileController.Instance == null || obj != ExileController.Instance.gameObject) return;
            if (PlayerControl.LocalPlayer.Is(RoleEnum.Escapist))
            {
                var role = Role.GetRole<Escapist>(PlayerControl.LocalPlayer);
                role.EscapeButton.graphic.sprite = TownOfRoles.MarkSprite;
                role.LastEscape = DateTime.UtcNow;
            }
        }
    }
}