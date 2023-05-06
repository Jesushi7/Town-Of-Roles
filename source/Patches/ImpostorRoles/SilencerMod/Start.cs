using System;
using HarmonyLib;
using TownOfRoles.Roles;

namespace TownOfRoles.ImpostorRoles.SilencerMod
{
    [HarmonyPatch(typeof(IntroCutscene._CoBegin_d__33), nameof(IntroCutscene._CoBegin_d__33.MoveNext))]
    public static class Start
    {
        public static void Postfix(IntroCutscene._CoBegin_d__33 __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.Silencer))
            {
                var Silencer = (Silencer) role;
                Silencer.LastSilenced = DateTime.UtcNow;
                Silencer.LastSilenced = Silencer.LastSilenced.AddSeconds(CustomGameOptions.InitialCooldowns - CustomGameOptions.SilenceCd);
            }
        }
    }
}