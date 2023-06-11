using System;
using HarmonyLib;
using TownOfRoles.Roles;
using Object = UnityEngine.Object;

namespace TownOfRoles.NeutralRoles.GuardianMod
{
    [HarmonyPatch(typeof(Object), nameof(Object.Destroy), typeof(Object))]
    public static class HUDClose
    {
        public static void Postfix(Object obj)
        {
            if (ExileController.Instance == null || obj != ExileController.Instance.gameObject) return;
            if (PlayerControl.LocalPlayer.Is(RoleEnum.Guardian))
            {
                var role = Role.GetRole<Guardian>(PlayerControl.LocalPlayer);
                role.LastProtected = DateTime.UtcNow;
            }
        }
    }
}