using System;
using HarmonyLib;
using TownOfRoles.Roles;
using TownOfRoles.Roles.Cultist;

namespace TownOfRoles.CultistRoles.WhispererMod
{
    [HarmonyPatch(typeof(IntroCutscene._CoBegin_d__33), nameof(IntroCutscene._CoBegin_d__33.MoveNext))]
    public static class Start
    {
        public static void Postfix(IntroCutscene._CoBegin_d__33 __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.Whisperer))
            {
                var whisperer = (Whisperer) role;
                whisperer.LastWhispered = DateTime.UtcNow;
                whisperer.LastWhispered = whisperer.LastWhispered.AddSeconds(CustomGameOptions.InitialCooldowns - CustomGameOptions.WhisperCooldown);
            }
        }
    }
}