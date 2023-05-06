using System;
using HarmonyLib;
using TownOfRoles.Roles;
using Object = UnityEngine.Object;

namespace TownOfRoles.NeutralRoles.GuardianAngelMod
{
    [HarmonyPatch(typeof(Object), nameof(Object.Destroy), typeof(Object))]
    public static class HUDClose
    {
        public static void Postfix(Object obj)
        {
            if (ExileController.Instance == null || obj != ExileController.Instance.gameObject) return;
            if (PlayerControl.LocalPlayer.Is(RoleEnum.GuardianAngel))
            {
                var role = Role.GetRole<GuardianAngel>(PlayerControl.LocalPlayer);
                role.LastProtected = DateTime.UtcNow;
            }
        }
    }
}