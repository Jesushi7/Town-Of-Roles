using System;
using HarmonyLib;
using TownOfRoles.Roles;
using Object = UnityEngine.Object;

namespace TownOfRoles.ImpostorRoles.MorphlingMod
{
    [HarmonyPatch(typeof(Object), nameof(Object.Destroy), typeof(Object))]
    public static class HUDClose
    {
        public static void Postfix(Object obj)
        {
            if (ExileController.Instance == null || obj != ExileController.Instance.gameObject) return;
            if (PlayerControl.LocalPlayer.Is(RoleEnum.Morphling))
            {
                var role = Role.GetRole<Morphling>(PlayerControl.LocalPlayer);
                role.MorphButton.graphic.sprite = TownOfRoles.SampleSprite;
                role.SampledPlayer = null;
                role.LastMorphed = DateTime.UtcNow;
            }
        }
    }
}