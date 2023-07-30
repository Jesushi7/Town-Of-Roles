using System;
using HarmonyLib;
using TownOfSushi.Roles;
using TownOfSushi.Roles.Cultist;
using Object = UnityEngine.Object;

namespace TownOfSushi.CrewmateRoles.CamouflagerMod
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