/*using HarmonyLib;
using Object = UnityEngine.Object;
using System;
using TownOfUs.Roles;
using TownOfUs;

namespace TownOfUs.NeutralRoles.VultureMod
{
    [HarmonyPatch(typeof(Object), nameof(Object.Destroy), typeof(Object))]
    public static class HUDClose
    {
        public static void Postfix(Object __instance)
        {
            if (ExileController.Instance == null || __instance != ExileController.Instance.gameObject)
                return;

            foreach (var role in Role.GetRoles(RoleEnum.Vulture))
            {
                var role2 = (Vulture) role;
                role2.LastEaten = DateTime.UtcNow;
            }
        }
    }
}*/