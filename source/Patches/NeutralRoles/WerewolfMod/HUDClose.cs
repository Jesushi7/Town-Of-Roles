using System;
using HarmonyLib;
using TownOfRoles.Roles;
using Object = UnityEngine.Object;

namespace TownOfRoles.NeutralRoles.WerewolfMod
{
    [HarmonyPatch(typeof(Object), nameof(Object.Destroy), typeof(Object))]
    public static class HUDClose
    {
        public static void Postfix(Object obj)
        {
            if (ExileController.Instance == null || obj != ExileController.Instance.gameObject) return;
            foreach (var role in Role.GetRoles(RoleEnum.Werewolf))
            {
                var werewolf = (Werewolf) role;
                werewolf.LastRampaged = DateTime.UtcNow;
                werewolf.LastKilled = DateTime.UtcNow;
            }
        }
    }
}