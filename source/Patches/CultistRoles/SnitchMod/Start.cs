using System;
using HarmonyLib;
using TownOfRoles.Roles;
using TownOfRoles.Roles.Cultist;

namespace TownOfRoles.CultistRoles.SnitchMod
{
    [HarmonyPatch(typeof(IntroCutscene._CoBegin_d__33), nameof(IntroCutscene._CoBegin_d__33.MoveNext))]
    public static class Start
    {
        public static void Postfix(IntroCutscene._CoBegin_d__33 __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.CultistSnitch))
            {
                var Snitch = (CultistSnitch) role;
                Snitch.LastInvestigated = DateTime.UtcNow;
                Snitch.LastInvestigated = Snitch.LastInvestigated.AddSeconds(CustomGameOptions.InitialCooldowns - CustomGameOptions.SnitchCd);
            }
        }
    }
}