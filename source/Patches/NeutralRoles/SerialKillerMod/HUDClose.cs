using System;
using HarmonyLib;
using TownOfRoles.Roles;
using Object = UnityEngine.Object;

namespace TownOfRoles.CrewmateRoles.SerialKillerMod
{
    [HarmonyPatch(typeof(Object), nameof(Object.Destroy), typeof(Object))]
    public static class HUDClose
    {
        public static void Postfix(Object obj)
        {
            if (ExileController.Instance == null || obj != ExileController.Instance.gameObject) return;
            foreach (var role in Role.GetRoles(RoleEnum.SerialKiller))
            {
                var SerialKiller = (SerialKiller) role;
                SerialKiller.LastKill = DateTime.UtcNow;
            }
        }
    }
}