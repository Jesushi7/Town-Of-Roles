using System;
using HarmonyLib;
using TownOfRoles.Roles;

namespace TownOfRoles.NeutralRoles.SerialKillerMod
{
    [HarmonyPatch(typeof(IntroCutscene._CoBegin_d__33), nameof(IntroCutscene._CoBegin_d__33.MoveNext))]
    public static class Start
    {
        public static void Postfix(IntroCutscene._CoBegin_d__33 __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.SerialKiller))
            {
                var SerialKiller = (SerialKiller)role;
                SerialKiller.LastKill = DateTime.UtcNow;
                SerialKiller.LastKill = SerialKiller.LastKill.AddSeconds(CustomGameOptions.InitialCooldowns - GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown);
            }
        }
    }
}