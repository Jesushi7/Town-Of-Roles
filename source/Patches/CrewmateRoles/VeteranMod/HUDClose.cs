using System;
using HarmonyLib;
using TownOfRoles.Roles;
using Object = UnityEngine.Object;

namespace TownOfRoles.CrewmateRoles.VeteranMod
{
    [HarmonyPatch(typeof(Object), nameof(Object.Destroy), typeof(Object))]
    public static class HUDClose
    {
        public static void Postfix(Object obj)
        {
            if (ExileController.Instance == null || obj != ExileController.Instance.gameObject) return;
            if (PlayerControl.LocalPlayer.Is(RoleEnum.Veteran))
            {
                var role = Role.GetRole<Veteran>(PlayerControl.LocalPlayer);
                role.LastAlerted = DateTime.UtcNow;
            }
        }
    }
}