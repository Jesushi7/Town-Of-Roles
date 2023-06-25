using System;
using HarmonyLib;
using TownOfRoles.Roles;

namespace TownOfRoles.NeutralRoles.VultureMod
{
    [HarmonyPatch(typeof(IntroCutscene._CoBegin_d__33), nameof(IntroCutscene._CoBegin_d__33.MoveNext))]
    public static class Start
    {
        public static void Postfix(IntroCutscene._CoBegin_d__33 __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.Vulture))
            {
                var cannibal = (Vulture) role;
                cannibal.LastEat = DateTime.UtcNow.AddSeconds(-CustomGameOptions.VultureCd);
            }
        }
    }
}