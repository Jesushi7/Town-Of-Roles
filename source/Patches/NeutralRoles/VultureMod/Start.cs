/*using System;
using HarmonyLib;
using TownOfUs.CustomOption;
using TownOfUs.Roles;

namespace TownOfUs.NeutralRoles.VultureMod
{
    [HarmonyPatch(typeof(IntroCutscene._CoBegin_d__19), nameof(IntroCutscene._CoBegin_d__19.MoveNext))]
    public static class Start
    {
        public static void Postfix(IntroCutscene._CoBegin_d__19 __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.Vulture))
            {
                var Vulture = (Vulture)role;
                Vulture.LastEaten = DateTime.UtcNow;
                Vulture.LastEaten = Vulture.LastEaten.AddSeconds(CustomGameOptions.InitialCooldowns - CustomGameOptions.VultureCd);
            }
        }
    }
}*/