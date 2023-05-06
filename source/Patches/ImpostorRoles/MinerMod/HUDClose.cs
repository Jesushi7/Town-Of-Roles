using System;
using HarmonyLib;
using TownOfRoles.Roles;
using Object = UnityEngine.Object;

namespace TownOfRoles.ImpostorRoles.MinerMod
{
    [HarmonyPatch(typeof(Object), nameof(Object.Destroy), typeof(Object))]
    public static class HUDClose
    {
        public static void Postfix(Object obj)
        {
            if (ExileController.Instance == null || obj != ExileController.Instance.gameObject) return;
            if (PlayerControl.LocalPlayer.Is(RoleEnum.Miner))
            {
                var role = Role.GetRole<Miner>(PlayerControl.LocalPlayer);
                role.LastMined = DateTime.UtcNow;
            }
        }
    }
}