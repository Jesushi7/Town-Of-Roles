using HarmonyLib;
using TownOfRoles.Roles;
using Object = UnityEngine.Object;
using System;

namespace TownOfRoles.CrewmateRoles.TrapperRole
{
    [HarmonyPatch(typeof(Object), nameof(Object.Destroy), typeof(Object))]
    public static class HUDClose
    {
        public static void Postfix(Object obj)
        {
            if (ExileController.Instance == null || obj != ExileController.Instance.gameObject) return;
            foreach (var role in Role.GetRoles(RoleEnum.Trapper))
            {
                var trapper = (Trapper)role;
                trapper.LastTrapped = DateTime.UtcNow;
                trapper.trappedPlayers.Clear();
                if (CustomGameOptions.TrapsRemoveOnNewRound)
                {
                    trapper.traps.ClearTraps();
                }
            }
        }
    }
}
