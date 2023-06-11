using System;
using HarmonyLib;
using TownOfRoles.Roles;
using TownOfRoles.Roles.Cultist;
using Object = UnityEngine.Object;

namespace TownOfRoles.CrewmateRoles.CamouflagerMod
{
    [HarmonyPatch(typeof(Object), nameof(Object.Destroy), typeof(Object))]
    public static class HUDClose
    {
        public static void Postfix(Object obj)
        {
            if (ExileController.Instance == null || obj != ExileController.Instance.gameObject) return;
            if (PlayerControl.LocalPlayer.Is(RoleEnum.Camouflager))
            {
                var role = Role.GetRole<Camouflager>(PlayerControl.LocalPlayer);
                role.LastSwooped = DateTime.UtcNow;
            }
        }
    }
}