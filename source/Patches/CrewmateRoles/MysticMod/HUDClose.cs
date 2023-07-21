using System;
using HarmonyLib;
using TownOfSushi.Roles;
using Object = UnityEngine.Object;

namespace TownOfSushi.CrewmateRoles.MysticMod
{
    [HarmonyPatch(typeof(Object), nameof(Object.Destroy), typeof(Object))]
    public static class HUDClose
    {
        public static void Postfix(Object obj)
        {
            if (ExileController.Instance == null || obj != ExileController.Instance.gameObject) return;
            foreach (var role in Role.GetRoles(RoleEnum.Mystic))
            {
                var Mystic = (Mystic) role;
                Mystic.LastExamined = DateTime.UtcNow;
                Mystic.LastExamined = Mystic.LastExamined.AddSeconds(CustomGameOptions.InitialExamineCd - CustomGameOptions.ExamineCd);
            }
        }
    }
}