using System;
using HarmonyLib;
using TownOfRoles.Roles;
using TownOfRoles.Roles.Cultist;

namespace TownOfRoles.CultistRoles.NecromancerMod
{
    [HarmonyPatch(typeof(IntroCutscene._CoBegin_d__33), nameof(IntroCutscene._CoBegin_d__33.MoveNext))]
    public static class Start
    {
        public static void Postfix(IntroCutscene._CoBegin_d__33 __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.Necromancer))
            {
                var necro = (Necromancer) role;
                necro.LastRevived = DateTime.UtcNow;
                necro.LastRevived = necro.LastRevived.AddSeconds(CustomGameOptions.InitialCooldowns - CustomGameOptions.ReviveCooldown);
            }
        }
    }
}