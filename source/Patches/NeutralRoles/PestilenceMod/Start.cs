using System;
using HarmonyLib;
using TownOfRoles.Roles;

namespace TownOfRoles.NeutralRoles.PestilenceMod
{
    [HarmonyPatch(typeof(IntroCutscene._CoBegin_d__33), nameof(IntroCutscene._CoBegin_d__33.MoveNext))]
    public static class Start
    {
        public static void Postfix(IntroCutscene._CoBegin_d__33 __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.Pestilence))
            {
                var pestilence = (Pestilence)role;
                pestilence.LastKill = DateTime.UtcNow;
                pestilence.LastKill = pestilence.LastKill.AddSeconds(CustomGameOptions.InitialCooldowns - CustomGameOptions.PestKillCd);
            }
        }
    }
}