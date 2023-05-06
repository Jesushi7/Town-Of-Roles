using System;
using HarmonyLib;
using TownOfRoles.Roles;

namespace TownOfRoles.ImpostorRoles.GrenadierMod
{
    [HarmonyPatch(typeof(IntroCutscene._CoBegin_d__33), nameof(IntroCutscene._CoBegin_d__33.MoveNext))]
    public static class Start
    {
        public static void Postfix(IntroCutscene._CoBegin_d__33 __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.Grenadier))
            {
                var grenadier = (Grenadier) role;
                grenadier.LastFlashed = DateTime.UtcNow;
                grenadier.LastFlashed = grenadier.LastFlashed.AddSeconds(CustomGameOptions.InitialCooldowns - CustomGameOptions.GrenadeCd);
            }
        }
    }
}