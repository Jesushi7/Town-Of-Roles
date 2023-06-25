using System;
using HarmonyLib;
using TownOfRoles.Roles;

namespace TownOfRoles.CrewmateRoles.EngineerMod
{
    [HarmonyPatch(typeof(IntroCutscene._CoBegin_d__33), nameof(IntroCutscene._CoBegin_d__33.MoveNext))]
    public static class Start
    {
        public static void Postfix(IntroCutscene._CoBegin_d__33 __instance)
        {
            if (CustomGameOptions.EngineerFixPer != EngineerFixPer.Custom || !CustomGameOptions.EngiHasCooldown) return;
            foreach (var role in Role.GetRoles(RoleEnum.Engineer))
            {
                var engineer = (Engineer) role;
                engineer.LastFix = DateTime.UtcNow;
                engineer.LastFix = engineer.LastFix.AddSeconds(CustomGameOptions.InitialCooldowns - CustomGameOptions.EngiCooldown);
            }
        }
    }
}