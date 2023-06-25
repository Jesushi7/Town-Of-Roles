using System;
using HarmonyLib;
using TownOfRoles.Roles;

namespace TownOfRoles.ImpostorRoles.DisguiserMod
{
    [HarmonyPatch(typeof(IntroCutscene._CoBegin_d__33), nameof(IntroCutscene._CoBegin_d__33.MoveNext))]
    public static class Start
    {
        public static void Postfix(IntroCutscene._CoBegin_d__33 __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.Disguiser))
            {
                var camouflager = (Disguiser)role;
                camouflager.LastDisguised = DateTime.UtcNow;
                camouflager.LastDisguised = camouflager.LastDisguised.AddSeconds(CustomGameOptions.InitialCooldowns - CustomGameOptions.DisguiserCd);
            }
        }
    }
}