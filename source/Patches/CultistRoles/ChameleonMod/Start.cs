using System;
using HarmonyLib;
using TownOfRoles.Roles;
using TownOfRoles.Roles.Cultist;

namespace TownOfRoles.CultistRoles.ChameleonMod
{
    [HarmonyPatch(typeof(IntroCutscene._CoBegin_d__33), nameof(IntroCutscene._CoBegin_d__33.MoveNext))]
    public static class Start
    {
        public static void Postfix(IntroCutscene._CoBegin_d__33 __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.Chameleon))
            {
                var chameleon = (Chameleon)role;
                chameleon.LastSwooped = DateTime.UtcNow;
                chameleon.LastSwooped = chameleon.LastSwooped.AddSeconds(CustomGameOptions.InitialCooldowns - CustomGameOptions.SwoopCd);
            }
        }
    }
}